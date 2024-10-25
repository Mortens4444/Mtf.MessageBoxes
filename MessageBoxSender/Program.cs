using Enums;
using MessageBoxes;
using System.Collections.Generic;
using System.Threading;
using System;
using System.Windows.Forms;

namespace MessageBoxSender
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string title = "Message box sender";
            string message = "This is a default message, you can set up a custom message with the -m directive.";
            var messageType = MessageType.Information;
            var timeout = Timeout.Infinite;
            var decide = Decide.Yes;

            var messageAliases = new List<string> { "message", "m" };
            var infoAliases = new List<string> { "info", "information", "i" };
            var questionAliases = new List<string> { "question", "q" };
            var errorAliases = new List<string> { "error", "e" };
            var titleAliases = new List<string> { "title", "t" };
            var yesAliases = new List<string> { "yes", "y" };
            var noAliases = new List<string> { "no", "n" };

            int i = 0;
            while (i < args.Length)
            {
                var arg = args[i].ToLower().TrimStart('/', '-');
                if (messageAliases.Contains(arg))
                {
                    message = TestArgsLength(i, args.Length) ? "No message provided." : args[++i];
                }
                else if (infoAliases.Contains(arg))
                {
                    messageType = MessageType.Information;
                }
                else if (questionAliases.Contains(arg))
                {
                    messageType = MessageType.Question;
                }
                else if (errorAliases.Contains(arg))
                {
                    messageType = MessageType.Error;
                }
                else if (titleAliases.Contains(arg))
                {
                    title = TestArgsLength(i, args.Length) ? "No title has been provided" : args[++i];
                }
                else if (yesAliases.Contains(arg))
                {
                    decide = Decide.Yes;
                }
                else if (noAliases.Contains(arg))
                {
                    decide = Decide.No;
                }
                else if (arg == "timeout")
                {
                    timeout = TestArgsLength(i, args.Length) ? Timeout.Infinite : Convert.ToInt32(args[++i]);
                }
                i++;
            }

            switch (messageType)
            {
                case MessageType.Information:
                    InfoBox.Show(title, message, timeout);
                    break;
                case MessageType.Question:
                    ConfirmBox.Show(title, message, timeout, decide);
                    break;
                case MessageType.Error:
                    ErrorBox.Show(title, message, timeout);
                    break;
            }
        }

        private static bool TestArgsLength(int i, int argsLength)
        {
            return i + 1 > argsLength;
        }
    }
}
