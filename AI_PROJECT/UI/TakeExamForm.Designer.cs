namespace AI_PROJECT.UI
{
    partial class TakeExamForm
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
            this.lblSelectExam = new System.Windows.Forms.Label();
            this.cmbExams = new System.Windows.Forms.ComboBox();
            this.btnStartExam = new System.Windows.Forms.Button();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.rbAnswer1 = new System.Windows.Forms.RadioButton();
            this.rbAnswer2 = new System.Windows.Forms.RadioButton();
            this.rbAnswer3 = new System.Windows.Forms.RadioButton();
            this.rbAnswer4 = new System.Windows.Forms.RadioButton();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblExamName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = FormStyling.HeaderFont;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(100, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Take Exam";
            // 
            // lblExamName
            // 
            this.lblExamName.AutoSize = true;
            this.lblExamName.Font = FormStyling.HeaderFont;
            this.lblExamName.Location = new System.Drawing.Point(20, 50);
            this.lblExamName.Name = "lblExamName";
            this.lblExamName.Size = new System.Drawing.Size(200, 30);
            this.lblExamName.TabIndex = 13;
            this.lblExamName.Text = "Exam Name";
            this.lblExamName.Visible = false;
            // 
            // lblSelectExam
            // 
            this.lblSelectExam.AutoSize = true;
            this.lblSelectExam.Location = new System.Drawing.Point(20, 70);
            this.lblSelectExam.Name = "lblSelectExam";
            this.lblSelectExam.Size = new System.Drawing.Size(82, 17);
            this.lblSelectExam.TabIndex = 1;
            this.lblSelectExam.Text = "Select Exam:";
            // 
            // cmbExams
            // 
            this.cmbExams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExams.FormattingEnabled = true;
            this.cmbExams.Location = new System.Drawing.Point(110, 67);
            this.cmbExams.Name = "cmbExams";
            this.cmbExams.Size = new System.Drawing.Size(200, 25);
            this.cmbExams.TabIndex = 2;
            // 
            // btnStartExam
            // 
            this.btnStartExam.Location = new System.Drawing.Point(320, 65);
            this.btnStartExam.Name = "btnStartExam";
            this.btnStartExam.Size = new System.Drawing.Size(100, 30);
            this.btnStartExam.TabIndex = 3;
            this.btnStartExam.Text = "Start Exam";
            this.btnStartExam.UseVisualStyleBackColor = true;
            this.btnStartExam.Click += new System.EventHandler(this.btnStartExam_Click);
            // 
            // lblQuestion
            // 
            this.lblQuestion.Location = new System.Drawing.Point(20, 110);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(400, 60);
            this.lblQuestion.TabIndex = 4;
            this.lblQuestion.Text = "Question Text";
            this.lblQuestion.Visible = false;
            // 
            // rbAnswer1
            // 
            this.rbAnswer1.AutoSize = true;
            this.rbAnswer1.Location = new System.Drawing.Point(20, 180);
            this.rbAnswer1.Name = "rbAnswer1";
            this.rbAnswer1.Size = new System.Drawing.Size(85, 21);
            this.rbAnswer1.TabIndex = 5;
            this.rbAnswer1.TabStop = true;
            this.rbAnswer1.Text = "Answer 1";
            this.rbAnswer1.UseVisualStyleBackColor = true;
            this.rbAnswer1.Visible = false;
            // 
            // rbAnswer2
            // 
            this.rbAnswer2.AutoSize = true;
            this.rbAnswer2.Location = new System.Drawing.Point(20, 210);
            this.rbAnswer2.Name = "rbAnswer2";
            this.rbAnswer2.Size = new System.Drawing.Size(85, 21);
            this.rbAnswer2.TabIndex = 6;
            this.rbAnswer2.TabStop = true;
            this.rbAnswer2.Text = "Answer 2";
            this.rbAnswer2.UseVisualStyleBackColor = true;
            this.rbAnswer2.Visible = false;
            // 
            // rbAnswer3
            // 
            this.rbAnswer3.AutoSize = true;
            this.rbAnswer3.Location = new System.Drawing.Point(20, 240);
            this.rbAnswer3.Name = "rbAnswer3";
            this.rbAnswer3.Size = new System.Drawing.Size(85, 21);
            this.rbAnswer3.TabIndex = 7;
            this.rbAnswer3.TabStop = true;
            this.rbAnswer3.Text = "Answer 3";
            this.rbAnswer3.UseVisualStyleBackColor = true;
            this.rbAnswer3.Visible = false;
            // 
            // rbAnswer4
            // 
            this.rbAnswer4.AutoSize = true;
            this.rbAnswer4.Location = new System.Drawing.Point(20, 270);
            this.rbAnswer4.Name = "rbAnswer4";
            this.rbAnswer4.Size = new System.Drawing.Size(85, 21);
            this.rbAnswer4.TabIndex = 8;
            this.rbAnswer4.TabStop = true;
            this.rbAnswer4.Text = "Answer 4";
            this.rbAnswer4.UseVisualStyleBackColor = true;
            this.rbAnswer4.Visible = false;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(20, 310);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(100, 35);
            this.btnPrevious.TabIndex = 9;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Visible = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(170, 310);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 35);
            this.btnNext.TabIndex = 10;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Visible = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(320, 310);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(100, 35);
            this.btnSubmit.TabIndex = 11;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Visible = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTimer.Location = new System.Drawing.Point(320, 20);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(100, 21);
            this.lblTimer.TabIndex = 12;
            this.lblTimer.Text = "Time Left: ";
            this.lblTimer.Visible = false;
            // 
            // TakeExamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 370);
            this.Controls.Add(this.lblExamName);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.rbAnswer4);
            this.Controls.Add(this.rbAnswer3);
            this.Controls.Add(this.rbAnswer2);
            this.Controls.Add(this.rbAnswer1);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.btnStartExam);
            this.Controls.Add(this.cmbExams);
            this.Controls.Add(this.lblSelectExam);
            this.Controls.Add(this.lblTitle);
            this.Font = FormStyling.NormalFont;
            this.Name = "TakeExamForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Take Exam";
            this.Load += new System.EventHandler(this.TakeExamForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSelectExam;
        private System.Windows.Forms.ComboBox cmbExams;
        private System.Windows.Forms.Button btnStartExam;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.RadioButton rbAnswer1;
        private System.Windows.Forms.RadioButton rbAnswer2;
        private System.Windows.Forms.RadioButton rbAnswer3;
        private System.Windows.Forms.RadioButton rbAnswer4;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblExamName;
    }

        #endregion
    }
