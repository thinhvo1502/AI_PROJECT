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
            FormStyling.ApplyStyles(this);
            LoadExamData();
        }
        private void LoadExamData()
        {
            txtExamName.Text = _currentExam.ExamName;
            txtDescription.Text = _currentExam.Description;
            numTimeLimit.Value = _currentExam.TimeLimit;

            var examQuestions = _examService.GetExamQuestions(_currentExam.ExamID);
            dgvQuestions.DataSource = _allQuestions.Select(q => new
            {
                q.QuestionID,
                Question = q.QuestionText.Length > 50 ? q.QuestionText.Substring(0, 47) + "..." : q.QuestionText,
                IsSelected = examQuestions.Any(eq => eq.QuestionID == q.QuestionID)
            }).ToList();

            dgvQuestions.Columns["QuestionID"].Visible = false;
            dgvQuestions.Columns["IsSelected"].HeaderText = "Select";
            dgvQuestions.Columns["Question"].HeaderText = "Question";
            dgvQuestions.AutoResizeColumns();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedQuestionIds = new List<int>();
                foreach (DataGridViewRow row in dgvQuestions.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["IsSelected"].Value))
                    {
                        selectedQuestionIds.Add((int)row.Cells["QuestionID"].Value);
                    }
                }

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
                int questionId = (int)dgvQuestions.SelectedRows[0].Cells["QuestionID"].Value;
                Question question = _allQuestions.First(q => q.QuestionID == questionId);
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
    }
}
