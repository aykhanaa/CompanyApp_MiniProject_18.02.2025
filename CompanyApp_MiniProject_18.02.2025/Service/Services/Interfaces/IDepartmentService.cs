using Domain.Entities;
using System.Linq.Expressions;


namespace Service.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllAsync();
        Task CreateAsync(Department department);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, Department department);
        Task<Department> GetByIdAsync(int id);
        Task<IEnumerable<Department>> GetAllWithConditionAsync(Expression<Func<Department, bool>> predicate);

    }
}
