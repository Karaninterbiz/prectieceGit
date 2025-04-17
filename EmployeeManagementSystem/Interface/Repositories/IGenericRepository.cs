namespace EmployeeManagementSystem.Interface.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> FindByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();

        T Update(T entity, int id);
        Task SaveAsync();
    }
}
