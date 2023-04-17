using InoviceProject.Models;
using InoviceProject.Services.Interface;

namespace InoviceProject.Services.Implementation
{
    public class OrderItemsRepository:IOrderItemsRepository
    {
        InvoiceDBContext context;
        public OrderItemsRepository(InvoiceDBContext context)
        {
            this.context = context;
        }

        public void AddOrderItem(tblOrder_items order_item)
        {
            context.OrderItems.Add(order_item);
            context.SaveChanges();
        }
        public void DeleteOrderItem(int order_item_id)
        {
            tblOrder_items items = context.OrderItems.Find(order_item_id);
            context.OrderItems.Remove(items);
            context.SaveChanges();
        }

        public List<order_items_Model> GetOrdersItems()
        {
            List<order_items_Model> lst = new List<order_items_Model>();
            foreach (tblOrder_items Order_item in context.OrderItems.ToList())
            {

                tblProduct p = context.Products.Find(Order_item.Product_id);
                tblSubCategory sc = context.SubCategories.Find(p.SubCategory_id);
                order_items_Model pso = new order_items_Model()
                {
                    orderitem_id = Order_item.orderitem_id,
                    order_id= Order_item.order_id,
                    product_id = Order_item.Product_id,
                    product_name = p.Product_name,
                    selling_rate=p.Selling_rate,
                    Order_quantity = Order_item.Order_quantity,
                };
                
                lst.Add(pso);
            }
            return lst;
        }

        public List<order_items_Model> GetAllOrdersItems()
        {
            return GetOrdersItems();
        }

        public order_items_Model GetOrderItemById(int order_item_id)
        {

            order_items_Model stock = GetOrdersItems().FirstOrDefault(e => e.orderitem_id.Equals(order_item_id));
            return stock;
        }

        

        public void UpdateOrderItem(tblOrder_items order_item)
        {
            context.OrderItems.Update(order_item);
            context.SaveChanges();
        }

        public List<order_items_Model> OrderWiseProductId(int order_id)
        {
            return GetAllOrdersItems().Where(e => e.order_id.Equals(order_id)).ToList();
        }



        //public List<Product_stock_order_Model> VendorWiseStock_orders(int vendor_id)
        //{
        //    return GetAllStock_orders().Where(e => e.Vendor_id.Equals(vendor_id)).ToList();
        //}
    }
}
