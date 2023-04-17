using InoviceProject.Models;

namespace InoviceProject.Services.Interface
{
    public interface ISubCategoryRepository
    {
        List<SubCategoryModel> GetAllSubCategory();
        SubCategoryModel GetSubCategoryById(int subcategory_id);
        void AddSubCategory (tblSubCategory subcategory);
        void UpdateSubCategory (tblSubCategory subcategory);
        void DeleteSubCategory (int subcategory_id);
        List<SubCategoryModel> GetCategoryWiseSubCategory(int category_id);
    }
}
