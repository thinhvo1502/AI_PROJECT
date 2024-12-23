using AI_PROJECT.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AI_PROJECT.BLL;
using AI_PROJECT.DAL.Models;
using AI_PROJECT.UI;
using System.Drawing.Imaging;

namespace AI_PROJECT
{
    public partial class MainForm : Form
    {
       private System.ComponentModel.IContainer components = null;
        private UserService _userService;
        private ExamService _examService;

        public MainForm(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
            _examService = new ExamService();
            ApplyCustomStyles();
            UpdateButtonVisibility();
        }
        private void ApplyCustomStyles()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            foreach (Control control in pnlSidebar.Controls)
            {
                if (control is Button)
                {
                    ((Button)control).FlatAppearance.MouseOverBackColor = Color.FromArgb(44, 62, 80);
                    ((Button)control).FlatAppearance.MouseDownBackColor = Color.FromArgb(52, 73, 94);
                    ((Button)control).Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    ((Button)control).Cursor = Cursors.Hand;
                    ((Button)control).Image = GetButtonIcon(control.Name);
                    ((Button)control).ImageAlign = ContentAlignment.MiddleLeft;
                    ((Button)control).TextAlign = ContentAlignment.MiddleLeft;
                    ((Button)control).TextImageRelation = TextImageRelation.ImageBeforeText;
                    ((Button)control).Padding = new Padding(10, 0, 0, 0);
/*                    ((Button)control).ImageScaling = ToolStripItemImageScaling.None;
*/                }
            }
        }

        private Image GetButtonIcon(string buttonName)
        {
            Image originalImage = null;
            switch (buttonName)
            {
                case "btnManageCategories":
                    originalImage = Properties.Resources.CategoryIcon;
                    break;
                case "btnManageQuestions":
                    originalImage = Properties.Resources.QuestionIcon;
                    break;
                case "btnCreateExam":
                    originalImage = Properties.Resources.CreateExamIcon;
                    break;
                case "btnTakeExam":
                    originalImage = Properties.Resources.TakeExamIcon;
                    break;
                case "btnExamHistory":
                    originalImage = Properties.Resources.HistoryIcon;
                    break;
                case "btnEditExam":
                    originalImage = Properties.Resources.EditIcon;
                    break;
                case "btnDeleteExam":
                    originalImage = Properties.Resources.DeleteIcon;
                    break;
                default:
                    return null;
            }

            return originalImage != null ? ResizeImage(originalImage, 24, 24) : null;
        }

        private Image ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void UpdateButtonVisibility()
        {
            bool isAdmin = _userService.IsAdmin();
            btnManageCategories.Visible = isAdmin;
            btnManageQuestions.Visible = isAdmin;
            btnCreateExam.Visible = isAdmin;
            btnTakeExam.Visible = true;
            btnExamHistory.Visible = true;
            btnEditExam.Visible = isAdmin;
            btnDeleteExam.Visible = isAdmin;
        }

        private void btnManageCategories_Click(object sender, EventArgs e)
        {
            if (_userService.IsAdmin())
            {
                var categoryForm = new CategoryForm();
                categoryForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You don't have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnManageQuestions_Click(object sender, EventArgs e)
        {
            if (_userService.IsAdmin())
            {
                var questionForm = new QuestionForm();
                questionForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You don't have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCreateExam_Click(object sender, EventArgs e)
        {
            if (_userService.IsAdmin())
            {
                var createExamForm = new CreateExamForm();
                createExamForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You don't have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTakeExam_Click(object sender, EventArgs e)
        {
            var takeExamForm = new TakeExamForm(_userService);
            takeExamForm.ShowDialog();
        }

        private void btnExamHistory_Click(object sender, EventArgs e)
        {
            var examHistoryForm = new ExamHistoryForm(_userService);
            examHistoryForm.ShowDialog();
        }

        private void btnEditExam_Click(object sender, EventArgs e)
        {
            if (_userService.IsAdmin())
            {
                var selectExamForm = new SelectExamForm(_examService);
                if (selectExamForm.ShowDialog() == DialogResult.OK)
                {
                    var editExamForm = new EditExamForm(selectExamForm.SelectedExamId);
                    editExamForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("You don't have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteExam_Click(object sender, EventArgs e)
        {
            if (_userService.IsAdmin())
            {
                var selectExamForm = new SelectExamForm(_examService);
                if (selectExamForm.ShowDialog() == DialogResult.OK)
                {
                    var result = MessageBox.Show("Are you sure you want to delete this exam? This action cannot be undone.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            _examService.DeleteExam(selectExamForm.SelectedExamId);
                            MessageBox.Show("Exam deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred while deleting the exam: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("You don't have permission to access this feature.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




    }
}
