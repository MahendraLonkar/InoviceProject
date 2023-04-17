using InoviceProject.Models;

namespace InoviceProject.Services.Interface
{
    public interface IProductRepository
    {
        List<ProductModel> GetAllProduct();
        ProductModel GetProductById(int product_id);
        void AddProduct(tblProduct product);
        void UpdateProduct(tblProduct product);
        void DeleteProduct(int product_id);
        List<ProductModel> SubCategoryWiseProduct(int subcategory_id);
        List<ProductModel> CategoryWiseProduct(int category_id);

        List<ProductModel> UnitWiseProduct(int unit_id);


    }
}
