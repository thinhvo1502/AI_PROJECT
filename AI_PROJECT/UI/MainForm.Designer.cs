using AI_PROJECT.UI;

namespace AI_PROJECT
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        

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
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnManageCategories = new System.Windows.Forms.Button();
            this.btnManageQuestions = new System.Windows.Forms.Button();
            this.btnCreateExam = new System.Windows.Forms.Button();
            this.btnTakeExam = new System.Windows.Forms.Button();
            this.btnExamHistory = new System.Windows.Forms.Button();
            this.btnEditExam = new System.Windows.Forms.Button();
            this.btnDeleteExam = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlSidebar.Controls.Add(this.btnManageCategories);
            this.pnlSidebar.Controls.Add(this.btnManageQuestions);
            this.pnlSidebar.Controls.Add(this.btnCreateExam);
            this.pnlSidebar.Controls.Add(this.btnTakeExam);
            this.pnlSidebar.Controls.Add(this.btnExamHistory);
            this.pnlSidebar.Controls.Add(this.btnEditExam);
            this.pnlSidebar.Controls.Add(this.btnDeleteExam);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(200, 600);
            this.pnlSidebar.TabIndex = 0;
            // 
            // btnManageCategories
            // 
            this.btnManageCategories.FlatAppearance.BorderSize = 0;
            this.btnManageCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageCategories.ForeColor = System.Drawing.Color.White;
            this.btnManageCategories.Location = new System.Drawing.Point(0, 80);
            this.btnManageCategories.Name = "btnManageCategories";
            this.btnManageCategories.Size = new System.Drawing.Size(200, 40);
            this.btnManageCategories.TabIndex = 0;
            this.btnManageCategories.Text = "Manage Categories";
            this.btnManageCategories.UseVisualStyleBackColor = true;
            this.btnManageCategories.Click += new System.EventHandler(this.btnManageCategories_Click);
            // 
            // btnManageQuestions
            // 
            this.btnManageQuestions.FlatAppearance.BorderSize = 0;
            this.btnManageQuestions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageQuestions.ForeColor = System.Drawing.Color.White;
            this.btnManageQuestions.Location = new System.Drawing.Point(0, 120);
            this.btnManageQuestions.Name = "btnManageQuestions";
            this.btnManageQuestions.Size = new System.Drawing.Size(200, 40);
            this.btnManageQuestions.TabIndex = 1;
            this.btnManageQuestions.Text = "Manage Questions";
            this.btnManageQuestions.UseVisualStyleBackColor = true;
            this.btnManageQuestions.Click += new System.EventHandler(this.btnManageQuestions_Click);
            // 
            // btnCreateExam
            // 
            this.btnCreateExam.FlatAppearance.BorderSize = 0;
            this.btnCreateExam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateExam.ForeColor = System.Drawing.Color.White;
            this.btnCreateExam.Location = new System.Drawing.Point(0, 160);
            this.btnCreateExam.Name = "btnCreateExam";
            this.btnCreateExam.Size = new System.Drawing.Size(200, 40);
            this.btnCreateExam.TabIndex = 2;
            this.btnCreateExam.Text = "Create Exam";
            this.btnCreateExam.UseVisualStyleBackColor = true;
            this.btnCreateExam.Click += new System.EventHandler(this.btnCreateExam_Click);
            // 
            // btnTakeExam
            // 
            this.btnTakeExam.FlatAppearance.BorderSize = 0;
            this.btnTakeExam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTakeExam.ForeColor = System.Drawing.Color.White;
            this.btnTakeExam.Location = new System.Drawing.Point(0, 200);
            this.btnTakeExam.Name = "btnTakeExam";
            this.btnTakeExam.Size = new System.Drawing.Size(200, 40);
            this.btnTakeExam.TabIndex = 3;
            this.btnTakeExam.Text = "Take Exam";
            this.btnTakeExam.UseVisualStyleBackColor = true;
            this.btnTakeExam.Click += new System.EventHandler(this.btnTakeExam_Click);
            // 
            // btnExamHistory
            // 
            this.btnExamHistory.FlatAppearance.BorderSize = 0;
            this.btnExamHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExamHistory.ForeColor = System.Drawing.Color.White;
            this.btnExamHistory.Location = new System.Drawing.Point(0, 240);
            this.btnExamHistory.Name = "btnExamHistory";
            this.btnExamHistory.Size = new System.Drawing.Size(200, 40);
            this.btnExamHistory.TabIndex = 4;
            this.btnExamHistory.Text = "View Exam History";
            this.btnExamHistory.UseVisualStyleBackColor = true;
            this.btnExamHistory.Click += new System.EventHandler(this.btnExamHistory_Click);
            // 
            // btnEditExam
            // 
            this.btnEditExam.FlatAppearance.BorderSize = 0;
            this.btnEditExam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditExam.ForeColor = System.Drawing.Color.White;
            this.btnEditExam.Location = new System.Drawing.Point(0, 280);
            this.btnEditExam.Name = "btnEditExam";
            this.btnEditExam.Size = new System.Drawing.Size(200, 40);
            this.btnEditExam.TabIndex = 5;
            this.btnEditExam.Text = "Edit Exam";
            this.btnEditExam.UseVisualStyleBackColor = true;
            this.btnEditExam.Click += new System.EventHandler(this.btnEditExam_Click);
            // 
            // btnDeleteExam
            // 
            this.btnDeleteExam.FlatAppearance.BorderSize = 0;
            this.btnDeleteExam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteExam.ForeColor = System.Drawing.Color.White;
            this.btnDeleteExam.Location = new System.Drawing.Point(0, 320);
            this.btnDeleteExam.Name = "btnDeleteExam";
            this.btnDeleteExam.Size = new System.Drawing.Size(200, 40);
            this.btnDeleteExam.TabIndex = 6;
            this.btnDeleteExam.Text = "Delete Exam";
            this.btnDeleteExam.UseVisualStyleBackColor = true;
            this.btnDeleteExam.Click += new System.EventHandler(this.btnDeleteExam_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblWelcome.Location = new System.Drawing.Point(220, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(331, 32);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome to the Quiz System";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Location = new System.Drawing.Point(220, 70);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(560, 510);
            this.pnlContent.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quiz System";
            this.pnlSidebar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button btnManageCategories;
        private System.Windows.Forms.Button btnManageQuestions;
        private System.Windows.Forms.Button btnCreateExam;
        private System.Windows.Forms.Button btnTakeExam;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnExamHistory;
        private System.Windows.Forms.Button btnEditExam;
        private System.Windows.Forms.Button btnDeleteExam;
        private System.Windows.Forms.Panel pnlContent;
        #endregion
    }
}

