﻿using Domain.Entities;
using Service.Helpers.Constants;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;



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
                Console.WriteLine($"Id:{item.Id}, Name:{item.Name}, Surname:{item.Surname},Age:{item.Age},Address:{item.Address},CreatedDate:{item.CreatedDate.ToString("MM/dd/yyyy")},DepartmentId:{item.DepartmentId}");
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
                Console.WriteLine(ResponseMessages.InputRequired);
                goto Name;
            }
            if (!name.CheckNameFormat())
            {
                Console.WriteLine(ResponseMessages.InvalidNameFormat);
                goto Name;
            }

        Surname: Console.WriteLine("Enter surname:");
            string surname = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(surname))
            {
                Console.WriteLine(ResponseMessages.InputRequired);
                goto Surname;
            }
            if (!surname.CheckNameFormat())
            {
                Console.WriteLine(ResponseMessages.InvalidNameFormat);
                goto Surname;
            }

          Age:Console.WriteLine("Enter age:");
        string ageStr = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(ageStr))
            {
                Console.WriteLine(ResponseMessages.InputRequired);
                goto Age;
            }

            int age;

            if (!int.TryParse(ageStr, out age))
            {
                Console.WriteLine(ResponseMessages.IncorrectFormat);
                goto Age;
            }

            if (!(age >= 18 && age < 65))
            {
                Console.WriteLine(ResponseMessages.InvalidAgeFormat);
                goto Age;
            }

        Address: Console.WriteLine("Enter address:");
            string address = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(address))
            {
                Console.WriteLine(ResponseMessages.InputRequired);
                goto Address;
            }
            if (!address.CheckAddressFormat())
            {
                Console.WriteLine(ResponseMessages.InvalidAddressFormat);
                goto Address;
            }

            Console.WriteLine("Departments:");

        EducationId: Console.WriteLine("Enter id of the department you want to add employee:");
         string departmentIdStr = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(departmentIdStr))
            {
                Console.WriteLine(ResponseMessages.InputRequired);
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

            if (allDepartments.All(m => m.Id != departmentId))
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
                Console.WriteLine(ResponseMessages.InputRequired);
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
            Id:  Console.WriteLine("Add employee id");
            string employeeidStr = Console.ReadLine();

            int employeeid;
            if (!int.TryParse(employeeidStr, out employeeid))
            {
                Console.WriteLine(ResponseMessages.InvalidFormat);
                goto Id;
            }

            try
            {
                var result = await _employeeService.GetByIdAsync(employeeid);
                Console.WriteLine($"Id:{result.Id},Name:{result.Name} , Surname:{result.Surname},Age:{result.Age},Address:{result.Address},DepartmentId:{result.DepartmentId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto Id;
            }

        }
        public async Task SearchEmpByNameOrSurnameAsync()
        {

        Surname:  Console.WriteLine("Add search text");
            string serachText = Console.ReadLine();
            try
            {
                var result = await _employeeService.GetAllWithConditionAsync(x => x.Name.Trim().ToLower().Contains(serachText.Trim().ToLower()) || x.Surname.Trim().ToLower().Contains(serachText.Trim().ToLower()));

                foreach (var item in result)
                {
                    Console.WriteLine($"Id:{item.Id},Name:{item.Name}, Surname:{item.Surname},Age:{item.Age},Address:{item.Address},DepartmentId:{item.DepartmentId}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                goto Surname;
            }
        }
        public async Task UpdateAsync()
        {
            var allDepartment = await _departmentService.GetAllAsync();
            var allEmployee = await _employeeService.GetAllAsync();

            Id: Console.WriteLine("Enter id of the employee you want to update:");
            string idStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(idStr))
            {
                Console.WriteLine(ResponseMessages.InputRequired);
                goto Id;
            }
            int id;

            if (!int.TryParse(idStr, out id))
            {
                Console.WriteLine(ResponseMessages.InvalidIdFormat);
                goto Id;
            }

            if (allEmployee.All(m=>m.Id != id))
            {
                Console.WriteLine(ResponseMessages.DataNotFound);
                goto Id;
            }

            if (id < 1)
            {
                Console.WriteLine("Id cannot be less than 1. Please try again:");
                goto Id;
            }

            EditedName: Console.WriteLine("Add name");
            string editedName = Console.ReadLine();

            if (!string.IsNullOrEmpty(editedName))
            {
                if (!editedName.CheckNameFormatAllowSpace())
                {
                    Console.WriteLine(ResponseMessages.InvalidNameFormat);
                    goto EditedName;
                }
            }
            
            if (allEmployee.Any(m => m.Name.ToLower() == editedName.ToLower()))
            {
                Console.WriteLine("Employee name is already exists");
                goto EditedName;
            }
            


        EditedSurname: Console.WriteLine("Add surname");
            string editedsurname = Console.ReadLine();
            if(!string.IsNullOrEmpty(editedsurname))
            {
                if (!editedsurname.CheckNameFormatAllowSpace())
                {
                    Console.WriteLine(ResponseMessages.InvalidNameFormat);
                    goto EditedSurname;
                }
            }
            if (allEmployee.Any(m => m.Name.Trim().ToLower() == editedsurname.Trim().ToLower()))
            {
                Console.WriteLine("Employee surname is already exists");
                goto EditedSurname;
            }




        EditedAge: Console.WriteLine("Add age:");
            string editedagestr = Console.ReadLine();
            int editedage = 0;

            if (!string.IsNullOrWhiteSpace(editedagestr))
            {
                if (!int.TryParse(editedagestr, out editedage))
                {
                    Console.WriteLine(ResponseMessages.InvalidAgeFormat);
                    goto EditedAge;
                }

                if (!(editedage > 18 && editedage < 65))
                {
                    Console.WriteLine(ResponseMessages.InvalidAgeFormat);
                    goto EditedAge;
                }
            }


        EditedAddress: Console.WriteLine("Add address");
            string editaddress = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(editaddress))
            {
                if (!editaddress.CheckNameFormatAllowSpace())
                {
                    Console.WriteLine(ResponseMessages.InvalidNameFormat);
                    goto EditedName;
                }
            }

            if (allEmployee.Any(m => m.Address.Trim().ToLower() == editaddress.Trim().ToLower()))
            {
                Console.WriteLine("Employee address is already exists");
                goto EditedAddress;
            }



            Console.WriteLine("Department:");

            DepartmentId: Console.WriteLine("Enter department id want to switch:");
            string employeeIdStr = Console.ReadLine();

            int editedDepartmentId = 0;

            if (!string.IsNullOrWhiteSpace(employeeIdStr))
            {
                if (!int.TryParse(employeeIdStr, out editedDepartmentId))
                {
                    Console.WriteLine(ResponseMessages.InvalidIdFormat);
                    goto DepartmentId;
                }

                if (editedDepartmentId < 1)
                {
                    Console.WriteLine("Id cannot be less than 1");
                    goto DepartmentId;
                }

                if (allDepartment.All(m => m.Id != editedDepartmentId))
                {
                    Console.WriteLine("There is no education with specified id:");
                    goto DepartmentId;
                }
            }

            try
            {
                await _employeeService.UpdateAsync(id, new Employee { Name = editedName, Surname = editedsurname, Age = editedage, Address = editaddress, DepartmentId = editedDepartmentId });
                Console.WriteLine(ResponseMessages.UpdateSuccess);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            



        }
        public async Task GetEmplByAgeAsync()
        {
        Age: Console.WriteLine("Enter age");
            string ageStr = Console.ReadLine();

             int age;
            if (!int.TryParse(ageStr, out age))
            {
                Console.WriteLine(ResponseMessages.InvalidFormat);
                goto Age;
            }

            if (!(age >= 18 && age < 65))
            {
                Console.WriteLine(ResponseMessages.InvalidAgeFormat);
                goto Age;
            }


            try
            {
                var empAge = await _employeeService.GetEmplByAgeAsync(age);
                foreach (var item in empAge)
                {
                    Console.WriteLine($"Name:{item.Name}, Surname: {item.Surname},Age:{item.Age},Address:{item.Address},DepartmentId:{item.DepartmentId}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto Age;

            }
        }
        public async Task GetEmplByDepIdAsync()
        {
            DepId: Console.WriteLine("Add department id");
            string depIdStr = Console.ReadLine();

            int depId;
            if (!int.TryParse(depIdStr, out depId))
            {
                Console.WriteLine(ResponseMessages.InvalidFormat);
                goto DepId;
            }
            try
            {
                var empId = await _employeeService.GetEmplByDepIdAsync(depId);
                foreach (var item in empId)
                {
                    Console.WriteLine($"Name:{item.Name} ,Surname:{item.Surname},Age:{item.Age},Address:{item.Address},DepartmentId:{item.DepartmentId}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                goto DepId;
            }

        }
        public async Task GetAllEmplByDepNameAsync()
        {
        Name: Console.WriteLine("Add department name");
            string depName = Console.ReadLine();
            if (string.IsNullOrEmpty(depName))
            {
                Console.WriteLine(ResponseMessages.InputRequired);
                goto Name;
            }
            if (!depName.CheckNameFormat())
            {
                Console.WriteLine(ResponseMessages.InvalidNameFormat);
                goto Name;
            }

            try
            {
                var result = await _employeeService.GetAllEmplByDepNameAsync(depName);
                foreach (var item in result)
                {
                    Console.WriteLine($"Name :{item.Name} , Surname:{item.Surname},Age:{item.Age},Address:{item.Address},DepartmentId:{item.DepartmentId}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                goto Name;
            }
        }
        public async Task GetAllEmplCountAsync()
        {

            var emplCount = await _employeeService.GetAllEmplCountAsync();
            Console.WriteLine("All employees count:" +" " + emplCount);
        }

    }
}
