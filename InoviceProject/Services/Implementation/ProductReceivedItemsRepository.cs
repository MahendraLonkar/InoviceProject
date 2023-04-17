using InoviceProject.Models;
using InoviceProject.Services.Interface;

namespace InoviceProject.Services.Implementation
{
    public class ProductReceivedItemsRepository: IProductReceivedItemsRepository
    {
        InvoiceDBContext context;
        public ProductReceivedItemsRepository(InvoiceDBContext context)
        {
            this.context = context;
        }

        public List<ItemModel> GetReceiveditems()
        {
            List<ItemModel> items = new List<ItemModel>();

            foreach (tblReceived_Items i in context.ReceivedItems.ToList())
            {
                tblOrder_items t = context.OrderItems.Find(i.orderitem_id);
                tblProduct p = context.Products.Find(t.Product_id);
                tblReceived_details d = context.ReceivedDetails.Find(i.orderitem_id);
                ItemModel o = new ItemModel()
                {
                    Received_item_id = i.received_item_id,
                    Received_id = i.Receive_id,
                    order_item_id = i.orderitem_id,
                    order_quantity = t.Order_quantity,
                    product_id = p.Product_id,
                    product_name = p.Product_name,
                    Received_quantity = i.received_quantity,
                    purchase_rate = i.Purchase_rate
                };
                items.Add(o);
            }
            return items;
        }

        public List<ItemModel> GetAllReceivedItems()
        {
            return GetReceiveditems();
        }

        public ItemModel GetReceivedItemById(int recevied_item_id)
        {
            ItemModel rm = GetReceiveditems().FirstOrDefault(e => e.Received_item_id.Equals(recevied_item_id));
            return rm;
        }

        public List<ItemModel> GetorderitemwiseReceiveditem(int orderitem_id)
        {
            return GetReceiveditems().Where(e => e.order_item_id.Equals(orderitem_id)).ToList();
        }

        public List<ItemModel> GetreceivedstockmwiseReceiveditem(int received_id)
        {
            return GetReceiveditems().Where(e => e.Received_id.Equals(received_id)).ToList();
        }
    }
}
