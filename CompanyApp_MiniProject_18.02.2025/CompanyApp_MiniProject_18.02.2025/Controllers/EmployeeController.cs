using Domain.Entities;
using Service.Helpers.Constants;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp_MiniProject_18._02._2025.Controllers
{
    public class EmployeeController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController()
        {
            _employeeService = new EmployeeService();
            _departmentService = new DepartmentService();
        }

        public async Task GetAllAsync()
        {
            var allEmployees = await _employeeService.GetAllAsync();
            foreach (var item in allEmployees)
            {
                Console.WriteLine($"Id:{item.Id},Name:{item.Name},Surname:{item.Surname},Age:{item.Age},Address:{item.Address},DepartmentId:{item.DepartmentId},CreatedDate:{item.CreatedDate.ToString("MM/dd/yyyy")}");
            }
        }
        public async Task CreateAsync()
        {
            var allDepartments = await _departmentService.GetAllAsync();
            var allEmployees = await _employeeService.GetAllAsync();

        Name: Console.WriteLine("Enter name:");
            string name = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(name))
            {
                goto Name;
            }

        Surname: Console.WriteLine("Enter surname:");
            string surname = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(surname))
            {
                goto Surname;
            }

            Console.WriteLine("Enter age:");
        Age: string ageStr = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(ageStr))
            {
                Console.WriteLine("Age is required");
                goto Age;
            }

            int age;

            if (!int.TryParse(ageStr, out age))
            {
                Console.WriteLine(ResponseMessages.InvalidCapacityFormat);
                goto Age;
            }

            if (!(age > 18 && age < 65))
            {
                Console.WriteLine(ResponseMessages.InvalidAgeFormat);
                goto Age;
            }

        Address: Console.WriteLine("Enter address:");
            string address = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(address))
            {
                goto Address;
            }

            Console.WriteLine("Departments:");
            var allDepartment = await _departmentService.GetAllAsync();


            Console.WriteLine("Enter id of the department you want to add employee:");
        EducationId: string departmentIdStr = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(departmentIdStr))
            {
                Console.WriteLine("Department id is required");
                goto EducationId;
            }

            int departmentId;

            if (!int.TryParse(departmentIdStr, out departmentId))
            {
                Console.WriteLine(ResponseMessages.InvalidIdFormat);
                goto EducationId;
            }

            if (departmentId < 1)
            {
                Console.WriteLine("Id cannot be less than 1. Please try again:");
                goto EducationId;
            }

            if (allDepartment.All(m => m.Id != departmentId))
            {
                Console.WriteLine("There is no department with specified id. Please try again:");
                goto EducationId;
            }
            try
            {
                await _employeeService.CreateAsync(new Employee { Name = name, Surname = surname, Age = age, Address = address, DepartmentId = departmentId });

                Console.WriteLine(ResponseMessages.AddSuccess);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }



        }
        public async Task DeleteAsync()
        {
            var allEmployees = await _employeeService.GetAllAsync();


        Id: Console.WriteLine("Enter id of the employee you want to delete:");
            string idStr = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(idStr))
            {
                goto Id;
            }

            int id;

            if (!int.TryParse(idStr, out id))
            {
                Console.WriteLine(ResponseMessages.InvalidIdFormat);
                goto Id;
            }

            if (id < 1)
            {

                Console.WriteLine("Id cannot be less than 1. Please try again:");
                goto Id;
            }

            if (allEmployees.All(m => m.Id != id))
            {
                Console.WriteLine(ResponseMessages.DataNotFound);
                goto Id;
            }

            try
            {
                await _employeeService.DeleteAsync(id);
                Console.WriteLine(ResponseMessages.DeleteSuccess);
            }
            catch (Exception ex) 
            {

                Console.WriteLine(ex.Message);
            }
        }
        public async Task GetByIdAsync()
        {
            Console.WriteLine("Add employee id");
            int employeeid = int.Parse(Console.ReadLine());

            try
            {
                var result = await _employeeService.GetByIdAsync(employeeid);
                Console.WriteLine($"Id:{result.Id},Name:{result.Name},Surname:{result.Surname},Age:{result.Age},Address:{result.Address},DepartmentId:{result.DepartmentId},CreatedDate:{result.CreatedDate.ToString("MM/dd/yyyy")}");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }


    }
}
