namespace Mtf.MessageBoxes
{
	partial class ConfirmBox
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmBox));
			this.p_Main = new System.Windows.Forms.Panel();
			this.rtbMessage = new System.Windows.Forms.RichTextBox();
			this.btnUnpin = new System.Windows.Forms.Button();
			this.btnPin = new System.Windows.Forms.Button();
			this.btn_No = new System.Windows.Forms.Button();
			this.btn_Yes = new System.Windows.Forms.Button();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.tooltip = new System.Windows.Forms.ToolTip(this.components);
			this.closeTimer = new System.Windows.Forms.Timer(this.components);
			this.decrementSecondsLeftTimer = new System.Windows.Forms.Timer(this.components);
			this.p_Main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// p_Main
			// 
			this.p_Main.Controls.Add(this.rtbMessage);
			this.p_Main.Controls.Add(this.btnUnpin);
			this.p_Main.Controls.Add(this.btnPin);
			this.p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.p_Main.Location = new System.Drawing.Point(0, 0);
			this.p_Main.Name = "p_Main";
			this.p_Main.Size = new System.Drawing.Size(403, 107);
			this.p_Main.TabIndex = 0;
			// 
			// rtbMessage
			// 
			this.rtbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.rtbMessage.BackColor = System.Drawing.SystemColors.Control;
			this.rtbMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtbMessage.Location = new System.Drawing.Point(48, 10);
			this.rtbMessage.Name = "rtbMessage";
			this.rtbMessage.ReadOnly = true;
			this.rtbMessage.Size = new System.Drawing.Size(344, 62);
			this.rtbMessage.TabIndex = 0;
			this.rtbMessage.TabStop = false;
			this.rtbMessage.Text = "";
			// 
			// btnUnpin
			// 
			this.btnUnpin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUnpin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnUnpin.Image = ((System.Drawing.Image)(resources.GetObject("btnUnpin.Image")));
			this.btnUnpin.Location = new System.Drawing.Point(371, 78);
			this.btnUnpin.Name = "btnUnpin";
			this.btnUnpin.Size = new System.Drawing.Size(21, 21);
			this.btnUnpin.TabIndex = 1;
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
			this.btnPin.TabIndex = 2;
			this.btnPin.UseVisualStyleBackColor = true;
			this.btnPin.Visible = false;
			this.btnPin.Click += new System.EventHandler(this.BtnPin_Click);
			// 
			// btn_No
			// 
			this.btn_No.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btn_No.DialogResult = System.Windows.Forms.DialogResult.No;
			this.btn_No.Location = new System.Drawing.Point(203, 76);
			this.btn_No.Name = "btn_No";
			this.btn_No.Size = new System.Drawing.Size(75, 23);
			this.btn_No.TabIndex = 2;
			this.btn_No.Text = "No";
			this.btn_No.UseVisualStyleBackColor = true;
			// 
			// btn_Yes
			// 
			this.btn_Yes.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btn_Yes.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.btn_Yes.Location = new System.Drawing.Point(122, 76);
			this.btn_Yes.Name = "btn_Yes";
			this.btn_Yes.Size = new System.Drawing.Size(75, 23);
			this.btn_Yes.TabIndex = 1;
			this.btn_Yes.Text = "Yes";
			this.btn_Yes.UseVisualStyleBackColor = true;
			// 
			// pictureBox1
			// 
			this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox.Location = new System.Drawing.Point(10, 10);
			this.pictureBox.Name = "pictureBox1";
			this.pictureBox.Size = new System.Drawing.Size(32, 32);
			this.pictureBox.TabIndex = 7;
			this.pictureBox.TabStop = false;
			// 
			// closeTimer
			// 
			this.closeTimer.Tick += new System.EventHandler(this.Close_Tick);
			// 
			// decrementSecondsLeftTimer
			// 
			this.decrementSecondsLeftTimer.Enabled = true;
			this.decrementSecondsLeftTimer.Interval = 1000;
			this.decrementSecondsLeftTimer.Tick += new System.EventHandler(this.DecrementSecondsLeft_Tick);
			// 
			// ConfirmBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(403, 107);
			this.Controls.Add(this.btn_No);
			this.Controls.Add(this.btn_Yes);
			this.Controls.Add(this.pictureBox);
			this.Controls.Add(this.p_Main);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MinimumSize = new System.Drawing.Size(411, 131);
			this.Name = "ConfirmBox";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "ConfirmBox";
			this.Shown += new System.EventHandler(this.ConfirmBox_Shown);
			this.p_Main.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel p_Main;
		private System.Windows.Forms.Button btnPin;
		private System.Windows.Forms.Button btnUnpin;
		private System.Windows.Forms.Button btn_No;
		private System.Windows.Forms.Button btn_Yes;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.ToolTip tooltip;
		private System.Windows.Forms.Timer closeTimer;
		private System.Windows.Forms.Timer decrementSecondsLeftTimer;
		private System.Windows.Forms.RichTextBox rtbMessage;
	}
}