using Microsoft.EntityFrameworkCore;
using StarterApp.Database.Models;

namespace StarterApp.Database.Data.Repositories;


    // handles item database actions
public class ItemRepository : IRepository<Item>
{
    private readonly AppDbContext _db;

    // database connection
    public ItemRepository(AppDbContext db)
    {
        _db = db;
    }


    // gets all items
    public async Task<List<Item>> GetAllAsync()
    {
        return await _db.Items
            .Include(i => i.Owner)
            .ToListAsync();
    }

    // gets item by id
    public async Task<Item?> GetByIdAsync(int id)
    {
        return await _db.Items
            .Include(i => i.Owner)
            .FirstOrDefaultAsync(i => i.Id == id);
    }



    // saves item
    public async Task AddAsync(Item item)
    {
        _db.Items.Add(item);

        await _db.SaveChangesAsync();
    }
    // updates item
    public async Task UpdateAsync(Item item)
    {
        _db.Items.Update(item);

        await _db.SaveChangesAsync();
    }

    // deletes item
    public async Task DeleteAsync(int id)
    {
        var item = await _db.Items.FindAsync(id);

        if (item != null)
        {
            _db.Items.Remove(item);

            await _db.SaveChangesAsync();
        }
    }

}