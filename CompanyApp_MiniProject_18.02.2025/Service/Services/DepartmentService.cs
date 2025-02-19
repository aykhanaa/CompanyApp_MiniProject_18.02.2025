using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepo;
        public DepartmentService()
        {
            _departmentRepo = new DepartmentRepository();
        }

        public async Task CreateAsync(Department department)
        {
            await _departmentRepo.CreateAsync(department);

        }

        public async Task DeleteAsync(int id)
        {
            if (id == null) throw new ArgumentNullException(ResponseMessages.DataNotFound);
            var department = await _departmentRepo.GetByIdAsync(id);
            if (department == null) throw new NotFoundException(ResponseMessages.DataNotFound);
            await _departmentRepo.DeleteAsync(department);

        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await _departmentRepo.GetAllAsync();
        }

        
    }
}

