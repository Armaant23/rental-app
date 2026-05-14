namespace StarterApp.Database.Data.Repositories;

// basic repository layout
public interface IRepository<T> where T : class
{
    // gets  data
    Task<List<T>> GetAllAsync();

    // get one item
    Task<T?> GetByIdAsync(int id);

    // save item
    Task AddAsync(T item);

    // update item
    Task UpdateAsync(T item);

    // deletes item
    Task DeleteAsync(int id);
}