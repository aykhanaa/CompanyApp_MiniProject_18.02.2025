
using CompanyApp_MiniProject_18._02._2025.Controllers;

DepartmentController departmentController = new DepartmentController();
//EmployeeController employeeController = new EmployeeController();  



while (true)
{
    Console.WriteLine("1- Department.Create,  2- Department.GetAll,  3- Department.Delete,  4- Department.GetByIdAsync,  5- Department.Update,  6- Department.Search" +
                      ",  7-Employee.GetAll,  8-Employee.Create,   9-Employee.Delete,  10-Emplyee.GetById, 11-SearchEmpByNameOrSurname "); 
x: string optionStr = Console.ReadLine();

    bool isCorrectOption = int.TryParse(optionStr, out int option);
    if (isCorrectOption)
    {
        switch (option)
        {
            case 1:
                await departmentController.CreateAsync();
                break;
            case 2:
                await departmentController.GetAllAsync();
                break;
            case 3:
                await departmentController.DeleteAsync();
                break;
            case 4:
                await departmentController.GetByIdAsync();
                break;
            case 5:
                await departmentController.UpdateAsync();
                break;
            case 6:
                await departmentController.SearchAsync();
                break;
            //case 7:
            //    await employeeController.GetAllAsync();
            //    break;
            //case 8:
            //    await employeeController.CreateAsync();
            //    break;
            //case 9:
            //    await employeeController.DeleteAsync();
            //    break;
            //case 10:
            //    await employeeController.GetByIdAsync();
            //    break;
            //case 11:
            //    await employeeController.SearchEmpByNameOrSurnameAsync();
            //    break;



            //case 12:
            //    await categorycontroller.DeleteAsync();
            //    break;
            //case 24:
            //    await doctorcontroller.GetAllAsync();
            //    break;
            //case 25:
            //    await doctorcontroller.CreateAsync();
            //    break;
            //case 26:
            //    await doctorcontroller.DeleteAsync();
            //    break;
            //case 27:
            //    await doctorcontroller.GetByIdAsync();
            //    break;
            //case 28:
            //    await doctorcontroller.UpdateAsync();
            //    break;
            //case 29:
            //    await doctorcontroller.SearchAsync();
            //    break;
            //case 30:
            //    await doctorcontroller.GetAllSortingAsync();
            //    break;
            //case 31:
            //    await doctorcontroller.GetByAgeAsync();
            //    break;
            //case 32:
            //    await doctorcontroller.GetDoctorsBySalaryAsync();
            //    break;
            //case 33:
            //    await citycontroller.GetAllAsync();
            //    break;
            default:
                Console.WriteLine("Option wrong choose");
                goto x;
        }
    }

    else
    {
        Console.WriteLine("Option format wrong, choose again");
        goto x;
    }
}


