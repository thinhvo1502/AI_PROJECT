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
                lstCategories.Items.Add(new ListBoxItem { Text = category.CategoryName, Value = category });
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnAddCategory.Text == "Update Category")
                {
                    var selectedCategory = (Category)((ListBoxItem)lstCategories.SelectedItem).Value;
                    selectedCategory.CategoryName = txtCategoryName.Text;
                    _categoryService.UpdateCategory(selectedCategory);
                    MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _categoryService.AddCategory(txtCategoryName.Text);
                    MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ClearFields();
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewCategory_Click(object sender, EventArgs e)
        {
            if (lstCategories.SelectedItem is ListBoxItem selectedItem)
            {
                var category = (Category)selectedItem.Value;
                MessageBox.Show($"Category ID: {category.CategoryID}\nCategory Name: {category.CategoryName}",
                                "Category Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a category to view.", "No Category Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            if (lstCategories.SelectedItem is ListBoxItem selectedItem)
            {
                var category = (Category)selectedItem.Value;
                txtCategoryName.Text = category.CategoryName;
                btnAddCategory.Text = "Update Category";
                btnCancel.Visible = true;
            }
            else
            {
                MessageBox.Show("Please select a category to edit.", "No Category Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (lstCategories.SelectedItem is ListBoxItem selectedItem)
            {
                var category = (Category)selectedItem.Value;
                var result = MessageBox.Show($"Are you sure you want to delete the category:\n\n{category.CategoryName}\n\nThis will also delete all questions in this category.",
                                             "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _categoryService.DeleteCategory(category.CategoryID);
                        LoadCategories();
                        ClearFields();
                        MessageBox.Show("Category and related questions deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a category to delete.", "No Category Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtCategoryName.Clear();
            btnAddCategory.Text = "Add Category";
            btnCancel.Visible = false;
        }
    }

}
