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
        private UserService _userService;
       

        public MainForm(UserService userService)
        {
            InitializeComponent();
            FormStyling.ApplyStyles(this);
            _userService = userService;
/*            ShowLoginForm();
*/            UpdateButtonVisibility();
        }
        private void UpdateButtonVisibility()
        {
            bool isAdmin = _userService.IsAdmin();
            btnManageCategories.Visible = isAdmin;
            btnManageQuestions.Visible = isAdmin;
            btnCreateExam.Visible = isAdmin;
            btnTakeExam.Visible = true; // Tất cả người dùng đều có thể làm bài thi
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
            var takeExamForm = new TakeExamForm();
            takeExamForm.ShowDialog();
        }


    }
}
