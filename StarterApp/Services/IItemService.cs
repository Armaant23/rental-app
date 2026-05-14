using StarterApp.Database.Models;

namespace StarterApp.Services;

public interface IItemService
{
    //gets saved items
    Task<List<Item>> GetItemsAsync();

    Task AddItemAsync(Item item);
}