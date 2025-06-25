using Mtf.MessageBoxes.Enums;
using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Mtf.MessageBoxes
{
    public partial class ConfirmBox : BaseBox
    {
        private readonly bool defaultChoice;
        private readonly bool showAutoCloseButtons;

        protected ConfirmBox() { }

        protected ConfirmBox(string title, string message, int intervalInMs = 10000, Decide defaultChoice = Decide.No)
        {
            try
            {
                InitializeComponent();
                btnYes.Text = Yes;
                btnNo.Text = No;
                Text = String.Concat(Application.ProductName, ": ", title);
                rtbMessage.Text = message;
                closeTimer.Enabled = false;
                this.defaultChoice = Decide.Yes == defaultChoice;

                showAutoCloseButtons = intervalInMs != Timeout.Infinite;
                if (showAutoCloseButtons)
                {
                    closeTimer.Interval = intervalInMs;
                }

                decrementSecondsLeftTimer.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            }
        }

        private void FocusAcceptButton()
        {
            var button = defaultChoice ? btnYes : btnNo;
            button.Focus();
        }

        protected override void PinMessage()
        {
            closeTimer.Stop();
            decrementSecondsLeftTimer.Stop();
            btnPin.Visible = false;
            btnUnpin.Visible = showAutoCloseButtons;
            tooltip.SetToolTip(btnUnpin, EnableAutomaticMessageClosing);
            btnYes.Text = Yes;
            btnNo.Text = No;
            FocusAcceptButton();
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
            okSecondsLeft.Append(defaultChoice ? Yes : No);
            okSecondsLeft.AppendFormat($" ({secondsLeft})");
            var button = defaultChoice ? btnYes : btnNo;
            button.Text = okSecondsLeft.ToString();
        }

        private void DecrementSecondsLeft_Tick(object sender, EventArgs e)
        {
            secondsLeft--;
            ShowMessageOnDefaultButton();
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
            var confirmBox = new ConfirmBox(title, message, intervalInMs, defaultChoice)
            {
                parent = parent
            };
            if (intervalInMs == Timeout.Infinite)
            {
                confirmBox.PinMessage();
            }
            else
            {
                confirmBox.UnpinMessage();
            }

            return Show(confirmBox);
        }

        private void ConfirmBox_Shown(object sender, EventArgs e)
        {
            rtbMessage.Select(0, 0);
            AcceptButton = defaultChoice ? btnYes : btnNo;
            CancelButton = btnNo;
            FocusAcceptButton();
        }
    }
}
