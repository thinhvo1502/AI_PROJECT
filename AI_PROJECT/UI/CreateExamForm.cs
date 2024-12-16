using AI_PROJECT.BLL;
using AI_PROJECT.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_PROJECT.UI
{
    public partial class CreateExamForm : Form
    {
        private ExamService _examService;
        private CategoryService _categoryService;
        private List<Question> _questions;
        private System.ComponentModel.IContainer components = null;

        public CreateExamForm()
        {
            InitializeComponent();
            _examService = new ExamService();
            _categoryService = new CategoryService();
            FormStyling.ApplyStyles(this);
            LoadCategories();
        }

        private void LoadCategories()
        {
            cmbCategories.Items.Clear();
            var categories = _categoryService.GetAllCategories();
            foreach (var category in categories)
            {
                cmbCategories.Items.Add(new ComboBoxItem { Text = category.CategoryName, Value = category.CategoryID });
            }
        }

        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategories.SelectedItem is ComboBoxItem selectedCategory)
            {
                LoadQuestions((int)selectedCategory.Value);
            }
        }

        private void LoadQuestions(int categoryId)
        {
            lstQuestions.Items.Clear();
            _questions = _examService.GetQuestionsByCategory(categoryId);
            foreach (var question in _questions)
            {
                lstQuestions.Items.Add(question.QuestionText, false);
            }
        }

        private void btnCreateExam_Click(object sender, EventArgs e)
        {
            try
            {
                var examName = txtExamName.Text;
                var description = txtDescription.Text;
                var timeLimit = (int)numTimeLimit.Value;
                var selectedQuestionIds = new List<int>();

                for (int i = 0; i < lstQuestions.CheckedItems.Count; i++)
                {
                    int index = lstQuestions.CheckedIndices[i];
                    selectedQuestionIds.Add(_questions[index].QuestionID);
                }

                int examId = _examService.CreateExam(examName, description, timeLimit, selectedQuestionIds);
                MessageBox.Show($"Exam created successfully! Exam ID: {examId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtExamName.Clear();
            txtDescription.Clear();
            numTimeLimit.Value = 60;
            cmbCategories.SelectedIndex = -1;
            lstQuestions.Items.Clear();
        }

        private void CreateExamForm_Load(object sender, EventArgs e)
        {

        }
    }
}
