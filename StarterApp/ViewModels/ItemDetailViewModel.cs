using StarterApp.Database.Models;
using StarterApp.Services;
using CommunityToolkit.Mvvm.Input;

namespace StarterApp.ViewModels;
public partial class ItemDetailViewModel : BaseViewModel
{
    private readonly IItemService _itemService;
    private readonly IRentalService _rentalService;


    private Item? _itemData;

    public Item? ItemData
    {
        get => _itemData;
        set => SetProperty(ref _itemData, value);
    }
    // connects from services to viewmodel
    public ItemDetailViewModel(IItemService itemService, IRentalService rentalService)
    {
        _itemService = itemService;
        _rentalService = rentalService;

        Title = "Item Details";
    }

    // load chosen item
    public async Task LoadItem(int itemId)
    {
        ItemData = await _itemService.GetItemByIdAsync(itemId);
    }

// request to rent item
[RelayCommand]
public async Task RequestRental()
{
    if (ItemData != null)
    {
        // basic 1 day rental
        var startDate = DateTime.UtcNow;
        var endDate = startDate.AddDays(1);

    // works out rental price
        var totalPrice = ItemData.PricePerDay * 1;

        var rental = new Rental
        {
            ItemId = ItemData.Id,
            OwnerId = ItemData.OwnerId,
            BorrowerId = 1,
            StartDate = startDate,
            EndDate = endDate,
            TotalPrice = totalPrice,
            Status = "Requested"
        };

        await _rentalService.AddRentalRequestAsync(rental);
    }
}


    // delete current item
    public async Task DeleteItem()
    {
        if (ItemData != null)
        {
            await _itemService.DeleteItemAsync(ItemData.Id);
        }
    }
}