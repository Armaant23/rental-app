using StarterApp.Database.Models;

namespace StarterApp.Services;

public interface IRentalService
{
    // saves rental request
    Task AddRentalRequestAsync(Rental rental);
    Task<List<Rental>> GetIncomingRequestsAsync(int ownerId);

    Task<List<Rental>> GetOutgoingRequestsAsync(int borrowerId);
// approves and rejects rental request
    Task ApproveRentalAsync(int rentalId);  
Task RejectRentalAsync(int rentalId);
}