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

       
    }
}
