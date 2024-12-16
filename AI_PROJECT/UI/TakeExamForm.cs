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
    public partial class TakeExamForm : Form
    {
        private ExamService _examService;
        private List<Question> _examQuestions;
        private int _currentQuestionIndex;
        private Dictionary<int, string> _userAnswers;
        private Timer _examTimer;
        private int _remainingTime;
        private Exam _currentExam;

        public TakeExamForm()
        {
            InitializeComponent();
            _examService = new ExamService();
            _userAnswers = new Dictionary<int, string>();
            FormStyling.ApplyStyles(this);
        }


        private void TakeExamForm_Load(object sender, EventArgs e)
        {
            LoadExams();
        }

        private void LoadExams()
        {
            cmbExams.Items.Clear();
            var exams = _examService.GetAllExams();
            foreach (var exam in exams)
            {
                cmbExams.Items.Add(new ComboBoxItem
                {
                    Text = $"{exam.ExamName} - Time Limit: {exam.TimeLimit} minutes",
                    Value = exam
                });
            }
        }

        private void btnStartExam_Click(object sender, EventArgs e)
        {
            if (cmbExams.SelectedItem is ComboBoxItem selectedExam)
            {
                _currentExam = (Exam)selectedExam.Value;
                lblExamName.Text = _currentExam.ExamName;
                _examQuestions = _examService.GetExamQuestions(_currentExam.ExamID);
                if (_examQuestions.Count == 0)
                {
                    MessageBox.Show("No questions found for this exam.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _currentQuestionIndex = 0;
                _userAnswers.Clear();
                StartExamTimer();
                DisplayQuestion();
                ToggleExamControls(true);
            }
            else
            {
                MessageBox.Show("Please select an exam to start.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartExamTimer()
        {
            _remainingTime = _currentExam.TimeLimit * 60; // Convert minutes to seconds
            _examTimer = new Timer();
            _examTimer.Interval = 1000; // 1 second
            _examTimer.Tick += ExamTimer_Tick;
            _examTimer.Start();
            UpdateTimerDisplay();
        }

        private void ExamTimer_Tick(object sender, EventArgs e)
        {
            _remainingTime--;
            UpdateTimerDisplay();

            if (_remainingTime <= 0)
            {
                _examTimer.Stop();
                MessageBox.Show("Time's up! The exam will now be submitted.", "Exam Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SubmitExam();
            }
        }

        private void UpdateTimerDisplay()
        {
            int minutes = _remainingTime / 60;
            int seconds = _remainingTime % 60;
            lblTimer.Text = $"Time Left: {minutes:D2}:{seconds:D2}";
        }

        private void ToggleExamControls(bool visible)
        {
            lblQuestion.Visible = visible;
            rbAnswer1.Visible = visible;
            rbAnswer2.Visible = visible;
            rbAnswer3.Visible = visible;
            rbAnswer4.Visible = visible;
            btnPrevious.Visible = visible;
            btnNext.Visible = visible;
            btnSubmit.Visible = visible;
            lblTimer.Visible = visible;
            lblExamName.Visible = visible;

            lblTitle.Visible = !visible;
            lblSelectExam.Visible = !visible;
            cmbExams.Visible = !visible;
            btnStartExam.Visible = !visible;
        }

        private void DisplayQuestion()
        {
            var question = _examQuestions[_currentQuestionIndex];
            lblQuestion.Text = question.QuestionText;
            rbAnswer1.Text = question.CorrectAnswer;
            rbAnswer2.Text = question.WrongAnswer1;
            rbAnswer3.Text = question.WrongAnswer2;
            rbAnswer4.Text = question.WrongAnswer3;

            // Shuffle the answer options
            var random = new Random();
            for (int i = 0; i < 4; i++)
            {
                int j = random.Next(i, 4);
                var temp = Controls["rbAnswer" + (i + 1)].Text;
                Controls["rbAnswer" + (i + 1)].Text = Controls["rbAnswer" + (j + 1)].Text;
                Controls["rbAnswer" + (j + 1)].Text = temp;
            }

            // Clear previous selection
            rbAnswer1.Checked = rbAnswer2.Checked = rbAnswer3.Checked = rbAnswer4.Checked = false;

            // Restore user's previous answer if exists
            if (_userAnswers.TryGetValue(question.QuestionID, out string previousAnswer))
            {
                for (int i = 1; i <= 4; i++)
                {
                    if (Controls["rbAnswer" + i].Text == previousAnswer)
                    {
                        ((RadioButton)Controls["rbAnswer" + i]).Checked = true;
                        break;
                    }
                }
            }

            btnPrevious.Enabled = _currentQuestionIndex > 0;
            btnNext.Enabled = _currentQuestionIndex < _examQuestions.Count - 1;
            btnSubmit.Visible = _currentQuestionIndex == _examQuestions.Count - 1;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            SaveAnswer();
            _currentQuestionIndex--;
            DisplayQuestion();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            SaveAnswer();
            _currentQuestionIndex++;
            DisplayQuestion();
        }

        private void SaveAnswer()
        {
            var question = _examQuestions[_currentQuestionIndex];
            for (int i = 1; i <= 4; i++)
            {
                if (((RadioButton)Controls["rbAnswer" + i]).Checked)
                {
                    _userAnswers[question.QuestionID] = Controls["rbAnswer" + i].Text;
                    break;
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveAnswer();
            SubmitExam();
        }

        private void SubmitExam()
        {
            _examTimer.Stop();
            int score = _examService.CalculateScore(_currentExam.ExamID, _userAnswers);
            MessageBox.Show($"Your score: {score}%", "Exam Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ToggleExamControls(false);
            LoadExams();
        }
    }

}
