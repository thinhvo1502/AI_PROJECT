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
            ApplyCustomStyles();
            LoadCategories();
        }
        private void ApplyCustomStyles()
        {
            this.BackColor = Color.FromArgb(240, 240, 240);

            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).BorderStyle = BorderStyle.FixedSingle;
                }
                else if (control is Button)
                {
                    ((Button)control).FlatStyle = FlatStyle.Flat;
                    ((Button)control).FlatAppearance.BorderSize = 0;
                    ((Button)control).Cursor = Cursors.Hand;
                }
            }

            dgvQuestions.BorderStyle = BorderStyle.None;
            dgvQuestions.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgvQuestions.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvQuestions.DefaultCellStyle.SelectionBackColor = Color.FromArgb(208, 225, 243);
            dgvQuestions.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvQuestions.EnableHeadersVisualStyles = false;
            dgvQuestions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvQuestions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 150, 136);
            dgvQuestions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
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
            // Reset DataGridView
            dgvQuestions.DataSource = null;
            dgvQuestions.Rows.Clear();

            // Lấy dữ liệu câu hỏi từ dịch vụ
            _questions = _examService.GetQuestionsByCategory(categoryId);

            // Cập nhật lại DataSource
            dgvQuestions.DataSource = _questions.Select(q => new
            {
                q.QuestionID,
                Question = q.QuestionText,
            }).ToList();

            // Ẩn cột "QuestionID" và thay đổi tên cột "Question"
            dgvQuestions.Columns["QuestionID"].Visible = false;
            dgvQuestions.Columns["Question"].HeaderText = "Question";

            // Kiểm tra xem cột "Select" đã tồn tại chưa
            if (!dgvQuestions.Columns.Contains("IsSelected"))
            {
                // Thêm cột checkbox vào đầu DataGridView
                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                checkBoxColumn.HeaderText = "Select";
                checkBoxColumn.Name = "IsSelected";
                dgvQuestions.Columns.Insert(0, checkBoxColumn);
            }

            // Tự động điều chỉnh kích thước cột
            dgvQuestions.AutoResizeColumns();
        }

        private void dgvQuestions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvQuestions.Columns["IsSelected"].Index && e.RowIndex >= 0)
            {
                dgvQuestions.EndEdit();
                dgvQuestions.Rows[e.RowIndex].Cells["IsSelected"].Value = !Convert.ToBoolean(dgvQuestions.Rows[e.RowIndex].Cells["IsSelected"].Value);
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
