using System;
using System.Runtime.InteropServices;

namespace Mtf.MessageBoxes.Exceptions
{
    public static class ExceptionExtensions
    {
        public static int GetErrorCode(this Exception ex)
        {
            return Marshal.GetHRForException(ex);
        }

        public static string GetDetails(this Exception ex)
        {
            return (new ExceptionDetails(ex)).Details;
        }

        public static Exception GetInnermostException(this Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }

    }
}
