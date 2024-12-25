using System;
using System.Diagnostics;
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
            if (Debugger.IsAttached)
            {
                ErrorBox.Show(title, message, timeout);
            }
        }
    }
}
