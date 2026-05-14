using StarterApp.Database.Models;

namespace StarterApp.Services;

public interface IItemService
{
    //gets saved items
    Task<List<Item>> GetItemsAsync();

    // gets item witg id
    Task<Item?> GetItemByIdAsync(int id);   
    // saves new item
    Task AddItemAsync(Item item);

// deletes item 
    Task DeleteItemAsync(int id);
}