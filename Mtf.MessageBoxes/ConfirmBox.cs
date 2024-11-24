using Mtf.MessageBoxes.Enums;
using System;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Mtf.MessageBoxes
{
    public partial class ConfirmBox : BaseBox
    {
        private readonly bool defaultChoice;
        private readonly bool showAutocloseButtons;

        protected ConfirmBox() { }

        protected ConfirmBox(string title, string message, int intervalInMs = 10000, Decide defaultChoice = Decide.No)
        {
            InitializeComponent();
            btn_Yes.Text = Yes;
            btn_No.Text = No;
            Text = String.Concat(Application.ProductName, ": ", title);
            rtbMessage.Text = message;
            closeTimer.Enabled = false;
            this.defaultChoice = Decide.Yes == defaultChoice;

            showAutocloseButtons = intervalInMs != Timeout.Infinite;
            if (showAutocloseButtons)
            {
                closeTimer.Interval = intervalInMs;
            }

            decrementSecondsLeftTimer.Enabled = false;
        }

        [DefaultValue("")]
        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void FocusAcceptButton()
        {
            var button = defaultChoice ? btn_Yes : btn_No;
            button.Focus();
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
            btn_Yes.Text = Yes;
            btn_No.Text = No;
            FocusAcceptButton();
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
            okSecondsLeft.Append(defaultChoice ? Yes : No);
            okSecondsLeft.AppendFormat(" ({0})", secondsLeft);
            var button = defaultChoice ? btn_Yes : btn_No;
            button.Text = okSecondsLeft.ToString();
        }

        private void DecrementSecondsLeft_Tick(object sender, EventArgs e)
        {
            secondsLeft--;
            ShowMessageOnDefaultButton();
        }

        private static DialogResult Show(ConfirmBox cb)
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

        public static DialogResult Show(string title, string message, int intervalInMs = 10000, Decide defaultChoice = Decide.No)
        {
            return Show(null, title, message, intervalInMs, defaultChoice);
        }

        public static DialogResult Show(string title, string message, Decide defaultChoice = Decide.No)
        {
            return Show(null, title, message, Timeout.Infinite, defaultChoice);
        }

        public static DialogResult Show(Form parent, string title, string message, Decide defaultChoice = Decide.No)
        {
            return Show(parent, title, message, Timeout.Infinite, defaultChoice);
        }

        public static DialogResult Show(Form parent, string title, string message, int intervalInMs = 10000, Decide defaultChoice = Decide.No)
        {
            var cb = new ConfirmBox(title, message, intervalInMs, defaultChoice)
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

            return Show(cb);
        }

        private void Close_Tick(object sender, EventArgs e)
        {
            AcceptButton?.PerformClick();
        }

        private void ConfirmBox_Shown(object sender, EventArgs e)
        {
            rtbMessage.Select(0, 0);
            AcceptButton = defaultChoice ? btn_Yes : btn_No;
            CancelButton = btn_No;
            FocusAcceptButton();
        }
    }
}
