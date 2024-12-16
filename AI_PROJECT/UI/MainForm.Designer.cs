﻿using AI_PROJECT.UI;

namespace AI_PROJECT
{
    partial class MainForm
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
            this.btnManageCategories = new System.Windows.Forms.Button();
            this.btnManageQuestions = new System.Windows.Forms.Button();
            this.btnCreateExam = new System.Windows.Forms.Button();
            this.btnTakeExam = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnManageCategories
            // 
            this.btnManageCategories.Location = new System.Drawing.Point(50, 120);
            this.btnManageCategories.Name = "btnManageCategories";
            this.btnManageCategories.Size = new System.Drawing.Size(250, 50);
            this.btnManageCategories.TabIndex = 0;
            this.btnManageCategories.Text = "Manage Categories";
            this.btnManageCategories.UseVisualStyleBackColor = true;
            this.btnManageCategories.Click += new System.EventHandler(this.btnManageCategories_Click);
            // 
            // btnManageQuestions
            // 
            this.btnManageQuestions.Location = new System.Drawing.Point(50, 190);
            this.btnManageQuestions.Name = "btnManageQuestions";
            this.btnManageQuestions.Size = new System.Drawing.Size(250, 50);
            this.btnManageQuestions.TabIndex = 1;
            this.btnManageQuestions.Text = "Manage Questions";
            this.btnManageQuestions.UseVisualStyleBackColor = true;
            this.btnManageQuestions.Click += new System.EventHandler(this.btnManageQuestions_Click);
            // 
            // btnCreateExam
            // 
            this.btnCreateExam.Location = new System.Drawing.Point(50, 260);
            this.btnCreateExam.Name = "btnCreateExam";
            this.btnCreateExam.Size = new System.Drawing.Size(250, 50);
            this.btnCreateExam.TabIndex = 2;
            this.btnCreateExam.Text = "Create Exam";
            this.btnCreateExam.UseVisualStyleBackColor = true;
            this.btnCreateExam.Click += new System.EventHandler(this.btnCreateExam_Click);
            // 
            // btnTakeExam
            // 
            this.btnTakeExam.Location = new System.Drawing.Point(50, 330);
            this.btnTakeExam.Name = "btnTakeExam";
            this.btnTakeExam.Size = new System.Drawing.Size(250, 50);
            this.btnTakeExam.TabIndex = 3;
            this.btnTakeExam.Text = "Take Exam";
            this.btnTakeExam.UseVisualStyleBackColor = true;
            this.btnTakeExam.Click += new System.EventHandler(this.btnTakeExam_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = FormStyling.HeaderFont;
            this.lblWelcome.Location = new System.Drawing.Point(45, 40);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(260, 30);
            this.lblWelcome.TabIndex = 4;
            this.lblWelcome.Text = "Welcome to the Quiz System";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 420);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnTakeExam);
            this.Controls.Add(this.btnCreateExam);
            this.Controls.Add(this.btnManageQuestions);
            this.Controls.Add(this.btnManageCategories);
            this.Font = FormStyling.NormalFont;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quiz System";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnManageCategories;
        private System.Windows.Forms.Button btnManageQuestions;
        private System.Windows.Forms.Button btnCreateExam;
        private System.Windows.Forms.Button btnTakeExam;
        private System.Windows.Forms.Label lblWelcome;
        #endregion
    }
}

