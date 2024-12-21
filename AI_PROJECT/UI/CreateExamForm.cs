﻿using AI_PROJECT.BLL;
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
            _questions = _examService.GetQuestionsByCategory(categoryId);
            dgvQuestions.DataSource = _questions.Select(q => new
            {
                q.QuestionID,
                Question = q.QuestionText.Length > 50 ? q.QuestionText.Substring(0, 47) + "..." : q.QuestionText,
                IsSelected = false
            }).ToList();

            dgvQuestions.Columns["QuestionID"].Visible = false;
            dgvQuestions.Columns["IsSelected"].HeaderText = "Select";
            dgvQuestions.Columns["Question"].HeaderText = "Question";
            dgvQuestions.AutoResizeColumns();
        }

        private void btnCreateExam_Click(object sender, EventArgs e)
        {
            try
            {
                var examName = txtExamName.Text;
                var description = txtDescription.Text;
                var timeLimit = (int)numTimeLimit.Value;
                var selectedQuestionIds = new List<int>();

                foreach (DataGridViewRow row in dgvQuestions.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["IsSelected"].Value))
                    {
                        selectedQuestionIds.Add((int)row.Cells["QuestionID"].Value);
                    }
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

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvQuestions.SelectedRows.Count > 0)
            {
                int questionId = (int)dgvQuestions.SelectedRows[0].Cells["QuestionID"].Value;
                Question question = _questions.First(q => q.QuestionID == questionId);
                string details = $"Question: {question.QuestionText}\n\n" +
                                 $"Correct Answer: {question.CorrectAnswer}\n" +
                                 $"Wrong Answer 1: {question.WrongAnswer1}\n" +
                                 $"Wrong Answer 2: {question.WrongAnswer2}\n" +
                                 $"Wrong Answer 3: {question.WrongAnswer3}";
                MessageBox.Show(details, "Question Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a question to view details.", "No Question Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearFields()
        {
            txtExamName.Clear();
            txtDescription.Clear();
            numTimeLimit.Value = 60;
            cmbCategories.SelectedIndex = -1;
            dgvQuestions.DataSource = null;
        }
    }
}
