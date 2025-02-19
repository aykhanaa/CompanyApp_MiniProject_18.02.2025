
using Domain.Entities;
using Service.Helpers.Constants;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;


namespace CompanyApp_MiniProject_18._02._2025.Controllers
{
    public class DepartmentController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController()
        {
            _departmentService = new DepartmentService();
        }

        public async Task GetAllAsync()
        {
            var allDepartment = await _departmentService.GetAllAsync();

            foreach (var item in allDepartment)
            {
                Console.WriteLine($"Id:{item.Id},Name:{item.Name},Capacity:{item.Capacity},CreatedDate:{item.CreatedDate.ToString("MM/dd/yyyy")}");
            }
        }
        public async Task CreateAsync()
        {
            var allDepartment = await _departmentService.GetAllAsync();

        Name: Console.WriteLine("Enter name:");

            string name = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(name))
            {
                goto Name;
            }

            if (!name.CheckCategoryNameFormat())
            {
                Console.WriteLine(ResponseMessages.InvalidNameFormat);
                goto Name;
            }

            if (allDepartment.Any(m => m.Name.ToLower() == name.ToLower()))
            {
                Console.WriteLine("Department with this name already exists");
                goto Name;
            }

            Console.WriteLine("Enter capacity:");
        Capacity: string capacityStr = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(capacityStr))
            {
                Console.WriteLine("Capacity is required");
                goto Capacity;
            }

            int capacity;

            if (!int.TryParse(capacityStr, out capacity))
            {
                Console.WriteLine(ResponseMessages.InvalidCapacityFormat + ". Please try again:");
                goto Capacity;
            }

            if (capacity <= 0)
            {
                Console.WriteLine("Capacity must be minimum 0. Please try again:");
                goto Capacity;
            }

            try
            {
                await _departmentService.CreateAsync(new Department { Name = name, Capacity = capacity });
                Console.WriteLine(ResponseMessages.CreateSuccess);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
        public async Task DeleteAsync()
        {
            var allDepartment = await _departmentService.GetAllAsync();
        Delete: Console.WriteLine("Add department id for deleted");
            string idStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(idStr))
            {
                goto Delete;
            }
            int id;
            if (!int.TryParse(idStr, out id))
            {
                Console.WriteLine(ValidationMessages.OnlyNumberFormat);
                goto Delete;
            }
            if (id < 1)
            {

                Console.WriteLine("Id cannot be less than 1. Please try again:");
                goto Delete;
            }
            if (allDepartment.All(m => m.Id != id))
            {
                Console.WriteLine(ResponseMessages.DataNotFound);
                goto Delete;
            }
            try
            {
                await _departmentService.DeleteAsync(id);
                Console.WriteLine(ResponseMessages.DeleteSuccess);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                goto Delete;
            }

        }
       
    }


}

