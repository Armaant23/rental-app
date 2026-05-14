using StarterApp.Database.Models;
using StarterApp.Services;

namespace StarterApp.ViewModels;

public class ItemDetailViewModel : BaseViewModel
{
    private readonly IItemService _itemService;

    public Item? ItemData { get; set; }

    // connects from service to viewmodel
    public ItemDetailViewModel(IItemService itemService)
    {
        _itemService = itemService;

        Title = "Item Details";
    }

    // load chosen item
    public async Task LoadItem(int itemId)
    {
        ItemData = await _itemService.GetItemByIdAsync(itemId);
    }
}