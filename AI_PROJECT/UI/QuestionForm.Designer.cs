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
            this.dgvQuestions = new System.Windows.Forms.DataGridView();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnEditQuestion = new System.Windows.Forms.Button();
            this.btnDeleteQuestion = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlQuestionDetails = new System.Windows.Forms.Panel();
            this.pnlQuestionList = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestions)).BeginInit();
            this.pnlQuestionDetails.SuspendLayout();
            this.pnlQuestionList.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(220, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Manage Questions";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(20, 20);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(65, 17);
            this.lblCategory.TabIndex = 1;
            this.lblCategory.Text = "Category:";
            // 
            // cmbCategories
            // 
            this.cmbCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategories.FormattingEnabled = true;
            this.cmbCategories.Location = new System.Drawing.Point(140, 17);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Size = new System.Drawing.Size(200, 25);
            this.cmbCategories.TabIndex = 2;
            // 
            // lblQuestionText
            // 
            this.lblQuestionText.AutoSize = true;
            this.lblQuestionText.Location = new System.Drawing.Point(20, 60);
            this.lblQuestionText.Name = "lblQuestionText";
            this.lblQuestionText.Size = new System.Drawing.Size(93, 17);
            this.lblQuestionText.TabIndex = 3;
            this.lblQuestionText.Text = "Question Text:";
            // 
            // txtQuestionText
            // 
            this.txtQuestionText.Location = new System.Drawing.Point(20, 80);
            this.txtQuestionText.Multiline = true;
            this.txtQuestionText.Name = "txtQuestionText";
            this.txtQuestionText.Size = new System.Drawing.Size(320, 60);
            this.txtQuestionText.TabIndex = 4;
            // 
            // lblCorrectAnswer
            // 
            this.lblCorrectAnswer.AutoSize = true;
            this.lblCorrectAnswer.Location = new System.Drawing.Point(20, 150);
            this.lblCorrectAnswer.Name = "lblCorrectAnswer";
            this.lblCorrectAnswer.Size = new System.Drawing.Size(102, 17);
            this.lblCorrectAnswer.TabIndex = 5;
            this.lblCorrectAnswer.Text = "Correct Answer:";
            // 
            // txtCorrectAnswer
            // 
            this.txtCorrectAnswer.Location = new System.Drawing.Point(140, 147);
            this.txtCorrectAnswer.Name = "txtCorrectAnswer";
            this.txtCorrectAnswer.Size = new System.Drawing.Size(200, 25);
            this.txtCorrectAnswer.TabIndex = 6;
            // 
            // lblWrongAnswer1
            // 
            this.lblWrongAnswer1.AutoSize = true;
            this.lblWrongAnswer1.Location = new System.Drawing.Point(20, 180);
            this.lblWrongAnswer1.Name = "lblWrongAnswer1";
            this.lblWrongAnswer1.Size = new System.Drawing.Size(110, 17);
            this.lblWrongAnswer1.TabIndex = 7;
            this.lblWrongAnswer1.Text = "Wrong Answer 1:";
            // 
            // txtWrongAnswer1
            // 
            this.txtWrongAnswer1.Location = new System.Drawing.Point(140, 177);
            this.txtWrongAnswer1.Name = "txtWrongAnswer1";
            this.txtWrongAnswer1.Size = new System.Drawing.Size(200, 25);
            this.txtWrongAnswer1.TabIndex = 8;
            // 
            // lblWrongAnswer2
            // 
            this.lblWrongAnswer2.AutoSize = true;
            this.lblWrongAnswer2.Location = new System.Drawing.Point(20, 210);
            this.lblWrongAnswer2.Name = "lblWrongAnswer2";
            this.lblWrongAnswer2.Size = new System.Drawing.Size(110, 17);
            this.lblWrongAnswer2.TabIndex = 9;
            this.lblWrongAnswer2.Text = "Wrong Answer 2:";
            // 
            // txtWrongAnswer2
            // 
            this.txtWrongAnswer2.Location = new System.Drawing.Point(140, 207);
            this.txtWrongAnswer2.Name = "txtWrongAnswer2";
            this.txtWrongAnswer2.Size = new System.Drawing.Size(200, 25);
            this.txtWrongAnswer2.TabIndex = 10;
            // 
            // lblWrongAnswer3
            // 
            this.lblWrongAnswer3.AutoSize = true;
            this.lblWrongAnswer3.Location = new System.Drawing.Point(20, 240);
            this.lblWrongAnswer3.Name = "lblWrongAnswer3";
            this.lblWrongAnswer3.Size = new System.Drawing.Size(110, 17);
            this.lblWrongAnswer3.TabIndex = 11;
            this.lblWrongAnswer3.Text = "Wrong Answer 3:";
            // 
            // txtWrongAnswer3
            // 
            this.txtWrongAnswer3.Location = new System.Drawing.Point(140, 237);
            this.txtWrongAnswer3.Name = "txtWrongAnswer3";
            this.txtWrongAnswer3.Size = new System.Drawing.Size(200, 25);
            this.txtWrongAnswer3.TabIndex = 12;
            // 
            // btnAddQuestion
            // 
            this.btnAddQuestion.Location = new System.Drawing.Point(140, 280);
            this.btnAddQuestion.Name = "btnAddQuestion";
            this.btnAddQuestion.Size = new System.Drawing.Size(120, 35);
            this.btnAddQuestion.TabIndex = 13;
            this.btnAddQuestion.Text = "Add Question";
            this.btnAddQuestion.UseVisualStyleBackColor = true;
            this.btnAddQuestion.Click += new System.EventHandler(this.btnAddQuestion_Click);
            // 
            // dgvQuestions
            // 
            this.dgvQuestions.AllowUserToAddRows = false;
            this.dgvQuestions.AllowUserToDeleteRows = false;
            this.dgvQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuestions.Location = new System.Drawing.Point(20, 20);
            this.dgvQuestions.Name = "dgvQuestions";
            this.dgvQuestions.ReadOnly = true;
            this.dgvQuestions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuestions.Size = new System.Drawing.Size(320, 200);
            this.dgvQuestions.TabIndex = 14;
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.Location = new System.Drawing.Point(20, 230);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(100, 35);
            this.btnViewDetails.TabIndex = 15;
            this.btnViewDetails.Text = "View Details";
            this.btnViewDetails.UseVisualStyleBackColor = true;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // btnEditQuestion
            // 
            this.btnEditQuestion.Location = new System.Drawing.Point(130, 230);
            this.btnEditQuestion.Name = "btnEditQuestion";
            this.btnEditQuestion.Size = new System.Drawing.Size(100, 35);
            this.btnEditQuestion.TabIndex = 16;
            this.btnEditQuestion.Text = "Edit";
            this.btnEditQuestion.UseVisualStyleBackColor = true;
            this.btnEditQuestion.Click += new System.EventHandler(this.btnEditQuestion_Click);
            // 
            // btnDeleteQuestion
            // 
            this.btnDeleteQuestion.Location = new System.Drawing.Point(240, 230);
            this.btnDeleteQuestion.Name = "btnDeleteQuestion";
            this.btnDeleteQuestion.Size = new System.Drawing.Size(100, 35);
            this.btnDeleteQuestion.TabIndex = 17;
            this.btnDeleteQuestion.Text = "Delete";
            this.btnDeleteQuestion.UseVisualStyleBackColor = true;
            this.btnDeleteQuestion.Click += new System.EventHandler(this.btnDeleteQuestion_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(20, 280);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlQuestionDetails
            // 
            this.pnlQuestionDetails.BackColor = System.Drawing.Color.White;
            this.pnlQuestionDetails.Controls.Add(this.lblCategory);
            this.pnlQuestionDetails.Controls.Add(this.cmbCategories);
            this.pnlQuestionDetails.Controls.Add(this.lblQuestionText);
            this.pnlQuestionDetails.Controls.Add(this.txtQuestionText);
            this.pnlQuestionDetails.Controls.Add(this.lblCorrectAnswer);
            this.pnlQuestionDetails.Controls.Add(this.txtCorrectAnswer);
            this.pnlQuestionDetails.Controls.Add(this.lblWrongAnswer1);
            this.pnlQuestionDetails.Controls.Add(this.txtWrongAnswer1);
            this.pnlQuestionDetails.Controls.Add(this.lblWrongAnswer2);
            this.pnlQuestionDetails.Controls.Add(this.txtWrongAnswer2);
            this.pnlQuestionDetails.Controls.Add(this.lblWrongAnswer3);
            this.pnlQuestionDetails.Controls.Add(this.txtWrongAnswer3);
            this.pnlQuestionDetails.Controls.Add(this.btnAddQuestion);
            this.pnlQuestionDetails.Controls.Add(this.btnCancel);
            this.pnlQuestionDetails.Location = new System.Drawing.Point(20, 70);
            this.pnlQuestionDetails.Name = "pnlQuestionDetails";
            this.pnlQuestionDetails.Size = new System.Drawing.Size(360, 330);
            this.pnlQuestionDetails.TabIndex = 19;
            // 
            // pnlQuestionList
            // 
            this.pnlQuestionList.BackColor = System.Drawing.Color.White;
            this.pnlQuestionList.Controls.Add(this.dgvQuestions);
            this.pnlQuestionList.Controls.Add(this.btnViewDetails);
            this.pnlQuestionList.Controls.Add(this.btnEditQuestion);
            this.pnlQuestionList.Controls.Add(this.btnDeleteQuestion);
            this.pnlQuestionList.Location = new System.Drawing.Point(400, 70);
            this.pnlQuestionList.Name = "pnlQuestionList";
            this.pnlQuestionList.Size = new System.Drawing.Size(360, 280);
            this.pnlQuestionList.TabIndex = 20;
            // 
            // QuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(780, 420);
            this.Controls.Add(this.pnlQuestionList);
            this.Controls.Add(this.pnlQuestionDetails);
            this.Controls.Add(this.lblTitle);
            this.Font = FormStyling.NormalFont;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "QuestionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Questions";
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestions)).EndInit();
            this.pnlQuestionDetails.ResumeLayout(false);
            this.pnlQuestionDetails.PerformLayout();
            this.pnlQuestionList.ResumeLayout(false);
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
        private System.Windows.Forms.ListBox lstQuestions;
        private System.Windows.Forms.Button btnViewQuestion;
        private System.Windows.Forms.Button btnEditQuestion;
        private System.Windows.Forms.Button btnDeleteQuestion;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvQuestions;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Panel pnlQuestionDetails;
        private System.Windows.Forms.Panel pnlQuestionList;
    }

        #endregion
    }