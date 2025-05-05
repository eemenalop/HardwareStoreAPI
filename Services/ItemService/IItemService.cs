using billingSystem.Dtos.CustomersDtos;
using billingSystem.Models;
using billingSystem.Dtos.ItemDtos;

namespace billingSystem.Services.ItemService
{
    public interface IItemService
    {
        Task<List<Item>> GetAllItems();

        Task<Item?> GetItemById(int id);

        Task<Item> CreateItem(CreateItemDto newItem);

        Task<Item?> UpdateItem(int id, UpdateItemDto updatedItem);

        Task DeleteItem(int id);
    }
}
