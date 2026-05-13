using Microsoft.EntityFrameworkCore;
using StarterApp.Database.Data;
using StarterApp.Database.Models;

namespace StarterApp.Services;


public class ItemService : IItemService
{
    private readonly AppDbContext _db;

    public ItemService(AppDbContext db)
    {
        _db = db;
    }

    // loads all items saved in the database
    public async Task<List<Item>> GetItemsAsync()
    {
        var items = await _db.Items
            .Include(i => i.Owner)
            .ToListAsync();

        return items;
    }

    // saves a new item
    public async Task AddItemAsync(Item item)
    {
        _db.Items.Add(item);
        await _db.SaveChangesAsync();
    }
}