using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Windows.Forms;

namespace Mtf.MessageBoxes.Exceptions
{
    public class ExceptionHandler
    {
        private int timeout;
        private ILogger<ExceptionHandler> logger;

        public void CatchUnhandledExceptions(bool showFirstChanceExceptions = false, int timeout = Timeout.Infinite)
        {
            this.timeout = timeout;
            
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            AppDomain.CurrentDomain.TypeResolve += CurrentDomain_TypeResolve;
            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
        }

        private Assembly CurrentDomain_TypeResolve(object sender, ResolveEventArgs args)
        {
            var message = $"{args.RequestingAssembly.FullName} cannot load type: {args.Name}";
            ShowError(message);
            return null;
        }

        private void CurrentDomain_FirstChanceException(object sender, FirstChanceExceptionEventArgs e)
        {
            HandleException("First chance exception (AppDomain.CurrentDomain.FirstChanceException)", e.Exception);
        }

        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var message = $"{args.RequestingAssembly?.FullName ?? Application.ProductName} cannot load assembly: {args.Name}";
            logger?.LogError(message);
            ShowMessageForDeveloper(message);
            return null;
        }

        private void ShowError(string message)
        {
            logger?.LogError(message);
            ShowMessageForDeveloper(message);
            ShowError(message, timeout);
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
#if NET452 || NET462
                    logger?.LogError(String.Concat("Unhandled exception (AppDomain.CurrentDomain): ", exception.ToString()));
#else
                    logger?.LogError(exception, "Unhandled exception (AppDomain.CurrentDomain)");
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
            HandleException("Unhandled exception (Application.ThreadException)", e.Exception);
        }

        private void HandleException(string message, Exception exception)
        {
            try
            {
#if NET452 || NET462
                logger?.LogError(String.Concat($"{message}: ", exception.ToString()));
#else
                logger?.LogError(exception, message);
#endif
                ShowException(exception, timeout);
            }
            catch (Exception ex)
            {
                ShowExceptionForDeveloper(ex);
            }
        }

        private void ShowMessageForDeveloper(string message)
        {
            Debug.WriteLine(message);
            Console.Error.WriteLine(message);
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

        private void ShowError(string message, int timeout)
        {
            if (Debugger.IsAttached)
            {
                DebugErrorBox.Show("Debugger error", message, timeout);
            }
            else
            {
                ErrorBox.Show("Error", message, timeout);
            }
        }
    }
}
