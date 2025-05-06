using System;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Mtf.MessageBoxes
{
    public partial class InputBox : BaseBox
    {
        private readonly bool showAutocloseButtons;

        protected InputBox() { }

        public InputBox(string title, string question, int intervalInMs = Timeout.Infinite, string defaultAnswer = "", MessageBoxButtons messageBoxButtons = MessageBoxButtons.OKCancel)
        {
            InitializeComponent();
            btnOk.Text = OK;
            btnCancel.Text = Cancel;
            Text = String.Concat(Application.ProductName, ": ", title);
            rtbQuestion.Text = question;
            rtbAnswer.Text = defaultAnswer;
            closeTimer.Enabled = false;

            showAutocloseButtons = intervalInMs != Timeout.Infinite;
            if (showAutocloseButtons)
            {
                closeTimer.Interval = intervalInMs;
            }

            decrementSecondsLeftTimer.Enabled = false;

            switch (messageBoxButtons)
            {
                case MessageBoxButtons.OK:
                    btnOk.Text = Constants.OK;
                    btnCancel.Visible = false;
                    break;

                case MessageBoxButtons.AbortRetryIgnore:
                    btnOk.Text = Constants.RETRY;
                    btnOk.DialogResult = DialogResult.Retry;
                    btnCancel.Text = Constants.ABORT;
                    btnCancel.DialogResult = DialogResult.Abort;
                    break;

                case MessageBoxButtons.YesNoCancel:
                    throw new NotImplementedException("Use MessageBoxButtons.YesNo instead of this option.");

                case MessageBoxButtons.YesNo:
                    btnOk.Text = Constants.YES;
                    btnOk.DialogResult = DialogResult.Yes;
                    btnCancel.Text = Constants.NO;
                    btnCancel.DialogResult = DialogResult.No;
                    btnCancel.Visible = true;
                    break;

                case MessageBoxButtons.RetryCancel:
                    btnOk.Text = Constants.RETRY;
                    btnOk.DialogResult = DialogResult.Retry;
                    btnCancel.Text = Constants.CANCEL;
                    btnCancel.Visible = true;
                    break;

                case MessageBoxButtons.OKCancel:
                default:
                    //btnOk.Text = Constants.OK;
                    btnOk.DialogResult = DialogResult.OK;
                    //btnCancel.Text = Constants.CANCEL;
                    break;
            }
        }

        [DefaultValue("")]
        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }
        
        [DefaultValue("")]
        public string Answer
        {
            get { return rtbAnswer.Text; }
            set { rtbAnswer.Text = value; }
        }

        private void BtnPin_Click(object sender, EventArgs e)
        {
            PinMessage();
        }

        private void BtnUnpin_Click(object sender, EventArgs e)
        {
            UnpinMessage();
        }

        private void PinMessage()
        {
            closeTimer.Stop();
            decrementSecondsLeftTimer.Stop();
            btnPin.Visible = false;
            btnUnpin.Visible = showAutocloseButtons;
            tooltip.SetToolTip(btnUnpin, EnableAutomaticMessageClosing);
            btnOk.Text = Yes;
            btnCancel.Text = No;
        }

        private void UnpinMessage()
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
            okSecondsLeft.AppendFormat("{0} ({1})", OK, secondsLeft);
            btnCancel.Text = okSecondsLeft.ToString();
        }

        private void DecrementSecondsLeft_Tick(object sender, EventArgs e)
        {
            secondsLeft--;
            ShowMessageOnDefaultButton();
        }

        private static DialogResult Show(InputBox cb)
        {
            if (cb.parent != null)
            {
                cb.Left = cb.parent.Left + (cb.parent.Width - cb.Width) / 2;
                cb.Top = cb.parent.Top + (cb.parent.Height - cb.Height) / 2;
            }
            else
            {
                cb.StartPosition = FormStartPosition.CenterScreen;
            }

            return cb.ShowDialog();
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
            var cb = new InputBox(title, question, intervalInMs, defaultAnswer)
            {
                parent = parent
            };
            if (intervalInMs == Timeout.Infinite)
            {
                cb.PinMessage();
            }
            else
            {
                cb.UnpinMessage();
            }

            if (Show(cb) == DialogResult.OK)
            {
                return cb.Answer;
            };

            return null;
        }

        private void Close_Tick(object sender, EventArgs e)
        {
            AcceptButton?.PerformClick();
        }

        private void InputBox_Shown(object sender, EventArgs e)
        {
            rtbQuestion.Select(0, 0);
            AcceptButton = btnOk;
            CancelButton = btnCancel;
        }
    }
}
