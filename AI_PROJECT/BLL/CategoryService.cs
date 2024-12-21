using AI_PROJECT.DAL.Models;
using AI_PROJECT.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_PROJECT.BLL
{
    public class CategoryService
    {
        private CategoryRepository _categoryRepository;

        public CategoryService()
        {
            _categoryRepository = new CategoryRepository();
        }

        public List<Category> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        public void AddCategory(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                throw new ArgumentException("Category name cannot be empty.");
            }
            var category = new Category { CategoryName = categoryName };
            _categoryRepository.AddCategory(category);
        }

        public Category GetCategoryById(int categoryId)
        {
            return _categoryRepository.GetCategoryById(categoryId);
        }

        public void UpdateCategory(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.CategoryName))
            {
                throw new ArgumentException("Category name cannot be empty.");
            }
            _categoryRepository.UpdateCategory(category);
        }

        public void DeleteCategory(int categoryId)
        {
            try
            {
                _categoryRepository.DeleteCategoryAndRelatedRecords(categoryId);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the category. It may be in use in an exam.", ex);
            }
        }
    }
}
