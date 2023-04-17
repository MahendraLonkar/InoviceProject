using InoviceProject.Models;

namespace InoviceProject.Services.Interface
{
    public interface IProductReceivedStockRepository
    {
        List<Product_received_stock_Model> GetProduct_received_stock();
        void AddReceivedStock(tblReceived_details received_Stock);
        void UpdateReceivedStock(tblReceived_details received_Stock);
        void DeleteReceivedStock(int received_Stock_id);
        Product_received_stock_Model GetReceivedStockById(int received_Stock_id);
        List<Product_received_stock_Model> OrderWiseReceivedStock(int order_id);
       
    }
}
