using Domain.Entities;
using System.Linq.Expressions;


namespace Service.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllAsync();
        Task CreateAsync(Department department);
        Task DeleteAsync(int id);
        
    }
}
