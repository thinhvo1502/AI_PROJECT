namespace AI_PROJECT.UI
{
    partial class QuestionForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategories = new System.Windows.Forms.ComboBox();
            this.lblQuestionText = new System.Windows.Forms.Label();
            this.txtQuestionText = new System.Windows.Forms.TextBox();
            this.lblCorrectAnswer = new System.Windows.Forms.Label();
            this.txtCorrectAnswer = new System.Windows.Forms.TextBox();
            this.lblWrongAnswer1 = new System.Windows.Forms.Label();
            this.txtWrongAnswer1 = new System.Windows.Forms.TextBox();
            this.lblWrongAnswer2 = new System.Windows.Forms.Label();
            this.txtWrongAnswer2 = new System.Windows.Forms.TextBox();
            this.lblWrongAnswer3 = new System.Windows.Forms.Label();
            this.txtWrongAnswer3 = new System.Windows.Forms.TextBox();
            this.btnAddQuestion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = FormStyling.HeaderFont;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(170, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Manage Questions";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(20, 70);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(65, 17);
            this.lblCategory.TabIndex = 1;
            this.lblCategory.Text = "Category:";
            // 
            // cmbCategories
            // 
            this.cmbCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategories.FormattingEnabled = true;
            this.cmbCategories.Location = new System.Drawing.Point(140, 67);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Size = new System.Drawing.Size(200, 25);
            this.cmbCategories.TabIndex = 2;
            // 
            // lblQuestionText
            // 
            this.lblQuestionText.AutoSize = true;
            this.lblQuestionText.Location = new System.Drawing.Point(20, 110);
            this.lblQuestionText.Name = "lblQuestionText";
            this.lblQuestionText.Size = new System.Drawing.Size(93, 17);
            this.lblQuestionText.TabIndex = 3;
            this.lblQuestionText.Text = "Question Text:";
            // 
            // txtQuestionText
            // 
            this.txtQuestionText.Location = new System.Drawing.Point(20, 130);
            this.txtQuestionText.Multiline = true;
            this.txtQuestionText.Name = "txtQuestionText";
            this.txtQuestionText.Size = new System.Drawing.Size(320, 60);
            this.txtQuestionText.TabIndex = 4;
            // 
            // lblCorrectAnswer
            // 
            this.lblCorrectAnswer.AutoSize = true;
            this.lblCorrectAnswer.Location = new System.Drawing.Point(20, 200);
            this.lblCorrectAnswer.Name = "lblCorrectAnswer";
            this.lblCorrectAnswer.Size = new System.Drawing.Size(102, 17);
            this.lblCorrectAnswer.TabIndex = 5;
            this.lblCorrectAnswer.Text = "Correct Answer:";
            // 
            // txtCorrectAnswer
            // 
            this.txtCorrectAnswer.Location = new System.Drawing.Point(140, 197);
            this.txtCorrectAnswer.Name = "txtCorrectAnswer";
            this.txtCorrectAnswer.Size = new System.Drawing.Size(200, 25);
            this.txtCorrectAnswer.TabIndex = 6;
            // 
            // lblWrongAnswer1
            // 
            this.lblWrongAnswer1.AutoSize = true;
            this.lblWrongAnswer1.Location = new System.Drawing.Point(20, 230);
            this.lblWrongAnswer1.Name = "lblWrongAnswer1";
            this.lblWrongAnswer1.Size = new System.Drawing.Size(110, 17);
            this.lblWrongAnswer1.TabIndex = 7;
            this.lblWrongAnswer1.Text = "Wrong Answer 1:";
            // 
            // txtWrongAnswer1
            // 
            this.txtWrongAnswer1.Location = new System.Drawing.Point(140, 227);
            this.txtWrongAnswer1.Name = "txtWrongAnswer1";
            this.txtWrongAnswer1.Size = new System.Drawing.Size(200, 25);
            this.txtWrongAnswer1.TabIndex = 8;
            // 
            // lblWrongAnswer2
            // 
            this.lblWrongAnswer2.AutoSize = true;
            this.lblWrongAnswer2.Location = new System.Drawing.Point(20, 260);
            this.lblWrongAnswer2.Name = "lblWrongAnswer2";
            this.lblWrongAnswer2.Size = new System.Drawing.Size(110, 17);
            this.lblWrongAnswer2.TabIndex = 9;
            this.lblWrongAnswer2.Text = "Wrong Answer 2:";
            // 
            // txtWrongAnswer2
            // 
            this.txtWrongAnswer2.Location = new System.Drawing.Point(140, 257);
            this.txtWrongAnswer2.Name = "txtWrongAnswer2";
            this.txtWrongAnswer2.Size = new System.Drawing.Size(200, 25);
            this.txtWrongAnswer2.TabIndex = 10;
            // 
            // lblWrongAnswer3
            // 
            this.lblWrongAnswer3.AutoSize = true;
            this.lblWrongAnswer3.Location = new System.Drawing.Point(20, 290);
            this.lblWrongAnswer3.Name = "lblWrongAnswer3";
            this.lblWrongAnswer3.Size = new System.Drawing.Size(110, 17);
            this.lblWrongAnswer3.TabIndex = 11;
            this.lblWrongAnswer3.Text = "Wrong Answer 3:";
            // 
            // txtWrongAnswer3
            // 
            this.txtWrongAnswer3.Location = new System.Drawing.Point(140, 287);
            this.txtWrongAnswer3.Name = "txtWrongAnswer3";
            this.txtWrongAnswer3.Size = new System.Drawing.Size(200, 25);
            this.txtWrongAnswer3.TabIndex = 12;
            // 
            // btnAddQuestion
            // 
            this.btnAddQuestion.Location = new System.Drawing.Point(140, 330);
            this.btnAddQuestion.Name = "btnAddQuestion";
            this.btnAddQuestion.Size = new System.Drawing.Size(120, 35);
            this.btnAddQuestion.TabIndex = 13;
            this.btnAddQuestion.Text = "Add Question";
            this.btnAddQuestion.UseVisualStyleBackColor = true;
            this.btnAddQuestion.Click += new System.EventHandler(this.btnAddQuestion_Click);
            // 
            // QuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 390);
            this.Controls.Add(this.btnAddQuestion);
            this.Controls.Add(this.txtWrongAnswer3);
            this.Controls.Add(this.lblWrongAnswer3);
            this.Controls.Add(this.txtWrongAnswer2);
            this.Controls.Add(this.lblWrongAnswer2);
            this.Controls.Add(this.txtWrongAnswer1);
            this.Controls.Add(this.lblWrongAnswer1);
            this.Controls.Add(this.txtCorrectAnswer);
            this.Controls.Add(this.lblCorrectAnswer);
            this.Controls.Add(this.txtQuestionText);
            this.Controls.Add(this.lblQuestionText);
            this.Controls.Add(this.cmbCategories);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblTitle);
            this.Font = FormStyling.NormalFont;
            this.Name = "QuestionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Questions";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategories;
        private System.Windows.Forms.Label lblQuestionText;
        private System.Windows.Forms.TextBox txtQuestionText;
        private System.Windows.Forms.Label lblCorrectAnswer;
        private System.Windows.Forms.TextBox txtCorrectAnswer;
        private System.Windows.Forms.Label lblWrongAnswer1;
        private System.Windows.Forms.TextBox txtWrongAnswer1;
        private System.Windows.Forms.Label lblWrongAnswer2;
        private System.Windows.Forms.TextBox txtWrongAnswer2;
        private System.Windows.Forms.Label lblWrongAnswer3;
        private System.Windows.Forms.TextBox txtWrongAnswer3;
        private System.Windows.Forms.Button btnAddQuestion;
    }

        #endregion
    }