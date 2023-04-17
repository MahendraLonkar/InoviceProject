using InoviceProject.Models;

namespace InoviceProject.Services.Interface
{
    public interface ICategoryRepository
    {
        List<CategoryModel> GetAllCategory();
        CategoryModel GetCategoryById(int category_id);
        void AddCategory (tblCategory category);
        void UpdateCategory (tblCategory category);
        void DeleteCategory (int category_id);
    }
}
