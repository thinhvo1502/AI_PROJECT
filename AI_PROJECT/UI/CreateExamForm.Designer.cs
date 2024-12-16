namespace AI_PROJECT.UI
{
    partial class CreateExamForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblExamName = new System.Windows.Forms.Label();
            this.txtExamName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblTimeLimit = new System.Windows.Forms.Label();
            this.numTimeLimit = new System.Windows.Forms.NumericUpDown();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategories = new System.Windows.Forms.ComboBox();
            this.lblQuestions = new System.Windows.Forms.Label();
            this.lstQuestions = new System.Windows.Forms.CheckedListBox();
            this.btnCreateExam = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(143, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Create Exam";
            // 
            // lblExamName
            // 
            this.lblExamName.AutoSize = true;
            this.lblExamName.Location = new System.Drawing.Point(20, 70);
            this.lblExamName.Name = "lblExamName";
            this.lblExamName.Size = new System.Drawing.Size(84, 19);
            this.lblExamName.TabIndex = 1;
            this.lblExamName.Text = "Exam Name:";
            // 
            // txtExamName
            // 
            this.txtExamName.Location = new System.Drawing.Point(140, 67);
            this.txtExamName.Name = "txtExamName";
            this.txtExamName.Size = new System.Drawing.Size(200, 25);
            this.txtExamName.TabIndex = 2;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(20, 110);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(81, 19);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(140, 107);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 60);
            this.txtDescription.TabIndex = 4;
            // 
            // lblTimeLimit
            // 
            this.lblTimeLimit.AutoSize = true;
            this.lblTimeLimit.Location = new System.Drawing.Point(20, 180);
            this.lblTimeLimit.Name = "lblTimeLimit";
            this.lblTimeLimit.Size = new System.Drawing.Size(116, 19);
            this.lblTimeLimit.TabIndex = 5;
            this.lblTimeLimit.Text = "Time Limit (mins):";
            // 
            // numTimeLimit
            // 
            this.numTimeLimit.Location = new System.Drawing.Point(140, 177);
            this.numTimeLimit.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numTimeLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTimeLimit.Name = "numTimeLimit";
            this.numTimeLimit.Size = new System.Drawing.Size(60, 25);
            this.numTimeLimit.TabIndex = 6;
            this.numTimeLimit.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(20, 220);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(68, 19);
            this.lblCategory.TabIndex = 7;
            this.lblCategory.Text = "Category:";
            // 
            // cmbCategories
            // 
            this.cmbCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategories.FormattingEnabled = true;
            this.cmbCategories.Location = new System.Drawing.Point(140, 217);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Size = new System.Drawing.Size(200, 25);
            this.cmbCategories.TabIndex = 8;
            this.cmbCategories.SelectedIndexChanged += new System.EventHandler(this.cmbCategories_SelectedIndexChanged);
            // 
            // lblQuestions
            // 
            this.lblQuestions.AutoSize = true;
            this.lblQuestions.Location = new System.Drawing.Point(20, 260);
            this.lblQuestions.Name = "lblQuestions";
            this.lblQuestions.Size = new System.Drawing.Size(74, 19);
            this.lblQuestions.TabIndex = 9;
            this.lblQuestions.Text = "Questions:";
            // 
            // lstQuestions
            // 
            this.lstQuestions.FormattingEnabled = true;
            this.lstQuestions.Location = new System.Drawing.Point(140, 260);
            this.lstQuestions.Name = "lstQuestions";
            this.lstQuestions.Size = new System.Drawing.Size(200, 184);
            this.lstQuestions.TabIndex = 10;
            // 
            // btnCreateExam
            // 
            this.btnCreateExam.Location = new System.Drawing.Point(140, 460);
            this.btnCreateExam.Name = "btnCreateExam";
            this.btnCreateExam.Size = new System.Drawing.Size(120, 35);
            this.btnCreateExam.TabIndex = 11;
            this.btnCreateExam.Text = "Create Exam";
            this.btnCreateExam.UseVisualStyleBackColor = true;
            this.btnCreateExam.Click += new System.EventHandler(this.btnCreateExam_Click);
            // 
            // CreateExamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 520);
            this.Controls.Add(this.btnCreateExam);
            this.Controls.Add(this.lstQuestions);
            this.Controls.Add(this.lblQuestions);
            this.Controls.Add(this.cmbCategories);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.numTimeLimit);
            this.Controls.Add(this.lblTimeLimit);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtExamName);
            this.Controls.Add(this.lblExamName);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "CreateExamForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Exam";
            this.Load += new System.EventHandler(this.CreateExamForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numTimeLimit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblExamName;
        private System.Windows.Forms.TextBox txtExamName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblTimeLimit;
        private System.Windows.Forms.NumericUpDown numTimeLimit;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategories;
        private System.Windows.Forms.Label lblQuestions;
        private System.Windows.Forms.CheckedListBox lstQuestions;
        private System.Windows.Forms.Button btnCreateExam;
    }

        #endregion
    }
