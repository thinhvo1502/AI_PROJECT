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
    public partial class CategoryForm : Form
    {
        private CategoryService _categoryService;

        public CategoryForm()
        {
            InitializeComponent();
            _categoryService = new CategoryService();
            FormStyling.ApplyStyles(this);
            LoadCategories();
        }

        private void LoadCategories()
        {
            lstCategories.Items.Clear();
            var categories = _categoryService.GetAllCategories();
            foreach (var category in categories)
            {
                lstCategories.Items.Add(category.CategoryName);
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                _categoryService.AddCategory(txtCategoryName.Text);
                LoadCategories();
                txtCategoryName.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
