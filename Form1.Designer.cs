namespace BibleQuiz
{
	partial class Form1
	{
		/// <summary>
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清除任何使用中的資源。
		/// </summary>
		/// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 設計工具產生的程式碼

		/// <summary>
		/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
		/// 修改這個方法的內容。
		/// </summary>
		private void InitializeComponent()
		{
			this.label_question = new System.Windows.Forms.Label();
			this.label_option = new System.Windows.Forms.Label();
			this.nextButton = new System.Windows.Forms.Button();
			this.label_answer = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label_question
			// 
			this.label_question.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label_question.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label_question.Location = new System.Drawing.Point(13, 13);
			this.label_question.Name = "label_question";
			this.label_question.Size = new System.Drawing.Size(504, 124);
			this.label_question.TabIndex = 0;
			this.label_question.Text = "label1";
			this.label_question.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label_option
			// 
			this.label_option.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label_option.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label_option.Location = new System.Drawing.Point(12, 148);
			this.label_option.Name = "label_option";
			this.label_option.Size = new System.Drawing.Size(504, 121);
			this.label_option.TabIndex = 1;
			this.label_option.Text = "label1";
			this.label_option.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nextButton
			// 
			this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.nextButton.AutoSize = true;
			this.nextButton.Location = new System.Drawing.Point(202, 281);
			this.nextButton.Name = "nextButton";
			this.nextButton.Size = new System.Drawing.Size(110, 41);
			this.nextButton.TabIndex = 2;
			this.nextButton.Text = "button1";
			this.nextButton.UseVisualStyleBackColor = true;
			this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
			// 
			// label_answer
			// 
			this.label_answer.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label_answer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label_answer.ForeColor = System.Drawing.Color.Firebrick;
			this.label_answer.Location = new System.Drawing.Point(256, 148);
			this.label_answer.Name = "label_answer";
			this.label_answer.Size = new System.Drawing.Size(260, 121);
			this.label_answer.TabIndex = 3;
			this.label_answer.Text = "答案：";
			this.label_answer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(529, 334);
			this.Controls.Add(this.label_answer);
			this.Controls.Add(this.nextButton);
			this.Controls.Add(this.label_option);
			this.Controls.Add(this.label_question);
			this.Name = "Form1";
			this.Text = "摩範生";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label_question;
		private System.Windows.Forms.Label label_option;
		private System.Windows.Forms.Button nextButton;
		private System.Windows.Forms.Label label_answer;
	}
}

