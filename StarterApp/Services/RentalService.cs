using Microsoft.EntityFrameworkCore;
using StarterApp.Database.Data;
using StarterApp.Database.Models;

namespace StarterApp.Services;

public class RentalService : IRentalService
{
    private readonly AppDbContext _db;

    // database connection
    public RentalService(AppDbContext db)
    {
        _db = db;
    }

    // saves rental request
    public async Task AddRentalRequestAsync(Rental rental)
    {
        _db.Rentals.Add(rental);

        await _db.SaveChangesAsync();
    }

    // gets requests for item owner
    public async Task<List<Rental>> GetIncomingRequestsAsync(int ownerId)
    {
        var rentals = await _db.Rentals
            .Include(r => r.Item)
            .Include(r => r.Borrower)
            .Where(r => r.OwnerId == ownerId)
            .ToListAsync();

        return rentals;
    }

    // gets requests made by user
    public async Task<List<Rental>> GetOutgoingRequestsAsync(int borrowerId)
    {
        var rentals = await _db.Rentals
            .Include(r => r.Item)
            .Include(r => r.Owner)
            .Where(r => r.BorrowerId == borrowerId)
            .ToListAsync();

        return rentals;
    }
}