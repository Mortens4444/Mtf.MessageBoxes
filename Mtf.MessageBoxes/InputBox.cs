using System;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Mtf.MessageBoxes
{
    public partial class InputBox : BaseBox
    {
        private readonly bool showAutoCloseButtons;

        private readonly string okText = "";
        private readonly string cancelText = "";

        protected InputBox() { }

        public InputBox(string title, string question, int intervalInMs = Timeout.Infinite, string defaultAnswer = "", MessageBoxButtons messageBoxButtons = MessageBoxButtons.OKCancel)
        {
            InitializeComponent();

            Text = String.Concat(Application.ProductName, ": ", title);
            rtbQuestion.Text = question;
            rtbAnswer.Text = defaultAnswer;
            closeTimer.Enabled = false;

            showAutoCloseButtons = intervalInMs != Timeout.Infinite;
            if (showAutoCloseButtons)
            {
                closeTimer.Interval = intervalInMs;
            }

            decrementSecondsLeftTimer.Enabled = false;

            switch (messageBoxButtons)
            {
                case MessageBoxButtons.OK:
                    //btnOk.Text = OK;
                    btnCancel.Visible = false;
                    break;

                case MessageBoxButtons.AbortRetryIgnore:
                    okText = Retry;
                    btnOk.Text = Retry;
                    btnOk.DialogResult = DialogResult.Retry;
                    cancelText = Abort;
                    btnCancel.Text = Abort;
                    btnCancel.DialogResult = DialogResult.Abort;
                    break;

                case MessageBoxButtons.YesNoCancel:
                    throw new NotImplementedException("Use MessageBoxButtons.YesNo instead of this option.");

                case MessageBoxButtons.YesNo:
                    okText = Yes;
                    btnOk.Text = Yes;
                    btnOk.DialogResult = DialogResult.Yes;
                    cancelText = No;
                    btnCancel.Text = No;
                    btnCancel.DialogResult = DialogResult.No;
                    btnCancel.Visible = true;
                    break;

                case MessageBoxButtons.RetryCancel:
                    okText = Retry;
                    btnOk.Text = Retry;
                    btnOk.DialogResult = DialogResult.Retry;
                    cancelText = Cancel;
                    btnCancel.Text = Cancel;
                    btnCancel.Visible = true;
                    break;

                case MessageBoxButtons.OKCancel:
                default:
                    okText = OK;
                    btnOk.Text = OK;
                    btnOk.DialogResult = DialogResult.OK;
                    cancelText = Cancel;
                    btnCancel.Text = Cancel;
                    btnCancel.DialogResult = DialogResult.Cancel;
                    break;
            }
        }
        
        [DefaultValue("")]
        public string Answer
        {
            get { return rtbAnswer.Text; }
            set { rtbAnswer.Text = value; }
        }

        protected override void PinMessage()
        {
            closeTimer.Stop();
            decrementSecondsLeftTimer.Stop();
            btnPin.Visible = false;
            btnUnpin.Visible = showAutoCloseButtons;
            tooltip.SetToolTip(btnUnpin, EnableAutomaticMessageClosing);
            btnOk.Text = okText;
            btnCancel.Text = cancelText;
        }

        protected override void UnpinMessage()
        {
            btnPin.Visible = true;
            btnUnpin.Visible = false;
            tooltip.SetToolTip(btnPin, DisableAutomaticMessageClosing);
            closeTimer.Start();
            decrementSecondsLeftTimer.Start();
            secondsLeft = (int)(Math.Truncate((decimal)closeTimer.Interval / 1000));
            ShowMessageOnDefaultButton();
        }

        private void ShowMessageOnDefaultButton()
        {
            var okSecondsLeft = new StringBuilder();
            okSecondsLeft.AppendFormat("{0} ({1})", okText, secondsLeft);
            btnOk.Text = okSecondsLeft.ToString();
        }

        private void DecrementSecondsLeft_Tick(object sender, EventArgs e)
        {
            secondsLeft--;
            ShowMessageOnDefaultButton();
        }

        public static string Show(string title, string question, int intervalInMs = Timeout.Infinite, string defaultAnswer = "")
        {
            return Show(null, title, question, intervalInMs, defaultAnswer);
        }

        public static string Show(string title, string question, string defaultAnswer = "")
        {
            return Show(null, title, question, Timeout.Infinite, defaultAnswer);
        }

        public static string Show(Form parent, string title, string question, int intervalInMs = Timeout.Infinite, string defaultAnswer = "")
        {
            var inputBox = new InputBox(title, question, intervalInMs, defaultAnswer)
            {
                parent = parent
            };
            if (intervalInMs == Timeout.Infinite)
            {
                inputBox.PinMessage();
            }
            else
            {
                inputBox.UnpinMessage();
            }

            if (Show(inputBox) == DialogResult.OK)
            {
                return inputBox.Answer;
            };

            return null;
        }

        private void InputBox_Shown(object sender, EventArgs e)
        {
            rtbQuestion.Select(0, 0);
        }
    }
}
