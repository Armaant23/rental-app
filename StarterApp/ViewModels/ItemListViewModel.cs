using System.Collections.ObjectModel;
using StarterApp.Database.Models;
using StarterApp.Services;

namespace StarterApp.ViewModels;

public class ItemListViewModel : BaseViewModel
{
    private readonly IItemService _itemService;

    // stores items shown on the page
    public ObservableCollection<Item> Items { get; set; } = new();

    public ItemListViewModel(IItemService itemService)
    {
        _itemService = itemService;

        Title = "Items";
    }


    // gets items from database
    public async Task LoadItems()
    {
        Items.Clear();

        var itemList = await _itemService.GetItemsAsync();

        foreach (var item in itemList)
        {
            Items.Add(item);
        }
    }
}