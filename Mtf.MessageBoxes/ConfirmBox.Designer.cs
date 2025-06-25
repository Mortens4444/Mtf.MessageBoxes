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
			components = new System.ComponentModel.Container();
			p_Main = new System.Windows.Forms.Panel();
			rtbMessage = new System.Windows.Forms.RichTextBox();
			btnUnpin = new System.Windows.Forms.Button();
			btnPin = new System.Windows.Forms.Button();
			btnNo = new System.Windows.Forms.Button();
			btnYes = new System.Windows.Forms.Button();
			pbConfirm = new System.Windows.Forms.PictureBox();
			tooltip = new System.Windows.Forms.ToolTip(components);
			closeTimer = new System.Windows.Forms.Timer(components);
			decrementSecondsLeftTimer = new System.Windows.Forms.Timer(components);
			p_Main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pbConfirm).BeginInit();
			SuspendLayout();
			// 
			// p_Main
			// 
			p_Main.Controls.Add(rtbMessage);
			p_Main.Controls.Add(btnUnpin);
			p_Main.Controls.Add(btnPin);
			p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
			p_Main.Location = new System.Drawing.Point(0, 0);
			p_Main.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			p_Main.Name = "p_Main";
			p_Main.Size = new System.Drawing.Size(470, 123);
			p_Main.TabIndex = 0;
			// 
			// rtbMessage
			// 
			rtbMessage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			rtbMessage.BackColor = System.Drawing.SystemColors.Control;
			rtbMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
			rtbMessage.Location = new System.Drawing.Point(56, 12);
			rtbMessage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			rtbMessage.Name = "rtbMessage";
			rtbMessage.ReadOnly = true;
			rtbMessage.Size = new System.Drawing.Size(401, 72);
			rtbMessage.TabIndex = 0;
			rtbMessage.TabStop = false;
			rtbMessage.Text = "";
			// 
			// btnUnpin
			// 
			btnUnpin.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			btnUnpin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			btnUnpin.Location = new System.Drawing.Point(433, 90);
			btnUnpin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			btnUnpin.Name = "btnUnpin";
			btnUnpin.Size = new System.Drawing.Size(24, 24);
			btnUnpin.TabIndex = 1;
			btnUnpin.UseVisualStyleBackColor = true;
			btnUnpin.Visible = false;
			btnUnpin.Click += BtnUnpin_Click;
			// 
			// btnPin
			// 
			btnPin.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			btnPin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			btnPin.Location = new System.Drawing.Point(433, 90);
			btnPin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			btnPin.Name = "btnPin";
			btnPin.Size = new System.Drawing.Size(24, 24);
			btnPin.TabIndex = 2;
			btnPin.UseVisualStyleBackColor = true;
			btnPin.Visible = false;
			btnPin.Click += BtnPin_Click;
			// 
			// btn_No
			// 
			btnNo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
			btnNo.Location = new System.Drawing.Point(237, 88);
			btnNo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			btnNo.Name = "btn_No";
			btnNo.Size = new System.Drawing.Size(88, 27);
			btnNo.TabIndex = 2;
			btnNo.Text = "No";
			btnNo.UseVisualStyleBackColor = true;
			// 
			// btn_Yes
			// 
			btnYes.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
			btnYes.Location = new System.Drawing.Point(142, 88);
			btnYes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			btnYes.Name = "btn_Yes";
			btnYes.Size = new System.Drawing.Size(88, 27);
			btnYes.TabIndex = 1;
			btnYes.Text = "Yes";
			btnYes.UseVisualStyleBackColor = true;
			// 
			// pbConfirm
			// 
			pbConfirm.Location = new System.Drawing.Point(12, 12);
			pbConfirm.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			pbConfirm.Name = "pbConfirmBox";
			pbConfirm.Size = new System.Drawing.Size(37, 37);
			pbConfirm.TabIndex = 7;
			pbConfirm.TabStop = false;
			// 
			// closeTimer
			// 
			closeTimer.Tick += Close_Tick;
			// 
			// decrementSecondsLeftTimer
			// 
			decrementSecondsLeftTimer.Enabled = true;
			decrementSecondsLeftTimer.Interval = 1000;
			decrementSecondsLeftTimer.Tick += DecrementSecondsLeft_Tick;
			// 
			// ConfirmBox
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(470, 123);
			Controls.Add(btnNo);
			Controls.Add(btnYes);
			Controls.Add(pbConfirm);
			Controls.Add(p_Main);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
			MinimumSize = new System.Drawing.Size(477, 145);
			Name = "ConfirmBox";
			ShowIcon = false;
			ShowInTaskbar = false;
			Text = "ConfirmBox";
			Shown += ConfirmBox_Shown;
			p_Main.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pbConfirm).EndInit();
			ResumeLayout(false);
		}

        #endregion

        private System.Windows.Forms.Panel p_Main;
		private System.Windows.Forms.Button btnPin;
		private System.Windows.Forms.Button btnUnpin;
		private System.Windows.Forms.Button btnNo;
		private System.Windows.Forms.Button btnYes;
		private System.Windows.Forms.PictureBox pbConfirm;
		private System.Windows.Forms.ToolTip tooltip;
		private System.Windows.Forms.Timer closeTimer;
		private System.Windows.Forms.Timer decrementSecondsLeftTimer;
		private System.Windows.Forms.RichTextBox rtbMessage;
	}
}