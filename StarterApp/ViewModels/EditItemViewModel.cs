using StarterApp.Database.Models;
using StarterApp.Services;
using CommunityToolkit.Mvvm.Input;

namespace StarterApp.ViewModels;

public partial class EditItemViewModel : BaseViewModel
{
    private readonly IItemService _itemService;

    private Item? _item;

    public string TitleText { get; set; } = "";

    public string Description { get; set; } = "";

    public string Category { get; set; } = "";

    public string PriceText { get; set; } = "";

    // connects item service
    public EditItemViewModel(IItemService itemService)
    {
        _itemService = itemService;

        Title = "Edit Item";
    }

    // load item into form
    public async Task LoadItem(int itemId)
    {
        _item = await _itemService.GetItemByIdAsync(itemId);

        if (_item != null)
        {
            TitleText = _item.Title;
            Description = _item.Description;
            Category = _item.Category;
            PriceText = _item.PricePerDay.ToString();
        }
    }
// saves changed item
[RelayCommand]
    public async Task SaveChanges()
    {
        if (_item == null)
        {
            return;
        }

        decimal.TryParse(PriceText, out var price);

        _item.Title = TitleText;
        _item.Description = Description;
        _item.Category = Category;
        _item.PricePerDay = price;

        await _itemService.UpdateItemAsync(_item);
    }
}