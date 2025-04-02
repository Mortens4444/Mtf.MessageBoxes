namespace Mtf.MessageBoxes
{
	partial class InfoBox
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
            pb_Information = new System.Windows.Forms.PictureBox();
            btnOk = new System.Windows.Forms.Button();
            decrementSecondsLeftTimer = new System.Windows.Forms.Timer(components);
            closeTimer = new System.Windows.Forms.Timer(components);
            tooltip = new System.Windows.Forms.ToolTip(components);
            p_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_Information).BeginInit();
            SuspendLayout();
            // 
            // p_Main
            // 
            p_Main.Controls.Add(rtbMessage);
            p_Main.Controls.Add(btnUnpin);
            p_Main.Controls.Add(btnPin);
            p_Main.Controls.Add(pb_Information);
            p_Main.Controls.Add(btnOk);
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
            rtbMessage.Text = "";
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
            btnPin.TabIndex = 8;
            btnPin.UseVisualStyleBackColor = true;
            btnPin.Visible = false;
            btnPin.Click += BtnPin_Click;
            // 
            // pb_Information
            // 
            pb_Information.Image = Properties.Resources.information;
            pb_Information.Location = new System.Drawing.Point(12, 12);
            pb_Information.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pb_Information.Name = "pb_Information";
            pb_Information.Size = new System.Drawing.Size(37, 37);
            pb_Information.TabIndex = 7;
            pb_Information.TabStop = false;
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
            // InfoBox
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(470, 123);
            Controls.Add(p_Main);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            MinimumSize = new System.Drawing.Size(477, 145);
            Name = "InfoBox";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "InfoBox";
            Shown += InfoBox_Shown;
            p_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb_Information).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_Main;
		private System.Windows.Forms.Button btnUnpin;
		private System.Windows.Forms.Button btnPin;
		private System.Windows.Forms.PictureBox pb_Information;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Timer decrementSecondsLeftTimer;
		private System.Windows.Forms.Timer closeTimer;
		private System.Windows.Forms.ToolTip tooltip;
		private System.Windows.Forms.RichTextBox rtbMessage;
	}
}