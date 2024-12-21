using AI_PROJECT.BLL;
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
  
    public partial class SelectExamForm : Form
    {
        private ExamService _examService;
        public int SelectedExamId { get; private set; }
        public SelectExamForm(ExamService examService)
        {
            InitializeComponent();
            _examService = examService;
            FormStyling.ApplyStyles(this);
            LoadExams();
        }
        private void LoadExams()
        {
            var exams = _examService.GetAllExams();
            foreach (var exam in exams)
            {
                cmbExams.Items.Add(new ComboBoxItem { Text = exam.ExamName, Value = exam.ExamID });
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (cmbExams.SelectedItem != null)
            {
                SelectedExamId = Convert.ToInt32(((ComboBoxItem)cmbExams.SelectedItem).Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select an exam.", "No Exam Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

