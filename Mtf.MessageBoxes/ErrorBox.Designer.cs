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

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorBox));
			this.p_Main = new System.Windows.Forms.Panel();
			this.btn_SendToClipboard = new System.Windows.Forms.Button();
			this.rtbMessage = new System.Windows.Forms.RichTextBox();
			this.cms_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmi_Copy = new System.Windows.Forms.ToolStripMenuItem();
			this.btnUnpin = new System.Windows.Forms.Button();
			this.btnPin = new System.Windows.Forms.Button();
			this.pb_Error = new System.Windows.Forms.PictureBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.decrementSecondsLeftTimer = new System.Windows.Forms.Timer(this.components);
			this.closeTimer = new System.Windows.Forms.Timer(this.components);
			this.tooltip = new System.Windows.Forms.ToolTip(this.components);
			this.tooltipTwo = new System.Windows.Forms.ToolTip(this.components);
			this.p_Main.SuspendLayout();
			this.cms_Menu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb_Error)).BeginInit();
			this.SuspendLayout();
			// 
			// p_Main
			// 
			this.p_Main.Controls.Add(this.btn_SendToClipboard);
			this.p_Main.Controls.Add(this.rtbMessage);
			this.p_Main.Controls.Add(this.btnUnpin);
			this.p_Main.Controls.Add(this.btnPin);
			this.p_Main.Controls.Add(this.pb_Error);
			this.p_Main.Controls.Add(this.btnOk);
			this.p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.p_Main.Location = new System.Drawing.Point(0, 0);
			this.p_Main.Name = "p_Main";
			this.p_Main.Size = new System.Drawing.Size(403, 107);
			this.p_Main.TabIndex = 0;
			// 
			// btn_SendToClipboard
			// 
			this.btn_SendToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_SendToClipboard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btn_SendToClipboard.Image = ((System.Drawing.Image)(resources.GetObject("btn_SendToClipboard.Image")));
			this.btn_SendToClipboard.Location = new System.Drawing.Point(344, 78);
			this.btn_SendToClipboard.Name = "btn_SendToClipboard";
			this.btn_SendToClipboard.Size = new System.Drawing.Size(21, 21);
			this.btn_SendToClipboard.TabIndex = 11;
			this.btn_SendToClipboard.UseVisualStyleBackColor = true;
			this.btn_SendToClipboard.Click += new System.EventHandler(this.Btn_SendToClipboard_Click);
			// 
			// rtbMessage
			// 
			this.rtbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.rtbMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtbMessage.ContextMenuStrip = this.cms_Menu;
			this.rtbMessage.Location = new System.Drawing.Point(48, 10);
			this.rtbMessage.Name = "rtbMessage";
			this.rtbMessage.ReadOnly = true;
			this.rtbMessage.Size = new System.Drawing.Size(344, 62);
			this.rtbMessage.TabIndex = 9;
			this.rtbMessage.Text = "";
			// 
			// cms_Menu
			// 
			this.cms_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Copy});
			this.cms_Menu.Name = "contextMenuStrip1";
			this.cms_Menu.Size = new System.Drawing.Size(100, 26);
			// 
			// tsmi_Copy
			// 
			this.tsmi_Copy.Image = global::Mtf.MessageBoxes.Resource.copy;
			this.tsmi_Copy.Name = "tsmi_Copy";
			this.tsmi_Copy.Size = new System.Drawing.Size(99, 22);
			this.tsmi_Copy.Text = "Copy";
			this.tsmi_Copy.Click += new System.EventHandler(this.Tsmi_Copy_Click);
			// 
			// btnUnpin
			// 
			this.btnUnpin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUnpin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnUnpin.Image = ((System.Drawing.Image)(resources.GetObject("btnUnpin.Image")));
			this.btnUnpin.Location = new System.Drawing.Point(371, 78);
			this.btnUnpin.Name = "btnUnpin";
			this.btnUnpin.Size = new System.Drawing.Size(21, 21);
			this.btnUnpin.TabIndex = 2;
			this.btnUnpin.UseVisualStyleBackColor = true;
			this.btnUnpin.Visible = false;
			this.btnUnpin.Click += new System.EventHandler(this.BtnUnpin_Click);
			// 
			// btnPin
			// 
			this.btnPin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnPin.Image = ((System.Drawing.Image)(resources.GetObject("btnPin.Image")));
			this.btnPin.Location = new System.Drawing.Point(371, 78);
			this.btnPin.Name = "btnPin";
			this.btnPin.Size = new System.Drawing.Size(21, 21);
			this.btnPin.TabIndex = 3;
			this.btnPin.UseVisualStyleBackColor = true;
			this.btnPin.Visible = false;
			this.btnPin.Click += new System.EventHandler(this.BtnPin_Click);
			// 
			// pb_Error
			// 
			this.pb_Error.Image = ((System.Drawing.Image)(resources.GetObject("pb_Error.Image")));
			this.pb_Error.Location = new System.Drawing.Point(10, 10);
			this.pb_Error.Name = "pb_Error";
			this.pb_Error.Size = new System.Drawing.Size(32, 32);
			this.pb_Error.TabIndex = 8;
			this.pb_Error.TabStop = false;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(165, 76);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			// 
			// decrementSecondsLeftTimer
			// 
			this.decrementSecondsLeftTimer.Enabled = true;
			this.decrementSecondsLeftTimer.Interval = 1000;
			this.decrementSecondsLeftTimer.Tick += new System.EventHandler(this.DecrementSecondsLeft_Tick);
			// 
			// closeTimer
			// 
			this.closeTimer.Tick += new System.EventHandler(this.Close_Tick);
			// 
			// ErrorBox
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(403, 107);
			this.Controls.Add(this.p_Main);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MinimumSize = new System.Drawing.Size(411, 131);
			this.Name = "ErrorBox";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Title";
			this.Load += new System.EventHandler(this.ErrorBox_Load);
			this.Shown += new System.EventHandler(this.ErrorBox_Shown);
			this.p_Main.ResumeLayout(false);
			this.cms_Menu.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pb_Error)).EndInit();
			this.ResumeLayout(false);

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
		private System.Windows.Forms.ContextMenuStrip cms_Menu;
		private System.Windows.Forms.ToolStripMenuItem tsmi_Copy;
		private System.Windows.Forms.Button btn_SendToClipboard;
		private System.Windows.Forms.ToolTip tooltipTwo;
	}
}