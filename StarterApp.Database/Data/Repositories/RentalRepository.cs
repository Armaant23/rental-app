using Microsoft.EntityFrameworkCore;
using StarterApp.Database.Models;

namespace StarterApp.Database.Data.Repositories;

// handles rental database actions
public class RentalRepository : IRepository<Rental>
{
    private readonly AppDbContext _db;

    // database connection
    public RentalRepository(AppDbContext db)
    {
        _db = db;
    }



    // gets all rentals
    public async Task<List<Rental>> GetAllAsync()
    {
        return await _db.Rentals
            .Include(r => r.Item)
            .ToListAsync();
    }


    // gets rental with id
    public async Task<Rental?> GetByIdAsync(int id)
    {
        return await _db.Rentals
            .Include(r => r.Item)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

        // saves the rental
        public async Task AddAsync(Rental rental)
        {
            _db.Rentals.Add(rental);

            await _db.SaveChangesAsync();
        }

    // updates rental
    public async Task UpdateAsync(Rental rental)
    {
        _db.Rentals.Update(rental);

        await _db.SaveChangesAsync();
    }

    // delete rental
    public async Task DeleteAsync(int id)
    {
        var rental = await _db.Rentals.FindAsync(id);

        if (rental != null)
        {
            _db.Rentals.Remove(rental);

            await _db.SaveChangesAsync();
        }
    }

}