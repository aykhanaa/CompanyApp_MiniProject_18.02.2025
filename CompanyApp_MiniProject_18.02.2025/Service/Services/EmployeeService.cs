using Azure;
using Domain.Entities;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepo;
        public EmployeeService()
        {
            _employeeRepo = new EmployeeRepository();
        }

        public async Task CreateAsync(Employee employee)
        {
            await _employeeRepo.CreateAsync(employee);
        }

        public async Task DeleteAsync(int id)
        {
            if (id == null) throw new NotFoundException(ResponseMessages.DataNotFound);
            var employee = await _employeeRepo.GetByIdAsync(id);
            if (employee == null) throw new NotFoundException(ResponseMessages.DataNotFound);
            await _employeeRepo.DeleteAsync(employee);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _employeeRepo.GetAllAsync();
        }

       
        public async Task<Employee> GetByIdAsync(int id)
        {
            var result = await _employeeRepo.GetByIdAsync(id);
            if (result is null) throw new NotFoundException(ResponseMessages.DataNotFound);
            return result;
        }

        public async Task<IEnumerable<Employee>> GetAllWithConditionAsync(Expression<Func<Employee, bool>> predicate)
        {
            var result = await _employeeRepo.GetAllWithConditionAsync(predicate);
            if (!result.Any()) throw new NotFoundException(ResponseMessages.DataNotFound);
            return result;
        }

        public async Task UpdateAsync(int id, Employee employee)
        {
            var existEmployee = await _employeeRepo.GetByIdAsync(id);

            if (!string.IsNullOrWhiteSpace(employee.Name))
            {
                existEmployee.Name = employee.Name;
            }

            if (!string.IsNullOrWhiteSpace(employee.Surname))
            {
                existEmployee.Surname = employee.Surname;
            }

            if (employee.Age > 0)
            {
                existEmployee.Age = employee.Age;
            }

            if (!string.IsNullOrWhiteSpace(employee.Address))
            {
                existEmployee.Address = employee.Address;
            }
            if (employee.DepartmentId > 0)
            {
                existEmployee.DepartmentId = employee.DepartmentId;
            }

            await _employeeRepo.UpdateAsync(existEmployee);
        }

        public async Task<List<Employee>> GetEmplByAgeAsync(int age)
        {
            var emplAge = await _employeeRepo.GetEmployeesByAgeAsync(age);
            if (emplAge.Count == 0) throw new NotFoundException(ResponseMessages.DataNotFound);
            return emplAge;
        }
        public async Task<List<Employee>> GetEmplByDepIdAsync(int departmentId)
        {
            var emplId = await _employeeRepo.GetEmployeesByDepIdAsync(departmentId);
            if (emplId.Count == 0) throw new Exception(ResponseMessages.DataNotFound);
            return emplId;
        }
    }
}
