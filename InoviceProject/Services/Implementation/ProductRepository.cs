using InoviceProject.Models;
using InoviceProject.Services.Interface;

namespace InoviceProject.Services.Implementation
{
    public class ProductRepository : IProductRepository
    {
        InvoiceDBContext context;
        public ProductRepository(InvoiceDBContext context)
        {
            this.context = context;
        }
        public void AddProduct(tblProduct product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void DeleteProduct(int product_id)
        {
            tblProduct product = context.Products.Find(product_id);
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public List<ProductModel> GetProduct()
        {
            List<ProductModel> lst = new List<ProductModel>();
            foreach (tblProduct p in context.Products.ToList())
            {
                tblSubCategory sc = context.SubCategories.Find(p.SubCategory_id);
                tblUnit u = context.Units.Find(p.Unit_id);

                ProductModel pm = new ProductModel()
                {
                    Product_id = p.Product_id,
                    Product_name = p.Product_name,
                    SubCategory_id= p.SubCategory_id,
                    SubCategory_Name=sc.SubCategory_name,
                    Unit_id= p.Unit_id,
                    Unit_Name=u.Unit_name,
                    Weight=p.Weight,
                    Stock_quantity=p.Stock_quantity,
                    Tax=p.Tax,
                    Selling_rate=p.Selling_rate
                };
                lst.Add(pm);
            }
            return lst;
        }
        public List<ProductModel> GetAllProduct()
        {
            return GetProduct();
        }

        public ProductModel GetProductById(int product_id)
        {
            ProductModel product = GetProduct().FirstOrDefault(e => e.Product_id.Equals(product_id));
            return product;
        }

        public List<ProductModel> SubCategoryWiseProduct(int subcategory_id)
        {
            return GetProduct().Where(e => e.SubCategory_id.Equals(subcategory_id)).ToList();
        }

        public List<ProductModel> UnitWiseProduct(int unit_id)
        {
            return GetProduct().Where(e => e.Unit_id.Equals(unit_id)).ToList();
        }

        public void UpdateProduct(tblProduct product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }

        public List<ProductModel> CategoryWiseProduct(int category_id)
        {
            return GetProduct().Where(e=>e.category_id.Equals(category_id)).ToList();
        }
    }
}
