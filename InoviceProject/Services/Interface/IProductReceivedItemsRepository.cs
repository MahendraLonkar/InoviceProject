using InoviceProject.Models;

namespace InoviceProject.Services.Interface
{
    public interface IProductReceivedItemsRepository
    {
        List<ItemModel> GetAllReceivedItems();
        ItemModel GetReceivedItemById(int recevied_item_id);
        List<ItemModel> GetreceivedstockmwiseReceiveditem(int received_id);


        List<ItemModel> GetorderitemwiseReceiveditem(int orderitem_id);
    }
}
