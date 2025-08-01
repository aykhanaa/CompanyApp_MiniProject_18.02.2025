﻿using Domain.Entities;


namespace Repository.Repositories.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<List<Employee>> GetEmployeesByAgeAsync(int age);
        Task<List<Employee>> GetEmployeesByDepIdAsync(int departmentId);
        Task<List<Employee>> GetAllEmployeesByDepNameAsync(string name);
        Task<int> GetAllEmployeesCountAsync();

    }
}
