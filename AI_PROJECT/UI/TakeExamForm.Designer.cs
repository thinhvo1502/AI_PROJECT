using System.Drawing;
using System.Windows.Forms;
using System;

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
            this.lblExamTitle = new System.Windows.Forms.Label();
            this.lblExamDescription = new System.Windows.Forms.Label();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.rbAnswer1 = new System.Windows.Forms.RadioButton();
            this.rbAnswer2 = new System.Windows.Forms.RadioButton();
            this.rbAnswer3 = new System.Windows.Forms.RadioButton();
            this.rbAnswer4 = new System.Windows.Forms.RadioButton();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblTimer = new System.Windows.Forms.Label();
            this.pnlExamSelection = new System.Windows.Forms.Panel();
            this.pnlExamInfo = new System.Windows.Forms.Panel();
            this.pnlQuestion = new System.Windows.Forms.Panel();
            this.pnlNavigation = new System.Windows.Forms.Panel();
            this.pnlExamSelection.SuspendLayout();
            this.pnlExamInfo.SuspendLayout();
            this.pnlQuestion.SuspendLayout();
            this.pnlNavigation.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(137, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Take Exam";
            // 
            // lblSelectExam
            // 
            this.lblSelectExam.AutoSize = true;
            this.lblSelectExam.Location = new System.Drawing.Point(20, 15);
            this.lblSelectExam.Name = "lblSelectExam";
            this.lblSelectExam.Size = new System.Drawing.Size(82, 17);
            this.lblSelectExam.TabIndex = 1;
            this.lblSelectExam.Text = "Select Exam:";
            // 
            // cmbExams
            // 
            this.cmbExams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExams.FormattingEnabled = true;
            this.cmbExams.Location = new System.Drawing.Point(120, 12);
            this.cmbExams.Name = "cmbExams";
            this.cmbExams.Size = new System.Drawing.Size(300, 25);
            this.cmbExams.TabIndex = 2;
            // 
            // btnStartExam
            // 
            this.btnStartExam.Location = new System.Drawing.Point(440, 10);
            this.btnStartExam.Name = "btnStartExam";
            this.btnStartExam.Size = new System.Drawing.Size(100, 30);
            this.btnStartExam.TabIndex = 3;
            this.btnStartExam.Text = "Start Exam";
            this.btnStartExam.UseVisualStyleBackColor = true;
            this.btnStartExam.Click += new System.EventHandler(this.btnStartExam_Click);
            // 
            // lblExamTitle
            // 
            this.lblExamTitle.AutoSize = true;
            this.lblExamTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExamTitle.Location = new System.Drawing.Point(20, 10);
            this.lblExamTitle.Name = "lblExamTitle";
            this.lblExamTitle.Size = new System.Drawing.Size(100, 25);
            this.lblExamTitle.TabIndex = 4;
            this.lblExamTitle.Text = "Exam Title";
            this.lblExamTitle.Visible = false;
            // 
            // lblExamDescription
            // 
            this.lblExamDescription.Location = new System.Drawing.Point(20, 40);
            this.lblExamDescription.Name = "lblExamDescription";
            this.lblExamDescription.Size = new System.Drawing.Size(520, 40);
            this.lblExamDescription.TabIndex = 5;
            this.lblExamDescription.Text = "Exam Description";
            this.lblExamDescription.Visible = false;
            // 
            // lblQuestion
            // 
            this.lblQuestion.Location = new System.Drawing.Point(20, 10);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(520, 60);
            this.lblQuestion.TabIndex = 6;
            this.lblQuestion.Text = "Question Text";
            this.lblQuestion.Visible = false;
            // 
            // rbAnswer1
            // 
            this.rbAnswer1.AutoSize = true;
            this.rbAnswer1.Location = new System.Drawing.Point(20, 80);
            this.rbAnswer1.Name = "rbAnswer1";
            this.rbAnswer1.Size = new System.Drawing.Size(85, 21);
            this.rbAnswer1.TabIndex = 7;
            this.rbAnswer1.TabStop = true;
            this.rbAnswer1.Text = "Answer 1";
            this.rbAnswer1.UseVisualStyleBackColor = true;
            this.rbAnswer1.Visible = false;
            // 
            // rbAnswer2
            // 
            this.rbAnswer2.AutoSize = true;
            this.rbAnswer2.Location = new System.Drawing.Point(20, 110);
            this.rbAnswer2.Name = "rbAnswer2";
            this.rbAnswer2.Size = new System.Drawing.Size(85, 21);
            this.rbAnswer2.TabIndex = 8;
            this.rbAnswer2.TabStop = true;
            this.rbAnswer2.Text = "Answer 2";
            this.rbAnswer2.UseVisualStyleBackColor = true;
            this.rbAnswer2.Visible = false;
            // 
            // rbAnswer3
            // 
            this.rbAnswer3.AutoSize = true;
            this.rbAnswer3.Location = new System.Drawing.Point(20, 140);
            this.rbAnswer3.Name = "rbAnswer3";
            this.rbAnswer3.Size = new System.Drawing.Size(85, 21);
            this.rbAnswer3.TabIndex = 9;
            this.rbAnswer3.TabStop = true;
            this.rbAnswer3.Text = "Answer 3";
            this.rbAnswer3.UseVisualStyleBackColor = true;
            this.rbAnswer3.Visible = false;
            // 
            // rbAnswer4
            // 
            this.rbAnswer4.AutoSize = true;
            this.rbAnswer4.Location = new System.Drawing.Point(20, 170);
            this.rbAnswer4.Name = "rbAnswer4";
            this.rbAnswer4.Size = new System.Drawing.Size(85, 21);
            this.rbAnswer4.TabIndex = 10;
            this.rbAnswer4.TabStop = true;
            this.rbAnswer4.Text = "Answer 4";
            this.rbAnswer4.UseVisualStyleBackColor = true;
            this.rbAnswer4.Visible = false;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(20, 10);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(100, 35);
            this.btnPrevious.TabIndex = 11;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Visible = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(230, 10);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 35);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Visible = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(440, 10);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(100, 35);
            this.btnSubmit.TabIndex = 13;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Visible = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.Location = new System.Drawing.Point(420, 20);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(100, 21);
            this.lblTimer.TabIndex = 14;
            this.lblTimer.Text = "Time Left: ";
            this.lblTimer.Visible = false;
            // 
            // pnlExamSelection
            // 
            this.pnlExamSelection.BackColor = System.Drawing.Color.White;
            this.pnlExamSelection.Controls.Add(this.lblSelectExam);
            this.pnlExamSelection.Controls.Add(this.cmbExams);
            this.pnlExamSelection.Controls.Add(this.btnStartExam);
            this.pnlExamSelection.Location = new System.Drawing.Point(20, 70);
            this.pnlExamSelection.Name = "pnlExamSelection";
            this.pnlExamSelection.Size = new System.Drawing.Size(560, 50);
            this.pnlExamSelection.TabIndex = 15;
            // 
            // pnlExamInfo
            // 
            this.pnlExamInfo.BackColor = System.Drawing.Color.White;
            this.pnlExamInfo.Controls.Add(this.lblExamTitle);
            this.pnlExamInfo.Controls.Add(this.lblExamDescription);
            this.pnlExamInfo.Location = new System.Drawing.Point(20, 130);
            this.pnlExamInfo.Name = "pnlExamInfo";
            this.pnlExamInfo.Size = new System.Drawing.Size(560, 90);
            this.pnlExamInfo.TabIndex = 16;
            this.pnlExamInfo.Visible = false;
            // 
            // pnlQuestion
            // 
            this.pnlQuestion.BackColor = System.Drawing.Color.White;
            this.pnlQuestion.Controls.Add(this.lblQuestion);
            this.pnlQuestion.Controls.Add(this.rbAnswer1);
            this.pnlQuestion.Controls.Add(this.rbAnswer2);
            this.pnlQuestion.Controls.Add(this.rbAnswer3);
            this.pnlQuestion.Controls.Add(this.rbAnswer4);
            this.pnlQuestion.Location = new System.Drawing.Point(20, 230);
            this.pnlQuestion.Name = "pnlQuestion";
            this.pnlQuestion.Size = new System.Drawing.Size(560, 200);
            this.pnlQuestion.TabIndex = 17;
            this.pnlQuestion.Visible = false;
            // 
            // pnlNavigation
            // 
            this.pnlNavigation.BackColor = System.Drawing.Color.White;
            this.pnlNavigation.Controls.Add(this.btnPrevious);
            this.pnlNavigation.Controls.Add(this.btnNext);
            this.pnlNavigation.Controls.Add(this.btnSubmit);
            this.pnlNavigation.Location = new System.Drawing.Point(20, 440);
            this.pnlNavigation.Name = "pnlNavigation";
            this.pnlNavigation.Size = new System.Drawing.Size(560, 55);
            this.pnlNavigation.TabIndex = 18;
            this.pnlNavigation.Visible = false;
            // 
            // TakeExamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.ClientSize = new System.Drawing.Size(600, 520);
            this.Controls.Add(this.pnlNavigation);
            this.Controls.Add(this.pnlQuestion);
            this.Controls.Add(this.pnlExamInfo);
            this.Controls.Add(this.pnlExamSelection);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TakeExamForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Take Exam";
            this.Load += new System.EventHandler(this.TakeExamForm_Load);
            this.pnlExamSelection.ResumeLayout(false);
            this.pnlExamSelection.PerformLayout();
            this.pnlExamInfo.ResumeLayout(false);
            this.pnlExamInfo.PerformLayout();
            this.pnlQuestion.ResumeLayout(false);
            this.pnlQuestion.PerformLayout();
            this.pnlNavigation.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSelectExam;
        private System.Windows.Forms.ComboBox cmbExams;
        private System.Windows.Forms.Button btnStartExam;
        private System.Windows.Forms.Label lblExamTitle;
        private System.Windows.Forms.Label lblExamDescription;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.RadioButton rbAnswer1;
        private System.Windows.Forms.RadioButton rbAnswer2;
        private System.Windows.Forms.RadioButton rbAnswer3;
        private System.Windows.Forms.RadioButton rbAnswer4;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Panel pnlExamSelection;
        private System.Windows.Forms.Panel pnlExamInfo;
        private System.Windows.Forms.Panel pnlQuestion;
        private System.Windows.Forms.Panel pnlNavigation;
    }

    #endregion
}
