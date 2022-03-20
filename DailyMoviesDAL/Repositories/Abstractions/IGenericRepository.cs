namespace DailyMoviesDAL.Repositories.Abstractions
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> All();
        Task<T> GetById(int id);
        Task<bool> Add(T entity);
        Task<bool> Delete(int Id);
        Task<bool> Upsert(T entity);
    }
}
