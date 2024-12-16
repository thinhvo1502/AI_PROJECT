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

                _questionService.AddQuestion(question);
                MessageBox.Show("Question added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtQuestionText.Clear();
            txtCorrectAnswer.Clear();
            txtWrongAnswer1.Clear();
            txtWrongAnswer2.Clear();
            txtWrongAnswer3.Clear();
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

}
