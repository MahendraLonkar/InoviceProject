
using InoviceProject.Models;
using InoviceProject.Services.Interface;

namespace InoviceProject.Services.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        InvoiceDBContext context;
        public CategoryRepository(InvoiceDBContext context)
        {
            this.context = context;
        }

        public void AddCategory(tblCategory category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public void DeleteCategory(int category_id)
        {
            tblCategory category = context.Categories.Find(category_id);
            context.Categories.Remove(category);
            context.SaveChanges();
        }

        public List<CategoryModel> GetCategory()
        {
            List<CategoryModel> lst= new List<CategoryModel>();
            foreach(tblCategory c in context.Categories.ToList())
            {
                CategoryModel cm = new CategoryModel()
                {
                    Category_id = c.Category_id,
                    Category_name = c.Category_name
                };
                lst.Add(cm);
            }
            return lst;
        }
        public List<CategoryModel> GetAllCategory()
        {
            return GetCategory();
        }

        public CategoryModel GetCategoryById(int category_id)
        {
            CategoryModel category = GetCategory().FirstOrDefault(e => e.Category_id.Equals(category_id));
            return category;
        }

        public void UpdateCategory(tblCategory category)
        {
            context.Categories.Update(category);
            context.SaveChanges();
        }
    }
}
