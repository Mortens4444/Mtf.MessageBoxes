using Enums;
using System;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MessageBoxes
{
    public partial class ConfirmBox : BaseBox
    {
        readonly bool default_choose;
        readonly bool show_autoclose_buttons;

        protected ConfirmBox() { }

        protected ConfirmBox(string title, string message, int intervalInMs, Decide default_choose)
        {
            InitializeComponent();
            btn_Yes.Text = Yes;
            btn_No.Text = No;
            Text = String.Concat(Application.ProductName, ": ", title);
            rtbMessage.Text = message;
            closeTimer.Enabled = false;
            this.default_choose = Decide.Yes == default_choose;

            show_autoclose_buttons = intervalInMs != Timeout.Infinite;
            if (show_autoclose_buttons) closeTimer.Interval = intervalInMs;
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
            if (default_choose) btn_Yes.Focus();
            else btn_No.Focus();
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
            btnUnpin.Visible = show_autoclose_buttons;
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
            var ok_secondsLeft = new StringBuilder();
            ok_secondsLeft.Append(default_choose ? Yes : No);
            ok_secondsLeft.AppendFormat(" ({0})", secondsLeft);
            if (default_choose) btn_Yes.Text = ok_secondsLeft.ToString();
            else btn_No.Text = ok_secondsLeft.ToString();
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
            else cb.StartPosition = FormStartPosition.CenterScreen;
            return cb.ShowDialog();
        }

        public static DialogResult Show(string title, string message, int intervalInMs, Decide default_choose)
        {
            return Show(null, title, message, intervalInMs, default_choose);
        }

        public static DialogResult Show(string title, string message, Decide default_choose)
        {
            return Show(null, title, message, Timeout.Infinite, default_choose);
        }

        public static DialogResult Show(Form parent, string title, string message, Decide default_choose)
        {
            return Show(parent, title, message, Timeout.Infinite, default_choose);
        }

        public static DialogResult Show(Form parent, string title, string message, int intervalInMs, Decide default_choose)
        {
            var cb = new ConfirmBox(title, message, intervalInMs, default_choose)
            {
                parent = parent
            };
            if (intervalInMs == Timeout.Infinite) cb.PinMessage();
            else cb.UnpinMessage();
            return Show(cb);
        }

        private void Close_Tick(object sender, EventArgs e)
        {
            AcceptButton?.PerformClick();
        }

        private void ConfirmBox_Shown(object sender, EventArgs e)
        {
            rtbMessage.Select(0, 0);
            AcceptButton = default_choose ? btn_Yes : btn_No;
            CancelButton = btn_No;
            FocusAcceptButton();
        }
    }
}
