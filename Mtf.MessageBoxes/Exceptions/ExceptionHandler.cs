using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;


namespace Mtf.MessageBoxes.Exceptions
{
    public static class ExceptionHandler
    {
        public static void CatchUnhandledExceptions()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                if (e.ExceptionObject is Exception exception)
                {
                    ShowException(exception);
                }
            }
            catch (Exception ex)
            {
                ShowExceptionForDeveloper(ex);
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                ShowException(e.Exception);
            }
            catch (Exception ex)
            {
                ShowExceptionForDeveloper(ex);
            }
        }

        private static void ShowExceptionForDeveloper(Exception exception)
        {
            Debug.WriteLine(exception);
            Console.Error.WriteLine(exception);
        }

        private static void ShowException(Exception exception)
        {
#if DEBUG
            DebugErrorBox.Show(exception);
#else
            ErrorBox.Show("Unhandled exception", exception.Message);
#endif
        }
    }
}
