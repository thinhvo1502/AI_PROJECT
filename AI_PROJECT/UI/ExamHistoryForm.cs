using AI_PROJECT.BLL;
using AI_PROJECT.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AI_PROJECT.UI
{
    public partial class ExamHistoryForm : Form
    {
        private ExamService _examService;
        private UserService _userService;
        private List<ExamHistory> _examHistories;

        public ExamHistoryForm(UserService userService)
        {
            InitializeComponent();
            _examService = new ExamService();
            _userService = userService;
            FormStyling.ApplyStyles(this);
            LoadExamHistory();
        }

        private void LoadExamHistory()
        {
            _examHistories = _examService.GetExamHistoryByUser(_userService.CurrentUser.UserID);
            UpdateDataGridView();
            CreateScoreOverTimeChart();
            CreateAverageScoreByExamChart();
        }

        private void UpdateDataGridView()
        {
            var dataSource = _examHistories.Select(h => new
            {
                ExamName = _examService.GetExamById(h.ExamID).ExamName,
                h.Score,
                h.DateTaken,
                TimeTaken = TimeSpan.FromSeconds(h.TimeTaken).ToString(@"hh\:mm\:ss")
            }).ToList();

            switch (cmbSortBy.SelectedIndex)
            {
                case 1: // Date (Oldest First)
                    dataSource = dataSource.OrderBy(x => x.DateTaken).ToList();
                    break;
                case 2: // Score (Highest First)
                    dataSource = dataSource.OrderByDescending(x => x.Score).ToList();
                    break;
                case 3: // Score (Lowest First)
                    dataSource = dataSource.OrderBy(x => x.Score).ToList();
                    break;
                default: // Date (Newest First)
                    dataSource = dataSource.OrderByDescending(x => x.DateTaken).ToList();
                    break;
            }

            dgvExamHistory.DataSource = dataSource;

            // Add ProgressBar column for Score
            if (!dgvExamHistory.Columns.Contains("ScoreProgressBar"))
            {
                var progressColumn = new DataGridViewProgressColumn();
                progressColumn.HeaderText = "Progress";
                progressColumn.Name = "ScoreProgressBar";
                progressColumn.Width = 100;
                progressColumn.DataPropertyName = "Score"; // Thêm dòng này
                dgvExamHistory.Columns.Add(progressColumn);
            }

            // Add text column for highest score
            if (!dgvExamHistory.Columns.Contains("HighestScore"))
            {
                var highestScoreColumn = new DataGridViewTextBoxColumn();
                highestScoreColumn.HeaderText = "Highest";
                highestScoreColumn.Name = "HighestScore";
                highestScoreColumn.Width = 50;
                dgvExamHistory.Columns.Add(highestScoreColumn);
            }
        }
        private void dgvExamHistory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvExamHistory.Columns["ScoreProgressBar"].Index && e.RowIndex >= 0)
            {
                if (e.Value != null)
                {
                    e.Value = Convert.ToInt32(e.Value);
                    e.FormattingApplied = true;
                }
            }
            else if (e.ColumnIndex == dgvExamHistory.Columns["HighestScore"].Index && e.RowIndex >= 0)
            {
                int currentScore = Convert.ToInt32(dgvExamHistory.Rows[e.RowIndex].Cells["Score"].Value);
                int maxScore = _examHistories.Max(h => h.Score);
                if (currentScore == maxScore)
                {
                    e.Value = "🏅";
                }
                else
                {
                    e.Value = string.Empty;
                }
            }
            else if (e.ColumnIndex == dgvExamHistory.Columns["Score"].Index && e.RowIndex >= 0)
            {
                int score = Convert.ToInt32(e.Value);
                if (score >= 80)
                    e.CellStyle.ForeColor = Color.Green;
                else if (score >= 60)
                    e.CellStyle.ForeColor = Color.Orange;
                else
                    e.CellStyle.ForeColor = Color.Red;
            }
        }

        private void CreateScoreOverTimeChart()
        {
            chartScoreOverTime.Series.Clear();
            chartScoreOverTime.ChartAreas.Clear();

            var chartArea = new ChartArea();
            chartScoreOverTime.ChartAreas.Add(chartArea);

            var series = new Series
            {
                Name = "Score",
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8
            };

            foreach (var history in _examHistories.OrderBy(h => h.DateTaken))
            {
                series.Points.AddXY(history.DateTaken, history.Score);
            }

            chartScoreOverTime.Series.Add(series);
            chartScoreOverTime.Titles.Add("Score Over Time");
            chartArea.AxisX.Title = "Date";
            chartArea.AxisY.Title = "Score";
            chartArea.AxisX.LabelStyle.Format = "dd/MM/yyyy";
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = 100;
        }

        private void CreateAverageScoreByExamChart()
        {
            chartAverageScoreByExam.Series.Clear();
            chartAverageScoreByExam.ChartAreas.Clear();

            var chartArea = new ChartArea();
            chartAverageScoreByExam.ChartAreas.Add(chartArea);

            var series = new Series
            {
                Name = "Average Score",
                ChartType = SeriesChartType.Column
            };

            var examScores = _examHistories
                .GroupBy(h => h.ExamID)
                .Select(g => new { ExamName = _examService.GetExamById(g.Key).ExamName, AverageScore = g.Average(h => h.Score) })
                .OrderByDescending(x => x.AverageScore)
                .ToList();

            foreach (var examScore in examScores)
            {
                var point = series.Points.AddXY(examScore.ExamName, examScore.AverageScore);
                if (examScore.AverageScore >= 80)
                    series.Points[point].Color = Color.Green;
                else if (examScore.AverageScore >= 60)
                    series.Points[point].Color = Color.Orange;
                else
                    series.Points[point].Color = Color.Red;
            }

            chartAverageScoreByExam.Series.Add(series);
            chartAverageScoreByExam.Titles.Add("Average Score by Exam");
            chartArea.AxisX.Title = "Exam";
            chartArea.AxisY.Title = "Average Score";
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.LabelStyle.Angle = -45;
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = 100;
        }

        private void cmbSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void chartScoreOverTime_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            var result = chartScoreOverTime.HitTest(pos.X, pos.Y, false);
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                var prop = result.Object as DataPoint;
                if (prop != null)
                {
                    var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                    var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                    var examHistory = _examHistories.OrderBy(h => h.DateTaken).ElementAt(result.PointIndex);
                    var exam = _examService.GetExamById(examHistory.ExamID);
                    var tooltip = $"Date: {examHistory.DateTaken:dd/MM/yyyy}\nExam: {exam.ExamName}\nScore: {examHistory.Score}%\nTime Taken: {TimeSpan.FromSeconds(examHistory.TimeTaken):hh\\:mm\\:ss}";

                    var toolTip = new ToolTip();
                    toolTip.Show(tooltip, chartScoreOverTime, (int)pointXPixel, (int)pointYPixel - 15, 5000);
                }
            }
        }
    }

    public class DataGridViewProgressColumn : DataGridViewTextBoxColumn
    {
        public DataGridViewProgressColumn()
        {
            CellTemplate = new DataGridViewProgressCell();
        }
    }

    public class DataGridViewProgressCell : DataGridViewTextBoxCell
    {
        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            if (value is int intValue)
            {
                return intValue;
            }
            return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            if (value != null && int.TryParse(value.ToString(), out int progressVal))
            {
                // Draw background
                using (var backColorBrush = new SolidBrush(cellStyle.BackColor))
                {
                    graphics.FillRectangle(backColorBrush, cellBounds);
                }

                // Calculate progress width
                Rectangle progressRect = cellBounds;
                progressRect.Width = Convert.ToInt32((progressRect.Width * progressVal) / 100);

                // Choose color based on progress value
                Color progressColor;
                if (progressVal >= 80)
                    progressColor = Color.Green;
                else if (progressVal >= 60)
                    progressColor = Color.Orange;
                else
                    progressColor = Color.Red;

                // Draw progress bar
                using (var progressBrush = new SolidBrush(progressColor))
                {
                    graphics.FillRectangle(progressBrush, progressRect);
                }

                // Draw progress text
                string progressText = $"{progressVal}%";
                using (var textBrush = new SolidBrush(Color.Black))
                {
                    var textSize = graphics.MeasureString(progressText, cellStyle.Font);
                    var textLocation = new PointF(
                        cellBounds.X + (cellBounds.Width - textSize.Width) / 2,
                        cellBounds.Y + (cellBounds.Height - textSize.Height) / 2
                    );
                    graphics.DrawString(progressText, cellStyle.Font, textBrush, textLocation);
                }
            }
            else
            {
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            }
        }
    }
}
