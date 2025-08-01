﻿using Domain.Entities;

using System.Linq.Expressions;


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
        Task<List<Employee>> GetAllEmplByDepNameAsync(string name);
        Task<int> GetAllEmplCountAsync();

    }
}
