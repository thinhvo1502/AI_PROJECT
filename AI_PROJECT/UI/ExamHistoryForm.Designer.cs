using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AI_PROJECT.UI
{
    partial class ExamHistoryForm
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
            this.dgvExamHistory = new System.Windows.Forms.DataGridView();
            this.chartScoreOverTime = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartAverageScoreByExam = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmbSortBy = new System.Windows.Forms.ComboBox();
            this.lblSortBy = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartScoreOverTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAverageScoreByExam)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Exam History";
            // 
            // dgvExamHistory
            // 
            this.dgvExamHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExamHistory.Location = new System.Drawing.Point(20, 100);
            this.dgvExamHistory.Name = "dgvExamHistory";
            this.dgvExamHistory.Size = new System.Drawing.Size(760, 200);
            this.dgvExamHistory.TabIndex = 1;
            this.dgvExamHistory.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvExamHistory_CellFormatting);
            // 
            // chartScoreOverTime
            // 
            this.chartScoreOverTime.Location = new System.Drawing.Point(20, 310);
            this.chartScoreOverTime.Name = "chartScoreOverTime";
            this.chartScoreOverTime.Size = new System.Drawing.Size(370, 300);
            this.chartScoreOverTime.TabIndex = 2;
            this.chartScoreOverTime.Text = "Score Over Time";
            this.chartScoreOverTime.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartScoreOverTime_MouseMove);
            // 
            // chartAverageScoreByExam
            // 
            this.chartAverageScoreByExam.Location = new System.Drawing.Point(410, 310);
            this.chartAverageScoreByExam.Name = "chartAverageScoreByExam";
            this.chartAverageScoreByExam.Size = new System.Drawing.Size(370, 300);
            this.chartAverageScoreByExam.TabIndex = 3;
            this.chartAverageScoreByExam.Text = "Average Score by Exam";
            // 
            // cmbSortBy
            // 
            this.cmbSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortBy.FormattingEnabled = true;
            this.cmbSortBy.Items.AddRange(new object[] { "Date (Newest First)", "Date (Oldest First)", "Score (Highest First)", "Score (Lowest First)" });
            this.cmbSortBy.Location = new System.Drawing.Point(80, 70);
            this.cmbSortBy.Name = "cmbSortBy";
            this.cmbSortBy.Size = new System.Drawing.Size(150, 25);
            this.cmbSortBy.TabIndex = 4;
            this.cmbSortBy.SelectedIndexChanged += new System.EventHandler(this.cmbSortBy_SelectedIndexChanged);
            // 
            // lblSortBy
            // 
            this.lblSortBy.AutoSize = true;
            this.lblSortBy.Location = new System.Drawing.Point(20, 73);
            this.lblSortBy.Name = "lblSortBy";
            this.lblSortBy.Size = new System.Drawing.Size(54, 17);
            this.lblSortBy.TabIndex = 5;
            this.lblSortBy.Text = "Sort by:";
            // 
            // ExamHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 630);
            this.Controls.Add(this.lblSortBy);
            this.Controls.Add(this.cmbSortBy);
            this.Controls.Add(this.chartAverageScoreByExam);
            this.Controls.Add(this.chartScoreOverTime);
            this.Controls.Add(this.dgvExamHistory);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "ExamHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exam History";
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartScoreOverTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAverageScoreByExam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvExamHistory;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartScoreOverTime;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAverageScoreByExam;
        private System.Windows.Forms.ComboBox cmbSortBy;
        private System.Windows.Forms.Label lblSortBy;

        #endregion
    }
}