using Consts;
using System.Windows.Forms;

namespace MessageBoxes
{
    public partial class BaseBox : Form
    {
        protected Form parent;
        protected int secondsLeft;
        public static readonly string OK = Constants.OK;
        public static readonly string Cancel = Constants.CANCEL;
        public static readonly string Yes = Constants.YES;
        public static readonly string No = Constants.NO;
        public static readonly string EnableAutomaticMessageClosing = Constants.ENABLE_AUTOMATIC_MESSAGE_CLOSING;
        public static readonly string DisableAutomaticMessageClosing = Constants.DISABLE_AUTOMATIC_MESSAGE_CLOSING;
        public static readonly string CopyToClipboard = Constants.COPY_TO_CLIPBOARD;

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
    }
}
