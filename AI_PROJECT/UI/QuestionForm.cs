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
    public partial class QuestionForm : Form
    {
        private QuestionService _questionService;
        private CategoryService _categoryService;

        public QuestionForm()
        {
            InitializeComponent();
            _questionService = new QuestionService();
            _categoryService = new CategoryService();
            ApplyCustomStyles();
            LoadCategories();
            LoadQuestions();
        }

        private void ApplyCustomStyles()
        {
            FormStyling.ApplyStyles(this);

            // Custom styles for QuestionForm
            this.pnlQuestionDetails.BorderStyle = BorderStyle.FixedSingle;
            this.pnlQuestionList.BorderStyle = BorderStyle.FixedSingle;

            this.btnAddQuestion.BackColor = Color.FromArgb(0, 150, 136);
            this.btnAddQuestion.ForeColor = Color.White;
            this.btnAddQuestion.FlatStyle = FlatStyle.Flat;
            this.btnAddQuestion.FlatAppearance.BorderSize = 0;

            this.btnCancel.BackColor = Color.FromArgb(158, 158, 158);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;

            this.btnViewDetails.BackColor = Color.FromArgb(3, 169, 244);
            this.btnViewDetails.ForeColor = Color.White;
            this.btnViewDetails.FlatStyle = FlatStyle.Flat;
            this.btnViewDetails.FlatAppearance.BorderSize = 0;

            this.btnEditQuestion.BackColor = Color.FromArgb(255, 152, 0);
            this.btnEditQuestion.ForeColor = Color.White;
            this.btnEditQuestion.FlatStyle = FlatStyle.Flat;
            this.btnEditQuestion.FlatAppearance.BorderSize = 0;

            this.btnDeleteQuestion.BackColor = Color.FromArgb(244, 67, 54);
            this.btnDeleteQuestion.ForeColor = Color.White;
            this.btnDeleteQuestion.FlatStyle = FlatStyle.Flat;
            this.btnDeleteQuestion.FlatAppearance.BorderSize = 0;

            // DataGridView styling
            this.dgvQuestions.BorderStyle = BorderStyle.None;
            this.dgvQuestions.BackgroundColor = Color.White;
            this.dgvQuestions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 150, 136);
            this.dgvQuestions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvQuestions.EnableHeadersVisualStyles = false;
        }

        private void LoadQuestions()
        {
            var questions = _questionService.GetAllQuestions();
            dgvQuestions.DataSource = questions.Select(q => new
            {
                q.QuestionID,
                Category = _categoryService.GetCategoryById(q.CategoryID).CategoryName,
                Question = q.QuestionText.Length > 50 ? q.QuestionText.Substring(0, 47) + "..." : q.QuestionText
            }).ToList();

            dgvQuestions.Columns["QuestionID"].Visible = false;
            dgvQuestions.AutoResizeColumns();
            dgvQuestions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvQuestions.SelectedRows.Count > 0)
            {
                int questionId = (int)dgvQuestions.SelectedRows[0].Cells["QuestionID"].Value;
                var question = _questionService.GetAllQuestions().FirstOrDefault(q => q.QuestionID == questionId);
                if (question != null)
                {
                    string details = $"Question: {question.QuestionText}\n\n" +
                                     $"Correct Answer: {question.CorrectAnswer}\n" +
                                     $"Wrong Answer 1: {question.WrongAnswer1}\n" +
                                     $"Wrong Answer 2: {question.WrongAnswer2}\n" +
                                     $"Wrong Answer 3: {question.WrongAnswer3}";
                    MessageBox.Show(details, "Question Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a question to view details.", "No Question Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnAddQuestion.Text == "Update Question")
                {
                    // Update existing question
                    var selectedQuestionId = (int)dgvQuestions.SelectedRows[0].Cells["QuestionID"].Value;
                    var updatedQuestion = new Question
                    {
                        QuestionID = selectedQuestionId,
                        CategoryID = ((Category)cmbCategories.SelectedItem).CategoryID,
                        QuestionText = txtQuestionText.Text,
                        CorrectAnswer = txtCorrectAnswer.Text,
                        WrongAnswer1 = txtWrongAnswer1.Text,
                        WrongAnswer2 = txtWrongAnswer2.Text,
                        WrongAnswer3 = txtWrongAnswer3.Text
                    };
                    _questionService.UpdateQuestion(updatedQuestion);
                    MessageBox.Show("Question updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Add new question
                    var newQuestion = new Question
                    {
                        CategoryID = ((Category)cmbCategories.SelectedItem).CategoryID,
                        QuestionText = txtQuestionText.Text,
                        CorrectAnswer = txtCorrectAnswer.Text,
                        WrongAnswer1 = txtWrongAnswer1.Text,
                        WrongAnswer2 = txtWrongAnswer2.Text,
                        WrongAnswer3 = txtWrongAnswer3.Text
                    };
                    _questionService.AddQuestion(newQuestion);
                    MessageBox.Show("Question added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ClearFields();
                LoadQuestions();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditQuestion_Click(object sender, EventArgs e)
        {
            if (dgvQuestions.SelectedRows.Count > 0)
            {
                int questionId = (int)dgvQuestions.SelectedRows[0].Cells["QuestionID"].Value;
                var question = _questionService.GetAllQuestions().FirstOrDefault(q => q.QuestionID == questionId);
                if (question != null)
                {
                    cmbCategories.SelectedItem = cmbCategories.Items.Cast<Category>().FirstOrDefault(c => c.CategoryID == question.CategoryID);
                    txtQuestionText.Text = question.QuestionText;
                    txtCorrectAnswer.Text = question.CorrectAnswer;
                    txtWrongAnswer1.Text = question.WrongAnswer1;
                    txtWrongAnswer2.Text = question.WrongAnswer2;
                    txtWrongAnswer3.Text = question.WrongAnswer3;

                    btnAddQuestion.Text = "Update Question";
                    btnCancel.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Please select a question to edit.", "No Question Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnDeleteQuestion_Click(object sender, EventArgs e)
        {
            if (dgvQuestions.SelectedRows.Count > 0)
            {
                int questionId = (int)dgvQuestions.SelectedRows[0].Cells["QuestionID"].Value;
                var result = MessageBox.Show("Are you sure you want to delete this question?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _questionService.DeleteQuestion(questionId);
                        LoadQuestions();
                        ClearFields();
                        MessageBox.Show("Question deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a question to delete.", "No Question Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            cmbCategories.SelectedIndex = -1;
            txtQuestionText.Clear();
            txtCorrectAnswer.Clear();
            txtWrongAnswer1.Clear();
            txtWrongAnswer2.Clear();
            txtWrongAnswer3.Clear();
            btnAddQuestion.Text = "Add Question";
            btnCancel.Visible = false;
        }

        private void LoadCategories()
        {
            var categories = _categoryService.GetAllCategories();
            cmbCategories.DataSource = categories;
            cmbCategories.DisplayMember = "CategoryName";
            cmbCategories.ValueMember = "CategoryID";
        }

    }
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
    public class ListBoxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

}
