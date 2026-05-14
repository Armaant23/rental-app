using System.Collections.ObjectModel;
using StarterApp.Database.Models;
using StarterApp.Services;

namespace StarterApp.ViewModels;

public class RentalsViewModel : BaseViewModel
{
    private readonly IRentalService _rentalService;

    public ObservableCollection<Rental> IncomingRentals { get; set; } = new();

    public ObservableCollection<Rental> OutgoingRentals { get; set; } = new();

    // connects rental service
    public RentalsViewModel(IRentalService rentalService)
    {
        _rentalService = rentalService;

        Title = "Rentals";
    }



// loads rental requests
    public async Task LoadRentals()
    {
        IncomingRentals.Clear();
        OutgoingRentals.Clear();

        var incoming = await _rentalService.GetIncomingRequestsAsync(1);
        var outgoing = await _rentalService.GetOutgoingRequestsAsync(1);

        foreach (var rental in incoming)
        {
            IncomingRentals.Add(rental);
        }

        foreach (var rental in outgoing)
        {
            OutgoingRentals.Add(rental);
        }
    }


     // approve rental request
    public async Task ApproveRental(int rentalId)
    {
        await _rentalService.ApproveRentalAsync(rentalId);

        await LoadRentals();
    }


    // reject rental request
    public async Task RejectRental(int rentalId)
    {
        await _rentalService.RejectRentalAsync(rentalId);

        await LoadRentals();
    }
}