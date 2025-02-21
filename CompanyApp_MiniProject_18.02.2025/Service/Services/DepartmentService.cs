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
            if (id == null) throw new NotFoundException(ResponseMessages.DataNotFound);
            var department = await _departmentRepo.GetByIdAsync(id);
            if (department == null) throw new NotFoundException(ResponseMessages.DataNotFound);
            await _departmentRepo.DeleteAsync(department);

        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await _departmentRepo.GetAllAsync();
        }

        public async Task<IEnumerable<Department>> GetAllWithConditionAsync(Expression<Func<Department, bool>> predicate)
        {
            var result = await _departmentRepo.GetAllWithConditionAsync(predicate);
            //if (!result.Any()) throw new NotFoundException(ResponseMessages.DataNotFound);
            return result;
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            var result = await _departmentRepo.GetByIdAsync(id);
            if (result is null) throw new NotFoundException(ResponseMessages.DataNotFound);

            return result;
        }

        public async Task UpdateAsync(int id, Department department)
        {
            var existDepartment = await _departmentRepo.GetByIdAsync(id);
            if (!string.IsNullOrWhiteSpace(department.Name))
            {
                existDepartment.Name = department.Name;
            }
            if (department.Capacity > 0)
            {
                existDepartment.Capacity = department.Capacity;
            }
            await _departmentRepo.UpdateAsync(existDepartment);
        }

    }
}

