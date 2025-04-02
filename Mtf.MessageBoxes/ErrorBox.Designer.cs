namespace Mtf.MessageBoxes
{
	sealed partial class ErrorBox
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

        #region Windows Form Designer generated code


        /* Unmerged change from project 'Mtf.MessageBoxes (net8.0-windows)'
        Before:
                    this.cms_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
                    this.tsmi_Copy = new System.Windows.Forms.ToolStripMenuItem();
        After:
                    this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
                    this.tsmi_Copy = new System.Windows.Forms.ToolStripMenuItem();
        */

        /* Unmerged change from project 'Mtf.MessageBoxes (net8.0-windows)'
        Before:
                    this.cms_Menu.SuspendLayout();
                    ((System.ComponentModel.ISupportInitialize)(this.pb_Error)).BeginInit();
        After:
                    this.cmsMenu.SuspendLayout();
                    ((System.ComponentModel.ISupportInitialize)(this.pb_Error)).BeginInit();
        */

        /* Unmerged change from project 'Mtf.MessageBoxes (net8.0-windows)'
        Before:
                    this.rtbMessage.ContextMenuStrip = this.cms_Menu;
                    this.rtbMessage.Location = new System.Drawing.Point(48, 10);
        After:
                    this.rtbMessage.ContextMenuStrip = this.cmsMenu;
                    this.rtbMessage.Location = new System.Drawing.Point(48, 10);
        */

        /* Unmerged change from project 'Mtf.MessageBoxes (net8.0-windows)'
        Before:
                    this.cms_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                    this.tsmi_Copy});
                    this.cms_Menu.Name = "contextMenuStrip1";
                    this.cms_Menu.Size = new System.Drawing.Size(100, 26);
                    // 
        After:
                    this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                    this.tsmi_Copy});
                    this.cmsMenu.Name = "contextMenuStrip1";
                    this.cmsMenu.Size = new System.Drawing.Size(100, 26);
                    // 
        */

        /* Unmerged change from project 'Mtf.MessageBoxes (net8.0-windows)'
        Before:
                    this.cms_Menu.ResumeLayout(false);
                    ((System.ComponentModel.ISupportInitialize)(this.pb_Error)).EndInit();
        After:
                    this.cmsMenu.ResumeLayout(false);
                    ((System.ComponentModel.ISupportInitialize)(this.pb_Error)).EndInit();
        */
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            p_Main = new System.Windows.Forms.Panel();
            btn_SendToClipboard = new System.Windows.Forms.Button();
            rtbMessage = new System.Windows.Forms.RichTextBox();
            cmsMenu = new System.Windows.Forms.ContextMenuStrip(components);
            tsmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            btnUnpin = new System.Windows.Forms.Button();
            btnPin = new System.Windows.Forms.Button();
            pb_Error = new System.Windows.Forms.PictureBox();
            btnOk = new System.Windows.Forms.Button();
            decrementSecondsLeftTimer = new System.Windows.Forms.Timer(components);
            closeTimer = new System.Windows.Forms.Timer(components);
            tooltip = new System.Windows.Forms.ToolTip(components);
            tooltipTwo = new System.Windows.Forms.ToolTip(components);
            p_Main.SuspendLayout();
            cmsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_Error).BeginInit();
            SuspendLayout();
            // 
            // p_Main
            // 
            p_Main.Controls.Add(btn_SendToClipboard);
            p_Main.Controls.Add(rtbMessage);
            p_Main.Controls.Add(btnUnpin);
            p_Main.Controls.Add(btnPin);
            p_Main.Controls.Add(pb_Error);
            p_Main.Controls.Add(btnOk);
            p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            p_Main.Location = new System.Drawing.Point(0, 0);
            p_Main.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            p_Main.Name = "p_Main";
            p_Main.Size = new System.Drawing.Size(470, 123);
            p_Main.TabIndex = 0;
            // 
            // btn_SendToClipboard
            // 
            btn_SendToClipboard.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_SendToClipboard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btn_SendToClipboard.Image = Properties.Resources.clipboard;
            btn_SendToClipboard.Location = new System.Drawing.Point(401, 90);
            btn_SendToClipboard.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_SendToClipboard.Name = "btn_SendToClipboard";
            btn_SendToClipboard.Size = new System.Drawing.Size(24, 24);
            btn_SendToClipboard.TabIndex = 11;
            btn_SendToClipboard.UseVisualStyleBackColor = true;
            btn_SendToClipboard.Click += Btn_SendToClipboard_Click;
            // 
            // rtbMessage
            // 
            rtbMessage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            rtbMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            rtbMessage.ContextMenuStrip = cmsMenu;
            rtbMessage.Location = new System.Drawing.Point(56, 12);
            rtbMessage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rtbMessage.Name = "rtbMessage";
            rtbMessage.ReadOnly = true;
            rtbMessage.Size = new System.Drawing.Size(401, 72);
            rtbMessage.TabIndex = 9;
            rtbMessage.Text = "";
            // 
            // cmsMenu
            // 
            cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiCopy });
            cmsMenu.Name = "contextMenuStrip1";
            cmsMenu.Size = new System.Drawing.Size(103, 26);
            // 
            // tsmiCopy
            // 
            tsmiCopy.Name = "tsmiCopy";
            tsmiCopy.Size = new System.Drawing.Size(102, 22);
            tsmiCopy.Text = "Copy";
            tsmiCopy.Click += Tsmi_Copy_Click;
            // 
            // btnUnpin
            // 
            btnUnpin.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnUnpin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnUnpin.Image = Properties.Resources.unpin;
            btnUnpin.Location = new System.Drawing.Point(433, 90);
            btnUnpin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnUnpin.Name = "btnUnpin";
            btnUnpin.Size = new System.Drawing.Size(24, 24);
            btnUnpin.TabIndex = 2;
            btnUnpin.UseVisualStyleBackColor = true;
            btnUnpin.Visible = false;
            btnUnpin.Click += BtnUnpin_Click;
            // 
            // btnPin
            // 
            btnPin.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnPin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnPin.Image = Properties.Resources.pin;
            btnPin.Location = new System.Drawing.Point(433, 90);
            btnPin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnPin.Name = "btnPin";
            btnPin.Size = new System.Drawing.Size(24, 24);
            btnPin.TabIndex = 3;
            btnPin.UseVisualStyleBackColor = true;
            btnPin.Visible = false;
            btnPin.Click += BtnPin_Click;
            // 
            // pb_Error
            // 
            pb_Error.Image = Properties.Resources.error;
            pb_Error.Location = new System.Drawing.Point(12, 12);
            pb_Error.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pb_Error.Name = "pb_Error";
            pb_Error.Size = new System.Drawing.Size(37, 37);
            pb_Error.TabIndex = 8;
            pb_Error.TabStop = false;
            // 
            // btnOk
            // 
            btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnOk.Location = new System.Drawing.Point(192, 88);
            btnOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(88, 27);
            btnOk.TabIndex = 1;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // decrementSecondsLeftTimer
            // 
            decrementSecondsLeftTimer.Enabled = true;
            decrementSecondsLeftTimer.Interval = 1000;
            decrementSecondsLeftTimer.Tick += DecrementSecondsLeft_Tick;
            // 
            // closeTimer
            // 
            closeTimer.Tick += Close_Tick;
            // 
            // ErrorBox
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(470, 123);
            Controls.Add(p_Main);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            MinimumSize = new System.Drawing.Size(477, 145);
            Name = "ErrorBox";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "Title";
            Load += ErrorBox_Load;
            Shown += ErrorBox_Shown;
            p_Main.ResumeLayout(false);
            cmsMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb_Error).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel p_Main;
		private System.Windows.Forms.Button btnUnpin;
		private System.Windows.Forms.Button btnPin;
		private System.Windows.Forms.PictureBox pb_Error;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Timer decrementSecondsLeftTimer;
		private System.Windows.Forms.Timer closeTimer;
		private System.Windows.Forms.ToolTip tooltip;
		private System.Windows.Forms.RichTextBox rtbMessage;
		private System.Windows.Forms.ContextMenuStrip cmsMenu;
		private System.Windows.Forms.ToolStripMenuItem tsmiCopy;
		private System.Windows.Forms.Button btn_SendToClipboard;
		private System.Windows.Forms.ToolTip tooltipTwo;
	}
}