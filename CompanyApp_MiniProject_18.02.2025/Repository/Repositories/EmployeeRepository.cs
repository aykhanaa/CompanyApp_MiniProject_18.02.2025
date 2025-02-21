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
    }
}
