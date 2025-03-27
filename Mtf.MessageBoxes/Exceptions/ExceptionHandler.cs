using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Mtf.MessageBoxes.Exceptions
{
    public class ExceptionHandler
    {
        private int timeout;
        private ILogger<ExceptionHandler> logger;

        public void CatchUnhandledExceptions(int timeout = Timeout.Infinite)
        {
            this.timeout = timeout;
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        public void SetLogger(ILogger<ExceptionHandler> logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            this.logger = logger;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                if (e.ExceptionObject is Exception exception)
                {
#if NET462_OR_GREATER
                    logger?.LogError(exception, "Unhandled exception (AppDomain.CurrentDomain)");
#else
                    logger?.LogError(String.Concat("Unhandled exception (AppDomain.CurrentDomain): ", exception.ToString()));
#endif
                    ShowException(exception, timeout);
                }
            }
            catch (Exception ex)
            {
                ShowExceptionForDeveloper(ex);
            }
        }

        private void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
#if NET462_OR_GREATER
                logger?.LogError(e.Exception, "Unhandled exception (Application.ThreadException)");
#else
                logger?.LogError(String.Concat("Unhandled exception (Application.ThreadException): ", e.Exception.ToString()));
#endif
                ShowException(e.Exception, timeout);
            }
            catch (Exception ex)
            {
                ShowExceptionForDeveloper(ex);
            }
        }

        private void ShowExceptionForDeveloper(Exception exception)
        {
            Debug.WriteLine(exception);
            Console.Error.WriteLine(exception);
        }

        private void ShowException(Exception exception, int timeout)
        {
            if (Debugger.IsAttached)
            {
                DebugErrorBox.Show(exception, timeout);
            }
            else
            {
                ErrorBox.Show("Unhandled exception", exception.GetInnermostException().Message, timeout);
            }
        }
    }
}
