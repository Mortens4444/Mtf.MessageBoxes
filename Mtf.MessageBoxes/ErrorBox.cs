using Mtf.MessageBoxes.Enums;
using Mtf.MessageBoxes.Exceptions;
using System;
using System.ComponentModel;
using System.Diagnostics;
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
            try
            {
                try
                {
                    var msg = $"{title}{Environment.NewLine}------------------------------------------------------------------{Environment.NewLine}{message}";
                    Debug.WriteLine(msg);
                    Console.Error.WriteLine(msg);
                }
                catch { }
                InitializeComponent();
                btnOk.Text = OK;
                Text = String.Concat(Application.ProductName, ": ", title);
                rtbMessage.Text = message;
                closeTimer.Enabled = false;
                tsmiCopy.Text = Copy;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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

        private static DialogResult Show(ErrorBox errorBox)
        {
            Console.Beep(440, 200);
            try
            {
                return BaseBox.Show(errorBox);
            }
            catch
            {
                return DialogResult.None;
            }
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

        public static void ShowLastWin32Error()
        {
            Show(new Win32Exception(Marshal.GetLastWin32Error()));
        }

        public static void ShowFileNotFound(string filename)
        {
            Show(Constants.GeneralError, String.Concat(Constants.FileNotFound, filename));
        }

        public static void ShowLastWin32ErrorIfNotSuccess()
        {
            var error_code = Marshal.GetLastWin32Error();
            if (error_code != 0)
            {
                Show(new Win32Exception(error_code));
            }
        }

        public static DialogResult Show(Exception ex)
        {
            var ed = new ExceptionDetails(ex);
            return Show(null, ed.ExceptionType, ed.Details, Constants.MilliSecondsLeft);
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
            return Show(parent, ed.ExceptionType, ed.Details, Constants.MilliSecondsLeft);
        }

        public static DialogResult Show(Form parent, string title, Exception ex)
        {
            return Show(parent, title, ex.GetDetails(), Constants.MilliSecondsLeft);
        }

        public static DialogResult Show(string title, Exception ex)
        {
            return Show(null, title, ex.GetDetails(), Constants.MilliSecondsLeft);
        }

        public static DialogResult Show(string title, Exception ex, int intervalInMs)
        {
            return Show(null, title, ex.GetDetails(), intervalInMs);
        }

        public static DialogResult Show(Form parent, string title, string message, int intervalInMs)
        {
            var errorBox = new ErrorBox(title, message, intervalInMs)
            {
                parent = parent
            };
            if (intervalInMs != Timeout.Infinite)
            {
                errorBox.UnpinMessage();
            }
            return Show(errorBox);
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

        private void TsmiCopy_Click(object sender, EventArgs e)
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
