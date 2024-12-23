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
    public partial class EditExamForm : Form
    {
        private ExamService _examService;
        private Exam _currentExam;
        private List<Question> _allQuestions;

        public EditExamForm(int examId)
        {
            InitializeComponent();
            _examService = new ExamService();
            _currentExam = _examService.GetExamById(examId);
            _allQuestions = _examService.GetAllQuestions();
            ApplyCustomStyles();
            LoadExamData();
        }
        private void ApplyCustomStyles()
        {
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);

            foreach (Control control in this.pnlMain.Controls)
            {
                if (control is Button)
                {
                    ((Button)control).FlatStyle = FlatStyle.Flat;
                    ((Button)control).FlatAppearance.BorderSize = 0;
                    ((Button)control).Cursor = Cursors.Hand;
                }
            }

            dgvQuestions.BorderStyle = BorderStyle.None;
            dgvQuestions.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvQuestions.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvQuestions.DefaultCellStyle.SelectionBackColor = Color.FromArgb(87, 166, 74);
            dgvQuestions.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvQuestions.RowHeadersVisible = false;
            dgvQuestions.EnableHeadersVisualStyles = false;
            dgvQuestions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvQuestions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvQuestions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvQuestions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }

        private void LoadExamData()
        {
            txtExamName.Text = _currentExam.ExamName;
            txtDescription.Text = _currentExam.Description;
            numTimeLimit.Value = _currentExam.TimeLimit;

            _allQuestions = _examService.GetAllQuestions();
            var examQuestions = _examService.GetExamQuestions(_currentExam.ExamID);

            dgvQuestions.DataSource = null;
            dgvQuestions.Columns.Clear();
            dgvQuestions.AutoGenerateColumns = false;

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Select";
            checkBoxColumn.Name = "IsSelected";
            checkBoxColumn.Width = 60;
            dgvQuestions.Columns.Add(checkBoxColumn);

            DataGridViewTextBoxColumn questionColumn = new DataGridViewTextBoxColumn();
            questionColumn.DataPropertyName = "QuestionText";
            questionColumn.HeaderText = "Question";
            questionColumn.Name = "Question";
            questionColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvQuestions.Columns.Add(questionColumn);

            var dataSource = _allQuestions.Select(q => new QuestionViewModel
            {
                QuestionID = q.QuestionID,
                QuestionText = q.QuestionText,
                IsSelected = examQuestions.Any(eq => eq.QuestionID == q.QuestionID)
            }).ToList();

            dgvQuestions.DataSource = dataSource;

            // Bind the IsSelected property to the checkbox column
            dgvQuestions.Columns["IsSelected"].DataPropertyName = "IsSelected";
        }

        public class QuestionViewModel
        {
            public int QuestionID { get; set; }
            public string QuestionText { get; set; }
            public bool IsSelected { get; set; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var dataSource = (List<QuestionViewModel>)dgvQuestions.DataSource;
                var selectedQuestionIds = dataSource.Where(q => q.IsSelected).Select(q => q.QuestionID).ToList();

                _examService.UpdateExam(
                    _currentExam.ExamID,
                    txtExamName.Text,
                    txtDescription.Text,
                    (int)numTimeLimit.Value,
                    selectedQuestionIds
                );

                MessageBox.Show("Exam updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvQuestions.SelectedRows.Count > 0)
            {
                var selectedQuestion = (QuestionViewModel)dgvQuestions.SelectedRows[0].DataBoundItem;
                Question question = _allQuestions.First(q => q.QuestionID == selectedQuestion.QuestionID);
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

        private void dgvQuestions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvQuestions.Columns["IsSelected"].Index && e.RowIndex >= 0)
            {
                dgvQuestions.EndEdit();
                var dataSource = (List<QuestionViewModel>)dgvQuestions.DataSource;
                dataSource[e.RowIndex].IsSelected = !dataSource[e.RowIndex].IsSelected;
                dgvQuestions.InvalidateRow(e.RowIndex);
            }
        }
    }
    }
