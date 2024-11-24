using Mtf.MessageBoxes;
using System;
using System.ComponentModel;
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

        [DefaultValue("")]
        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void BtnPin_Click(object sender, EventArgs e)
        {
            PinMessage();
        }

        private void BtnUnpin_Click(object sender, EventArgs e)
        {
            UnpinMessage();
        }

        void PinMessage()
        {
            closeTimer.Stop();
            decrementSecondsLeftTimer.Stop();
            btnPin.Visible = false;
            btnUnpin.Visible = true;
            tooltip.SetToolTip(btnUnpin, EnableAutomaticMessageClosing);
            btnOk.Text = OK;
        }

        private void UnpinMessage()
        {
            btnPin.Visible = true;
            btnUnpin.Visible = false;
            tooltip.SetToolTip(btnPin, DisableAutomaticMessageClosing);
            closeTimer.Start();
            decrementSecondsLeftTimer.Start();
            secondsLeft = (int)(Math.Truncate((decimal)closeTimer.Interval / 1000));
            ShowMessageOnOKButton();
        }

        private void ShowMessageOnOKButton()
        {
            var ok_secondsLeft = new StringBuilder(OK);
            ok_secondsLeft.AppendFormat(" ({0})", secondsLeft);
            btnOk.Text = ok_secondsLeft.ToString();
        }

        private void DecrementSecondsLeft_Tick(object sender, EventArgs e)
        {
            secondsLeft--;
            ShowMessageOnOKButton();
        }

        private static DialogResult Show(InfoBox ib)
        {
            if (ib.parent != null)
            {
                ib.Left = ib.parent.Left + (ib.parent.Width - ib.Width) / 2;
                ib.Top = ib.parent.Top + (ib.parent.Height - ib.Height) / 2;
            }
            else
            {
                ib.StartPosition = FormStartPosition.CenterScreen;
            }
            return ib.ShowDialog();
        }

        public static DialogResult Show(string title, string message, int intervalInMs)
        {
            return Show(null, title, message, intervalInMs);
        }

        public static DialogResult Show(string title, string message)
        {
            return Show(null, title, message, Constants.MILLIsecondsLeft);
        }

        public static DialogResult Show(Form parent, string title, string message)
        {
            return Show(parent, title, message, Constants.MILLIsecondsLeft);
        }

        public static DialogResult Show(Form parent, string title, string message, int intervalInMs)
        {
            var ib = new InfoBox(title, message, intervalInMs)
            {
                parent = parent
            };
            if (intervalInMs != Timeout.Infinite)
            {
                ib.UnpinMessage();
            }
            return Show(ib);
        }

        private void Close_Tick(object sender, EventArgs e)
        {
            Close();
        }

        private void InfoBox_Shown(object sender, EventArgs e)
        {
            rtbMessage.Select(0, 0);
        }
    }
}
