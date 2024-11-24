using System;
using System.Diagnostics;

namespace Mtf.MessageBoxes
{
    public static class DebugErrorBox
    {
        public static void Show(Exception ex)
        {
            if (Debugger.IsAttached)
            {
                ErrorBox.Show(ex);
            }
        }

        public static void Show(string title, string message)
        {
            if (Debugger.IsAttached)
            {
                ErrorBox.Show(title, message);
            }
        }
    }
}
