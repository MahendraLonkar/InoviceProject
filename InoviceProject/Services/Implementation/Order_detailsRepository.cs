using InoviceProject.Models;
using InoviceProject.Services.Interface;
using System.Linq;

namespace InoviceProject.Services.Implementation
{
    public class Order_detailsRepository : IOrder_detailsRepository
    {
        InvoiceDBContext context;
        public Order_detailsRepository(InvoiceDBContext context)
        {
            this.context = context;
        }

        public List<Order_details_Model> GetOrders()
        {

            List<Order_details_Model> lst = new List<Order_details_Model>();
            foreach (tblOrder_details c in context.OrderDetails.ToList())
            {
                tblVendor v = context.Vendors.Find(c.vendor_id);
                Order_details_Model cm = new Order_details_Model()
                {
                    order_id = c.order_id,
                    vendor_id = c.vendor_id,
                    vendor_name=v.Vendor_name,
                    order_date=c.order_date,
                    is_received = context.ReceivedDetails.Any(r => r.Order_id == c.order_id),
                    OrderItems = new List<order_items_Model>()
                };

                
                
                foreach (tblOrder_items oi in context.OrderItems.Where(oi => oi.order_id == c.order_id).ToList())
                {
                    tblProduct p = context.Products.Find(oi.Product_id);

                    order_items_Model om = new order_items_Model()
                    {
                        orderitem_id = oi.orderitem_id,
                        order_id = oi.order_id,
                        product_id = oi.Product_id,
                        product_name = p.Product_name,
                        Order_quantity = oi.Order_quantity
                    };
                    cm.OrderItems.Add(om);
                }
                    lst.Add(cm);
            }
            return lst;
        }
        public List<Order_details_Model> GetAllOrder()
        {
            return GetOrders();
        }



        public Order_details_Model GetOrderById(int order_id)
        {
            Order_details_Model od = GetAllOrder().FirstOrDefault(e => e.order_id.Equals(order_id));
            return od;
            
        }

        public void AddOrder(tblOrder_details order)
        {
            context.OrderDetails.Add(order);
            context.SaveChanges();
        }

        public void UpdateOrder(tblOrder_details order)
        {
            context.OrderDetails.Update(order);
            context.SaveChanges();
        }

        public void DeleteOrder(int order_id)
        {
            throw new NotImplementedException();
        }

        public Order_details_Model GetOrderwiseVendorId(int vendor_id)
        {
            Order_details_Model details_Model=GetAllOrder().FirstOrDefault(e=>e.vendor_id.Equals(vendor_id));
            return details_Model;
        }
    }
}
