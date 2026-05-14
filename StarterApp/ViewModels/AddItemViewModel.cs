using StarterApp.Database.Models;
using StarterApp.Services;
using CommunityToolkit.Mvvm.Input;

namespace StarterApp.ViewModels;

public partial class AddItemViewModel : BaseViewModel
{
    private readonly IItemService _itemService;

    // user input values
    public string TitleText { get; set; } = "";
    public string Description { get; set; } = "";
    public string Category { get; set; } = "";
    public string PriceText { get; set; } = "";

// connects service to viewmodel (for saving item)
    public AddItemViewModel(IItemService itemService)
    {
        _itemService = itemService;

        Title = "Add Item";
    }

    // saves the item
[RelayCommand]
public async Task SaveItem()
{
    decimal price = 0;

    decimal.TryParse(PriceText, out price);

    var item = new Item
    {
        Title = TitleText,
        Description = Description,
        Category = Category,
        PricePerDay = price,
        LocationName = "Edinburgh",
        OwnerId = 1
    };

    await _itemService.AddItemAsync(item);
}

}