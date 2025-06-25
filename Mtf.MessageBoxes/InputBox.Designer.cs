namespace Mtf.MessageBoxes
{
	partial class InputBox
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
            rtbAnswer = new System.Windows.Forms.RichTextBox();
            rtbQuestion = new System.Windows.Forms.RichTextBox();
            btnUnpin = new System.Windows.Forms.Button();
            btnPin = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            btnOk = new System.Windows.Forms.Button();
            pictureBox = new System.Windows.Forms.PictureBox();
            tooltip = new System.Windows.Forms.ToolTip(components);
            closeTimer = new System.Windows.Forms.Timer(components);
            decrementSecondsLeftTimer = new System.Windows.Forms.Timer(components);
            p_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // p_Main
            // 
            p_Main.Controls.Add(rtbAnswer);
            p_Main.Controls.Add(rtbQuestion);
            p_Main.Controls.Add(btnUnpin);
            p_Main.Controls.Add(btnPin);
            p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            p_Main.Location = new System.Drawing.Point(0, 0);
            p_Main.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            p_Main.Name = "p_Main";
            p_Main.Size = new System.Drawing.Size(470, 123);
            p_Main.TabIndex = 0;
            // 
            // rtbAnswer
            // 
            rtbAnswer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            rtbAnswer.BackColor = System.Drawing.Color.White;
            rtbAnswer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            rtbAnswer.Location = new System.Drawing.Point(56, 51);
            rtbAnswer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rtbAnswer.Name = "rtbAnswer";
            rtbAnswer.Size = new System.Drawing.Size(401, 33);
            rtbAnswer.TabIndex = 3;
            rtbAnswer.TabStop = false;
            rtbAnswer.Text = "";
            // 
            // rtbQuestion
            // 
            rtbQuestion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            rtbQuestion.BackColor = System.Drawing.SystemColors.Control;
            rtbQuestion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            rtbQuestion.Location = new System.Drawing.Point(56, 16);
            rtbQuestion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rtbQuestion.Name = "rtbQuestion";
            rtbQuestion.ReadOnly = true;
            rtbQuestion.Size = new System.Drawing.Size(401, 33);
            rtbQuestion.TabIndex = 0;
            rtbQuestion.TabStop = false;
            rtbQuestion.Text = "";
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
            btnUnpin.TabIndex = 1;
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
            btnPin.TabIndex = 2;
            btnPin.UseVisualStyleBackColor = true;
            btnPin.Visible = false;
            btnPin.Click += BtnPin_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(237, 88);
            btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(88, 27);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnOk.Location = new System.Drawing.Point(142, 88);
            btnOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(88, 27);
            btnOk.TabIndex = 1;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // pictureBox
            // 
            pictureBox.Image = Properties.Resources.question;
            pictureBox.Location = new System.Drawing.Point(12, 12);
            pictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new System.Drawing.Size(37, 37);
            pictureBox.TabIndex = 7;
            pictureBox.TabStop = false;
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
            // InputBox
            // 
            AcceptButton = btnOk; 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(470, 123);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(pictureBox);
            Controls.Add(p_Main);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            MinimumSize = new System.Drawing.Size(477, 145);
            Name = "InputBox";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "InputBox";
            Shown += InputBox_Shown;
            p_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel p_Main;
		private System.Windows.Forms.Button btnPin;
		private System.Windows.Forms.Button btnUnpin;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.ToolTip tooltip;
		private System.Windows.Forms.Timer closeTimer;
		private System.Windows.Forms.Timer decrementSecondsLeftTimer;
		private System.Windows.Forms.RichTextBox rtbQuestion;
        private System.Windows.Forms.RichTextBox rtbAnswer;
    }
}