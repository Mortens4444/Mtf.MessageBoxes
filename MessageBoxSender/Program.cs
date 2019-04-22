using Enums;
using MessageBoxes;
using System;
using System.Threading;
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

            int i = 0;
            while (i < args.Length)
            {
                var arg = args[i].ToLower();
                switch (arg)
                {
                    case "-message":
                    case "/message":
                    case "-m":
                    case "/m":
                        message = TestArgsLength(i, args.Length) ? "No message provided." : args[++i];
                        break;
                    case "-info":
                    case "/info":
                    case "-information":
                    case "/information":
                    case "-i":
                    case "/i":
                        messageType = MessageType.Information;
                        break;
                    case "-question":
                    case "/question":
                    case "-q":
                    case "/q":
                        messageType = MessageType.Question;
                        break;
                    case "-error":
                    case "/error":
                    case "-e":
                    case "/e":
                        messageType = MessageType.Error;
                        break;
                    case "-timeout":
                    case "/timeout":
                        timeout = TestArgsLength(i, args.Length) ? Timeout.Infinite : Convert.ToInt32(args[++i]);
                        break;
                    case "-title":
                    case "/title":
                    case "-t":
                    case "/t":
                        title = TestArgsLength(i, args.Length) ? "No title has been provided" : args[++i];
                        break;
                    case "-yes":
                    case "/yes":
                    case "-y":
                    case "/y":
                        decide = Decide.Yes;
                        break;
                    case "-no":
                    case "/no":
                    case "-n":
                    case "/n":
                        decide = Decide.No;
                        break;
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
