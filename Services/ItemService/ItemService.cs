using billingSystem.Models;
using billingSystem.Data;
using Microsoft.EntityFrameworkCore;
using billingSystem.Dtos.ItemDtos;

namespace billingSystem.Services.ItemService
{
    public class ItemService : IItemService
    {
        private readonly AppDbContext _context;

        public ItemService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Item>> GetAllItems()
        {
            return await _context.Items.ToListAsync();
        }
        public async Task<Item?> GetItemById(int id)
        {
            return await _context.Items.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Item> CreateItem(CreateItemDto newItem)
        {
            var item = new Item
            {
                Name = newItem.name,
                Price = newItem.price,
                StockAvailable = newItem.StockAvailable
            };

            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }
        public async Task<Item?> UpdateItem(int id, UpdateItemDto updatedItem)
        {
            var item = await GetItemById(id) ?? throw new Exception($"Item ID: {id} not found");
            item.Name = updatedItem.name;
            item.Price = updatedItem.price;
            item.StockAvailable = updatedItem.StockAvailable;
            await _context.SaveChangesAsync();
            return item;
        }
        public async Task DeleteItem(int id)
        {
            var item = await GetItemById(id) ?? throw new Exception($"Item ID: {id} not found");
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
        }



    }
}
