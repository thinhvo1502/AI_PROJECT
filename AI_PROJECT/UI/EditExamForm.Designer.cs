namespace AI_PROJECT.UI
{
    partial class EditExamForm
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
            this.lblExamName = new System.Windows.Forms.Label();
            this.txtExamName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblTimeLimit = new System.Windows.Forms.Label();
            this.numTimeLimit = new System.Windows.Forms.NumericUpDown();
            this.lblQuestions = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvQuestions = new System.Windows.Forms.DataGridView();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(114, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Edit Exam";
            // 
            // lblExamName
            // 
            this.lblExamName.AutoSize = true;
            this.lblExamName.Location = new System.Drawing.Point(20, 70);
            this.lblExamName.Name = "lblExamName";
            this.lblExamName.Size = new System.Drawing.Size(82, 17);
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
            this.lblDescription.Size = new System.Drawing.Size(78, 17);
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
            this.lblTimeLimit.Size = new System.Drawing.Size(114, 17);
            this.lblTimeLimit.TabIndex = 5;
            this.lblTimeLimit.Text = "Time Limit (mins):";
            // 
            // numTimeLimit
            // 
            this.numTimeLimit.Location = new System.Drawing.Point(140, 177);
            this.numTimeLimit.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            this.numTimeLimit.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numTimeLimit.Name = "numTimeLimit";
            this.numTimeLimit.Size = new System.Drawing.Size(60, 25);
            this.numTimeLimit.TabIndex = 6;
            this.numTimeLimit.Value = new decimal(new int[] { 60, 0, 0, 0 });
            // 
            // lblQuestions
            // 
            this.lblQuestions.AutoSize = true;
            this.lblQuestions.Location = new System.Drawing.Point(20, 220);
            this.lblQuestions.Name = "lblQuestions";
            this.lblQuestions.Size = new System.Drawing.Size(69, 17);
            this.lblQuestions.TabIndex = 7;
            this.lblQuestions.Text = "Questions:";
            // 
            // dgvQuestions
            // 
            this.dgvQuestions.AllowUserToAddRows = false;
            this.dgvQuestions.AllowUserToDeleteRows = false;
            this.dgvQuestions.Location = new System.Drawing.Point(20, 250);
            this.dgvQuestions.MultiSelect = true;
            this.dgvQuestions.Name = "dgvQuestions";
            this.dgvQuestions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuestions.Size = new System.Drawing.Size(320, 184);
            this.dgvQuestions.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(130, 440);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(240, 440);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.Location = new System.Drawing.Point(20, 440);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(100, 35);
            this.btnViewDetails.TabIndex = 11;
            this.btnViewDetails.Text = "View Details";
            this.btnViewDetails.UseVisualStyleBackColor = true;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // EditExamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 500);
            this.Controls.Add(this.btnViewDetails);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvQuestions);
            this.Controls.Add(this.lblQuestions);
            this.Controls.Add(this.numTimeLimit);
            this.Controls.Add(this.lblTimeLimit);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtExamName);
            this.Controls.Add(this.lblExamName);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "EditExamForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Exam";
            ((System.ComponentModel.ISupportInitialize)(this.numTimeLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestions)).EndInit();
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
        private System.Windows.Forms.Label lblQuestions;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvQuestions;
        private System.Windows.Forms.Button btnViewDetails;

        #endregion
    }
}