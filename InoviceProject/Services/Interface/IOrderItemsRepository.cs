using InoviceProject.Models;

namespace InoviceProject.Services.Interface
{
    public interface IOrderItemsRepository
    {
        List<order_items_Model> GetAllOrdersItems();
        void AddOrderItem(tblOrder_items order_item);
        void UpdateOrderItem(tblOrder_items order_item);
        void DeleteOrderItem(int order_item_id);
        order_items_Model GetOrderItemById(int order_item_id);
        List<order_items_Model> OrderWiseProductId(int order_id);
        

    }
}
