using System;
using System.Windows.Forms;

namespace Mtf.MessageBoxes
{
    public abstract partial class BaseBox : Form
    {
        protected Form parent;
        protected int secondsLeft;
        public static string Abort = Constants.Abort;
        public static string Retry = Constants.Retry;
        public static string OK = Constants.OK;
        public static string Cancel = Constants.Cancel;
        public static string Yes = Constants.Yes;
        public static string No = Constants.No;
        public static string EnableAutomaticMessageClosing = Constants.EnableAutomaticMessageClosing;
        public static string DisableAutomaticMessageClosing = Constants.DisableAutomaticMessageClosing;
        public static string CopyToClipboard = Constants.CopyToClipboard;
        public static string Copy = Constants.Copy;
        public static string PleaseWait  = Constants.PleaseWait;

        protected BaseBox()
        {
            InitializeComponent();
        }

        protected new DialogResult Show()
        {
            return ShowDialog();
        }

        protected new DialogResult Show(IWin32Window owner)
        {
            return ShowDialog(owner);
        }

        protected void BtnPin_Click(object sender, EventArgs e)
        {
            PinMessage();
        }

        protected void BtnUnpin_Click(object sender, EventArgs e)
        {
            UnpinMessage();
        }

        protected void Close_Tick(object sender, EventArgs e)
        {
            AcceptButton?.PerformClick();
        }

        protected abstract void PinMessage();

        protected abstract void UnpinMessage();

        protected static DialogResult Show(BaseBox baseBox)
        {
            if (baseBox.parent != null)
            {
                baseBox.Left = baseBox.parent.Left + (baseBox.parent.Width - baseBox.Width) / 2;
                baseBox.Top = baseBox.parent.Top + (baseBox.parent.Height - baseBox.Height) / 2;
            }
            else
            {
                baseBox.StartPosition = FormStartPosition.CenterScreen;
            }

            return baseBox.ShowDialog();
        }
    }
}
