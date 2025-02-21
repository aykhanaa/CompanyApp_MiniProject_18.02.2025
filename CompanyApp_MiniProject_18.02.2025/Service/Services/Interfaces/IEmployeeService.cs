using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task CreateAsync(Employee employee);
        Task DeleteAsync(int id);
        Task<Employee> GetByIdAsync(int id);
        Task UpdateAsync(int id, Employee employee);
        Task<IEnumerable<Employee>> GetAllWithConditionAsync(Expression<Func<Employee, bool>> predicate);
        Task<List<Employee>> GetEmplByAgeAsync(int age);
        Task<List<Employee>> GetEmplByDepIdAsync(int departmentId);

    }
}
