using StarterApp.Database.Models;
using StarterApp.Services;

namespace StarterApp.ViewModels;

public class ItemDetailViewModel : BaseViewModel
{
    private readonly IItemService _itemService;

    private Item? _itemData;
    public Item? ItemData
    {
        get => _itemData;
        set => SetProperty(ref _itemData, value);
        }
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


    // delete current item
    public async Task DeleteItem()
    {
        if (ItemData != null)
        {
            await _itemService.DeleteItemAsync(ItemData.Id);
        }
    }
}