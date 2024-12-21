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
            FormStyling.ApplyStyles(this);
            LoadCategories();
            LoadQuestions();
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

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedCategory = (ComboBoxItem)cmbCategories.SelectedItem;
                var question = new Question
                {
                    CategoryID = (int)selectedCategory.Value,
                    QuestionText = txtQuestionText.Text,
                    CorrectAnswer = txtCorrectAnswer.Text,
                    WrongAnswer1 = txtWrongAnswer1.Text,
                    WrongAnswer2 = txtWrongAnswer2.Text,
                    WrongAnswer3 = txtWrongAnswer3.Text
                };

                if (btnAddQuestion.Text == "Update Question")
                {
                    question.QuestionID = ((Question)((ListBoxItem)lstQuestions.SelectedItem).Value).QuestionID;
                    _questionService.UpdateQuestion(question);
                    MessageBox.Show("Question updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _questionService.AddQuestion(question);
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

        private void LoadQuestions()
        {
            lstQuestions.Items.Clear();
            var questions = _questionService.GetAllQuestions();
            foreach (var question in questions)
            {
                lstQuestions.Items.Add(new ListBoxItem { Text = question.QuestionText, Value = question });
            }
        }

        private void btnViewQuestion_Click(object sender, EventArgs e)
        {
            if (lstQuestions.SelectedItem is ListBoxItem selectedItem)
            {
                var question = (Question)selectedItem.Value;
                MessageBox.Show($"Question: {question.QuestionText}\n\n" +
                                $"Correct Answer: {question.CorrectAnswer}\n" +
                                $"Wrong Answer 1: {question.WrongAnswer1}\n" +
                                $"Wrong Answer 2: {question.WrongAnswer2}\n" +
                                $"Wrong Answer 3: {question.WrongAnswer3}",
                                "Question Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a question to view.", "No Question Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditQuestion_Click(object sender, EventArgs e)
        {
            if (lstQuestions.SelectedItem is ListBoxItem selectedItem)
            {
                var question = (Question)selectedItem.Value;
                PopulateFields(question);
            }
            else
            {
                MessageBox.Show("Please select a question to edit.", "No Question Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteQuestion_Click(object sender, EventArgs e)
        {
            if (lstQuestions.SelectedItem is ListBoxItem selectedItem)
            {
                var question = (Question)selectedItem.Value;
                var result = MessageBox.Show($"Are you sure you want to delete the question:\n\n{question.QuestionText}",
                                             "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _questionService.DeleteQuestion(question.QuestionID);
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

        private void PopulateFields(Question question)
        {
            cmbCategories.SelectedItem = cmbCategories.Items.Cast<ComboBoxItem>().FirstOrDefault(item => (int)item.Value == question.CategoryID);
            txtQuestionText.Text = question.QuestionText;
            txtCorrectAnswer.Text = question.CorrectAnswer;
            txtWrongAnswer1.Text = question.WrongAnswer1;
            txtWrongAnswer2.Text = question.WrongAnswer2;
            txtWrongAnswer3.Text = question.WrongAnswer3;
            btnAddQuestion.Text = "Update Question";
            btnCancel.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadQuestions();
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
