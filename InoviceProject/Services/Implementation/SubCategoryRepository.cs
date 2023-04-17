using InoviceProject.Models;
using InoviceProject.Services.Interface;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InoviceProject.Services.Implementation
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        InvoiceDBContext context;
        public SubCategoryRepository(InvoiceDBContext context)
        {
            this.context = context;
        }
        public void AddSubCategory(tblSubCategory subcategory)
        {
            
            context.SubCategories.Add(subcategory);
            context.SaveChanges();
        }

        public void DeleteSubCategory(int category_id)
        {
            tblSubCategory subCategory = context.SubCategories.Find(category_id);
            context.SubCategories.Remove(subCategory);
            context.SaveChanges();
        }

        public List<SubCategoryModel> GetSubCategories()
        {
            List<SubCategoryModel> lst = new List<SubCategoryModel>();
            foreach(tblSubCategory category in context.SubCategories.ToList())
            {
                tblCategory c = context.Categories.Find(category.Category_id);
                SubCategoryModel sm = new SubCategoryModel()
                {
                    SubCategory_id = category.SubCategory_id,
                    SubCategory_name = category.SubCategory_name,
                    Category_id = (int)category.Category_id,
                   Category_name = c.Category_name
                };
                lst.Add(sm);
            }
            return lst;
        }
        public List<SubCategoryModel> GetAllSubCategory()
        {
            return GetSubCategories();
        }

        public SubCategoryModel GetSubCategoryById(int subcategory_id)
        {
            SubCategoryModel subCategory = GetSubCategories().FirstOrDefault(e => e.SubCategory_id.Equals(subcategory_id));
            return subCategory;
        }

        public void UpdateSubCategory(tblSubCategory subcategory)
        {
            context.SubCategories.Update(subcategory);
            context.SaveChanges();
        }

        public List<SubCategoryModel> GetCategoryWiseSubCategory(int category_id)
        {
            return GetSubCategories().Where(e => e.Category_id.Equals(category_id)).ToList();
        }
    }
}
