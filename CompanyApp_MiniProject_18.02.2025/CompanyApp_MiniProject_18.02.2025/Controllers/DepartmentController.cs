
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
            try
            {
                var allDepartment = await _departmentService.GetAllAsync();

            Name: Console.WriteLine("Enter department name:");

                string name = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine(ResponseMessages.InputRequired);
                    goto Name;

                }
                if (!name.CheckNameFormat())
                {
                    Console.WriteLine(ResponseMessages.InvalidNameFormat);
                    goto Name;
                }


                if (allDepartment.Any(m => m.Name.Trim().ToLower() == name.Trim().ToLower()))
                {
                    Console.WriteLine("Department with this name already exists");
                    goto Name;
                }

                Console.WriteLine("Enter department  capacity:");
            Capacity: string capacityStr = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(capacityStr))
                {
                    Console.WriteLine(ResponseMessages.InputRequired);
                    goto Capacity;
                }

                int capacity;

                if (!int.TryParse(capacityStr, out capacity))
                {
                    Console.WriteLine(ResponseMessages.InvalidCapacityFormat);
                    goto Capacity;
                }

                if (capacity <= 0)
                {
                    Console.WriteLine("Capacity must be minimum 0. Please try again:");
                    goto Capacity;
                }
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
            try
            {
                
               
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
                await _departmentService.DeleteAsync(id);
                Console.WriteLine(ResponseMessages.DeleteSuccess);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                goto Delete;
            }

        }
        public async Task GetByIdAsync()
        {
            
            try
            {
                var allDepartment = await _departmentService.GetAllAsync();
            Id: Console.WriteLine("Add departament id:");
                string idstr = Console.ReadLine();
                int id;
                if (!int.TryParse(idstr, out id))
                {
                    Console.WriteLine(ValidationMessages.OnlyNumberFormat);
                    goto Id;
                }
                if (id < 1)
                {
                    Console.WriteLine("Id cannot be less than 1");
                    goto Id;
                }

                if (allDepartment.All(m => m.Id != id))
                {
                    Console.WriteLine(ResponseMessages.DataNotFound);
                    goto Id;
                }
                var result = await _departmentService.GetByIdAsync(id);

                Console.WriteLine($"Id:{result.Id},Name:{result.Name},Capacity:{result.Capacity},CreatedDate:{result.CreatedDate.ToString("MM/dd/yyyy")}");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }




        }
        public async Task UpdateAsync()
        {

            try
            {
                var allDepartment = await _departmentService.GetAllAsync();
            Id: Console.WriteLine("Enter id of the departament you want to update:");

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
                    Console.WriteLine("Id cannot be less than 1.");
                    goto Id;
                }

                if (allDepartment.All(m => m.Id != id))
                {
                    Console.WriteLine(ResponseMessages.DataNotFound);
                    goto Id;
                }
            UpdatedName: Console.WriteLine("Enter name :");
             string updatedName = Console.ReadLine().Trim();
                if (!string.IsNullOrEmpty(updatedName))
                {
                    if (!updatedName.CheckNameFormatAllowSpace())
                    {
                        Console.WriteLine(ResponseMessages.InvalidNameFormat);
                        goto UpdatedName;
                    }

                }
                if (allDepartment.Any(m => m.Name.ToLower() == updatedName.ToLower()))
                {
                    Console.WriteLine("Departament with this name already exists");
                    goto UpdatedName;
                }

            Capacity: Console.WriteLine("Enter capacity :");
             string updatedCapacityStr = Console.ReadLine();

                int updatedCapacity = 0;

                if (!string.IsNullOrEmpty(updatedCapacityStr))
                {
                    if (!int.TryParse(updatedCapacityStr, out updatedCapacity))
                    {
                        Console.WriteLine(ResponseMessages.InvalidCapacityFormat);
                        goto Capacity;
                    }

                    if (updatedCapacity < 1)
                    {
                        Console.WriteLine(ResponseMessages.InvalidCapacityFormat);
                    }
                }
                await _departmentService.UpdateAsync(id, new Department { Name = updatedName, Capacity = updatedCapacity });

                Console.WriteLine(ResponseMessages.UpdateSuccess);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
        public async Task SearchAsync()
        {
            Capacity: Console.WriteLine("Add search text");
            string serachText = Console.ReadLine();
            try
            {
                var result = await _departmentService.GetAllWithConditionAsync(x => x.Name.Trim().ToLower().Contains(serachText.Trim().ToLower()));

                foreach (var item in result)
                {
                    Console.WriteLine($"Id:{item.Id},Name:{item.Name},Capacity:{item.Capacity},CreatedDate:{item.CreatedDate.ToString("MM/dd/yyyy")}");
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                goto Capacity;
            }

        }

    }


}

