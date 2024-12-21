using AI_PROJECT.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AI_PROJECT.BLL;
using AI_PROJECT.DAL.Models;
using AI_PROJECT.UI;

namespace AI_PROJECT
{
    public partial class MainForm : Form
    {
       private System.ComponentModel.IContainer components = null;
        private UserService _userService;
        private ExamService _examService;
        private System.Windows.Forms.Button btnExamHistory;

        public MainForm(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
            _examService = new ExamService();
            FormStyling.ApplyStyles(this);
            UpdateButtonVisibility();
        }

        private void UpdateButtonVisibility()
        {
            bool isAdmin = _userService.IsAdmin();
            btnManageCategories.Visible = isAdmin;
            btnManageQuestions.Visible = isAdmin;
            btnCreateExam.Visible = isAdmin;
            btnTakeExam.Visible = true; // Tất cả người dùng đều có thể làm bài thi
            btnExamHistory.Visible = true; //All users can view exam history.
            btnEditExam.Visible = isAdmin;
            btnDeleteExam.Visible = isAdmin;
        }

        private void btnManageCategories_Click(object sender, EventArgs e)
        {
            if (_userService.IsAdmin())
            {
                var categoryForm = new CategoryForm();
                categoryForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You don't have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnManageQuestions_Click(object sender, EventArgs e)
        {
            if (_userService.IsAdmin())
            {
                var questionForm = new QuestionForm();
                questionForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You don't have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCreateExam_Click(object sender, EventArgs e)
        {
            if (_userService.IsAdmin())
            {
                var createExamForm = new CreateExamForm();
                createExamForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You don't have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTakeExam_Click(object sender, EventArgs e)
        {
            var takeExamForm = new TakeExamForm(_userService);
            takeExamForm.ShowDialog();
        }

        private void btnExamHistory_Click(object sender, EventArgs e)
        {
            var examHistoryForm = new ExamHistoryForm(_userService);
            examHistoryForm.ShowDialog();
        }

        private void btnEditExam_Click(object sender, EventArgs e)
        {
            if (_userService.IsAdmin())
            {
                var selectExamForm = new SelectExamForm(_examService);
                if (selectExamForm.ShowDialog() == DialogResult.OK)
                {
                    var editExamForm = new EditExamForm(selectExamForm.SelectedExamId);
                    editExamForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("You don't have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteExam_Click(object sender, EventArgs e)
        {
            if (_userService.IsAdmin())
            {
                var selectExamForm = new SelectExamForm(_examService);
                if (selectExamForm.ShowDialog() == DialogResult.OK)
                {
                    var result = MessageBox.Show("Are you sure you want to delete this exam? This action cannot be undone.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            _examService.DeleteExam(selectExamForm.SelectedExamId);
                            MessageBox.Show("Exam deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred while deleting the exam: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("You don't have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



    }
}
