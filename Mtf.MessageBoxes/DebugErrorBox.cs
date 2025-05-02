using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Mtf.MessageBoxes
{
    public static class DebugErrorBox
    {
        public static void Show(Exception ex, int timeout = Timeout.Infinite)
        {
            if (Debugger.IsAttached)
            {
                ErrorBox.Show(ex, timeout);
            }
        }

        public static void Show(string title, string message, int timeout = Timeout.Infinite)
        {
            if (Debugger.IsAttached || File.Exists("debug"))
            {
                ErrorBox.Show(String.Concat("DEBUG: ", title), message, timeout);
            }
        }
    }
}
