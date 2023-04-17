using InoviceProject.Models;
using InoviceProject.Services.Interface;

namespace InoviceProject.Services.Implementation
{
    public class ProductReceivedStockRepository:IProductReceivedStockRepository
    {
        InvoiceDBContext context;
        public ProductReceivedStockRepository(InvoiceDBContext context)
        {
            this.context = context;
        }

        public void AddReceivedStock(tblReceived_details received_Stock)
        {
            context.ReceivedDetails.Add(received_Stock);
            context.SaveChanges();
        }

        public void DeleteReceivedStock(int received_Stock_id)
        {
            tblReceived_details received_Stock = context.ReceivedDetails.Find(received_Stock_id);
            context.ReceivedDetails.Remove(received_Stock);
            context.SaveChanges();
        }

        public List<Product_received_stock_Model> GetAllReceived_Stocks()
        {
            List<Product_received_stock_Model> lst = new List<Product_received_stock_Model>();
            foreach (tblReceived_details received_Stock in context.ReceivedDetails.ToList())
            {
                tblOrder_details p = context.OrderDetails.Find(received_Stock.Order_id);
                tblVendor v = context.Vendors.Find(p.vendor_id);
                Product_received_stock_Model psm = new Product_received_stock_Model()
                {
                    Receive_stock_id = received_Stock.Receive_stock_id,
                    Order_id= received_Stock.Order_id,
                    order_date=p.order_date,
                    vendor_id=p.vendor_id,
                    Vendor_name=v.Vendor_name,
                    Received_date = received_Stock.Received_date,
                    ReceivedItems = new List<Received_Item_Model>()
                };
                foreach (tblReceived_Items ri in context.ReceivedItems.Where(ri => ri.Receive_id == received_Stock.Receive_stock_id).ToList())
                {

                    tblOrder_items t = context.OrderItems.Find(ri.orderitem_id);
                    tblProduct o = context.Products.Find(t.Product_id);
                    Received_Item_Model rim = new Received_Item_Model()
                    {
                        received_item_id = ri.received_item_id,
                        Receive_id = ri.Receive_id,
                        //product_id = t.Product_id,
                        //product_name = o.Product_name,
                        
                      received_quantity = ri.received_quantity,
                        orderitem_id=ri.orderitem_id
                    };
                    psm.ReceivedItems.Add(rim);
                }

                lst.Add(psm);
                p.Is_Received = true;
                context.SaveChanges();
            }
            return lst;
        }

        public Product_received_stock_Model GetReceivedStockById(int received_Stock_id)
        {
            Product_received_stock_Model received_stock = GetAllReceived_Stocks().FirstOrDefault(e => e.Receive_stock_id.Equals(received_Stock_id));
            return received_stock;
        }

        public List<Product_received_stock_Model> GetProduct_received_stock()
        {
            return GetAllReceived_Stocks();
        }

        

        public void UpdateReceivedStock(tblReceived_details received_Stock)
        {
            context.ReceivedDetails.Update(received_Stock);
            context.SaveChanges();
        }

        public List<Product_received_stock_Model> OrderWiseReceivedStock(int order_id)
        {
            
            return GetAllReceived_Stocks().Where(e => e.Order_id.Equals(order_id)).ToList();
        }


    }
}
