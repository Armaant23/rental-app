using Microsoft.EntityFrameworkCore;
using StarterApp.Database.Data;
using StarterApp.Database.Models;

namespace StarterApp.Services;


public class ItemService : IItemService
{
    private readonly AppDbContext _db;
// db connection
    public ItemService(AppDbContext db)
    {
        _db = db;
    }

    // loads all items that are saved db
    public async Task<List<Item>> GetItemsAsync()
    {
        var items = await _db.Items
            .Include(i => i.Owner)
            .ToListAsync();

        return items;
    }

        // gets one item by id
    public async Task<Item?> GetItemByIdAsync(int id)
    {
        var item = await _db.Items
            .Include(i => i.Owner)
            .FirstOrDefaultAsync(i => i.Id == id);

        return item;
    }

    // saves new item
    public async Task AddItemAsync(Item item)
    {
        _db.Items.Add(item);
        await _db.SaveChangesAsync();
    }

    // deletes item from database
    public async Task DeleteItemAsync(int id)
    {
        var item = await _db.Items.FindAsync(id);

        if (item != null)
        {
            _db.Items.Remove(item);

            await _db.SaveChangesAsync();
        }
    }


// updates existing item
public async Task UpdateItemAsync(Item item)
{
    _db.Items.Update(item);

    await _db.SaveChangesAsync();
}

// approves rental request

    public async Task ApproveRentalAsync(int rentalId)
    {
        var rental = await _db.Rentals.FindAsync(rentalId);

        if (rental != null)
        {
            rental.Status = "Approved ";

            await _db.SaveChangesAsync();
        }
    }

    // rejects rental request
    public async Task RejectRentalAsync(int rentalId)
    {
        var rental = await _db.Rentals.FindAsync(rentalId);
        if (rental != null)
        {
            rental.Status = "Rejected ";

            await _db.SaveChangesAsync();
        }
    }
}