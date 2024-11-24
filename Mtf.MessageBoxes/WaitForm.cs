using Mtf.MessageBoxes.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mtf.MessageBoxes
{
    public partial class WaitForm : Form
    {
        public WaitForm(string text, int? from = null, int? to = null)
        {
            InitializeComponent();

            if (from.HasValue && to.HasValue)
            {
                progressBar.Style = ProgressBarStyle.Blocks;
                progressBar.Minimum = from.Value;
                progressBar.Maximum = to.Value;
            }

            if (text != null)
            {
                lblPleaseWait.Text = text;
            }
        }

        public static void ExecuteAction(Action action, string text = null)
        {
            var waitForm = new WaitForm(text);
            Task.Run(action).ContinueWith((t) => waitForm.Invoke((Action)(() => waitForm.Close())));
            if (!waitForm.IsDisposed)
            {
                waitForm.ShowDialog();
            }
        }

        public static void ExecuteAction(Action<IProgress<ProgressReport>> action, int from, int to, string text = null)
        {
            var waitForm = new WaitForm(text, from, to);
            var progress = new Progress<ProgressReport>(report =>
            {
                if (waitForm.progressBar.Style != ProgressBarStyle.Marquee && report.Percentage >= waitForm.progressBar.Minimum && report.Percentage <= waitForm.progressBar.Maximum)
                {
                    waitForm.progressBar.Value = report.Percentage;
                }

                if (!String.IsNullOrEmpty(report.StatusMessage))
                {
                    waitForm.lblPleaseWait.Text = ShortenUrl(report.StatusMessage, 60);
                }
            });

            Task.Run(() => action(progress))
                .ContinueWith((t) => waitForm.Invoke((Action)(() => waitForm.Close())));

            if (!waitForm.IsDisposed)
            {
                waitForm.ShowDialog();
            }
        }

        private static string ShortenUrl(string url, int maxLength)
        {
            if (url.Length <= maxLength)
            {
                return url;
            }

            return String.Concat(url.Substring(0, maxLength), "…");
        }
    }
}
