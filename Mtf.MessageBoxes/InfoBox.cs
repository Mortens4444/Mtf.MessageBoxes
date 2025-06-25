using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Mtf.MessageBoxes
{
    public partial class InfoBox : BaseBox
    {
        protected InfoBox() { }

        InfoBox(string title, string message, int intervalInMs)
        {
            try
            {
                InitializeComponent();
                btnOk.Text = OK;
                Text = String.Concat(Application.ProductName, ": ", title);
                rtbMessage.Text = message;
                closeTimer.Enabled = false;
                if (intervalInMs != Timeout.Infinite)
                {
                    closeTimer.Interval = intervalInMs;
                }
                else
                {
                    btnPin.Visible = false;
                    btnUnpin.Visible = false;
                }
                decrementSecondsLeftTimer.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        protected override void PinMessage()
        {
            closeTimer.Stop();
            decrementSecondsLeftTimer.Stop();
            btnPin.Visible = false;
            btnUnpin.Visible = true;
            tooltip.SetToolTip(btnUnpin, EnableAutomaticMessageClosing);
            btnOk.Text = OK;
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
            var okSecondsLeft = new StringBuilder(OK);
            okSecondsLeft.AppendFormat($" ({secondsLeft})");
            btnOk.Text = okSecondsLeft.ToString();
        }

        private void DecrementSecondsLeft_Tick(object sender, EventArgs e)
        {
            secondsLeft--;
            ShowMessageOnDefaultButton();
        }

        public static DialogResult Show(string title, string message, int intervalInMs)
        {
            return Show(null, title, message, intervalInMs);
        }

        public static DialogResult Show(string title, string message)
        {
            return Show(null, title, message, Constants.MilliSecondsLeft);
        }

        public static DialogResult Show(Form parent, string title, string message)
        {
            return Show(parent, title, message, Constants.MilliSecondsLeft);
        }

        public static DialogResult Show(Form parent, string title, string message, int intervalInMs)
        {
            var infoBox = new InfoBox(title, message, intervalInMs)
            {
                parent = parent
            };
            if (intervalInMs != Timeout.Infinite)
            {
                infoBox.UnpinMessage();
            }
            return Show(infoBox);
        }

        private void InfoBox_Shown(object sender, EventArgs e)
        {
            rtbMessage.Select(0, 0);
        }
    }
}
