using InoviceProject.Models;

namespace InoviceProject.Services.Interface
{
    public interface IOrder_detailsRepository
    {
        List<Order_details_Model> GetAllOrder();
        Order_details_Model GetOrderById(int order_id);
        void AddOrder(tblOrder_details order);

        void UpdateOrder(tblOrder_details order);

        void DeleteOrder(int order_id);
        Order_details_Model GetOrderwiseVendorId(int vendor_id);

        
    }
}
