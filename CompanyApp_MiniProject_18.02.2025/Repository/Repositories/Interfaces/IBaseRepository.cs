using Domain.Common;
using Microsoft.Extensions.Primitives;
using System.Linq.Expressions;



namespace Repository.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task CreateAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllWithConditionAsync(Expression<Func<T, bool>> predicate);

    }
}
