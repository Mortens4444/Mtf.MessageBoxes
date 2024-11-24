using Mtf.MessageBoxes;
using Mtf.MessageBoxes.Enums;
using Mtf.MessageBoxes.Exceptions;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Mtf.MessageBoxes
{
    public sealed partial class ErrorBox : BaseBox
    {
        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, SetWindowPosFlags uFlags);

        ErrorBox(string title, string message, int intervalInMs)
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

            tooltipTwo.SetToolTip(btn_SendToClipboard, CopyToClipboard);
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
            var okSecondsLeft = new StringBuilder(OK);
            okSecondsLeft.AppendFormat($" ({secondsLeft})");
            btnOk.Text = okSecondsLeft.ToString();
        }

        private void DecrementSecondsLeft_Tick(object sender, EventArgs e)
        {
            secondsLeft--;
            ShowMessageOnOKButton();
        }

        private static DialogResult Show(ErrorBox eb)
        {
            if (eb.parent != null)
            {
                eb.Left = eb.parent.Left + (eb.parent.Width - eb.Width) / 2;
                eb.Top = eb.parent.Top + (eb.parent.Height - eb.Height) / 2;
            }
            else eb.StartPosition = FormStartPosition.CenterScreen;

            Console.Beep(440, 200);
            try
            {
                return eb.ShowDialog();
            }
            catch { return DialogResult.None; }
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

        public static void ShowLastWin32Error()
        {
            Show(new Win32Exception(Marshal.GetLastWin32Error()));
        }

        public static void ShowFileNotFound(string filename)
        {
            Show(Constants.GENERAL_ERROR, String.Concat(Constants.FILE_NOT_FOUND, filename));
        }

        public static void ShowLastWin32ErrorIfNotSuccess()
        {
            var error_code = Marshal.GetLastWin32Error();
            if (error_code != 0) Show(new Win32Exception(error_code));
        }

        public static DialogResult Show(Exception ex)
        {
            var ed = new ExceptionDetails(ex);
            return Show(null, ed.ExceptionType, ed.Details, Constants.MILLIsecondsLeft);
        }

        public static DialogResult ShowServiceNotification(Exception ex)
        {
            return MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        }

        public static DialogResult Show(Exception ex, int intervalInMs)
        {
            var ed = new ExceptionDetails(ex);
            return Show(null, ed.ExceptionType, ed.Details, intervalInMs);
        }

        public static DialogResult Show(Form parent, Exception ex)
        {
            var ed = new ExceptionDetails(ex);
            return Show(parent, ed.ExceptionType, ed.Details, Constants.MILLIsecondsLeft);
        }

        public static DialogResult Show(Form parent, string title, Exception ex)
        {
            return Show(parent, title, ex.GetDetails(), Constants.MILLIsecondsLeft);
        }

        public static DialogResult Show(string title, Exception ex)
        {
            return Show(null, title, ex.GetDetails(), Constants.MILLIsecondsLeft);
        }

        public static DialogResult Show(string title, Exception ex, int intervalInMs)
        {
            return Show(null, title, ex.GetDetails(), intervalInMs);
        }

        public static DialogResult Show(Form parent, string title, string message, int intervalInMs)
        {
            var eb = new ErrorBox(title, message, intervalInMs)
            {
                parent = parent
            };
            if (intervalInMs != Timeout.Infinite) eb.UnpinMessage();
            return Show(eb);
        }

        private void Close_Tick(object sender, EventArgs e)
        {
            Close();
        }

        private void ErrorBox_Shown(object sender, EventArgs e)
        {
            rtbMessage.Select(0, 0);
        }

        private void ErrorBox_Load(object sender, EventArgs e)
        {
            //SetWindowLong(this.Handle, (int)GetWindowLongParam.GWL_EXSTYLE, (WinAPI.GetWindowLong(this.Handle, GetWindowLongParam.GWL_EXSTYLE) | (int)ExtendedWindowStyles.WS_EX_TOPMOST));
            SetWindowPos(Handle, new IntPtr(-1), 0, 0, 0, 0, SetWindowPosFlags.IgnoreResize | SetWindowPosFlags.IgnoreMove); // Set TOP_MOST
        }

        private void Tsmi_Copy_Click(object sender, EventArgs e)
        {
            ToClipboard();
        }

        private void Btn_SendToClipboard_Click(object sender, EventArgs e)
        {
            ToClipboard();
        }

        private void ToClipboard()
        {
            try
            {
                /*Thread.CurrentThread.SetApartmentState(ApartmentState.STA);
                Clipboard.SetText(rtbMessage.Text);*/
                rtbMessage.SelectAll();
                rtbMessage.Focus();
                //Clipboard.SetText(rtbMessage.Text);
                SendKeys.Send("^(C)");
                //rtbMessage.Select(0, 0);
            }
            catch (Exception ex)
            {
                Show(ex);
            }
        }
    }
}
