using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
       

        public async Task<List<Employee>> GetEmployeesByAgeAsync(int age)
        {
            return await _context.Set<Employee>().Where(m => m.Age == age).ToListAsync();
        }

        public async Task<List<Employee>> GetEmployeesByDepIdAsync(int departmentId)
        {
            return await _context.Set<Employee>().Where(m => m.DepartmentId == departmentId).ToListAsync();
        }
        public async Task<List<Employee>> GetAllEmployeesByDepNameAsync(string depName)
        {
            return await _context.Set<Employee>().Include(m => m.Department)
                 .Where(m => m.Department.Name.ToLower() == depName.ToLower()).ToListAsync();
        }

        public async Task<int> GetAllEmployeesCountAsync()
        {
            return await _context.Employees.CountAsync();
        }
        
    }
}
