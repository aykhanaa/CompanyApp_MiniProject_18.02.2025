
using Azure;
using CompanyApp_MiniProject_18._02._2025.Controllers;
using Service.Helpers.Enums;

DepartmentController departmentController = new DepartmentController();
EmployeeController employeeController = new EmployeeController();  
UserController userController = new UserController();


while (!userController.IsLoggedIn)
{

Operation: Console.WriteLine("1. Log in\n2. Register");

    string operationStr = Console.ReadLine();
    int operation;
    bool isCorrectOperationFormat = int.TryParse(operationStr, out operation);
    if (isCorrectOperationFormat)
    {
        switch (operation)
        {
            case 1:

                await userController.LoginAsync();
                break;

            case 2:
                await userController.RegisterAsync();
                break;
            default:
                Console.WriteLine("Operation is wrong, please try again");
                goto Operation;
        }
    }
    else
    {
        Console.WriteLine("Operation format is wrong, try again:");
        goto Operation;
    }
}



while (true)
{
    Console.WriteLine("1- Department.Create,  2- Department.GetAll,  3- Department.Delete,  4- Department.GetByIdAsync,  5- Department.Update,  6- Department.Search" +
                      ",  7-Employee.GetAll,  8-Employee.Create,   9-Employee.Delete,  10-Emplyee.GetById, 11-SearchEmpByNameOrSurname, 12-Employee.Update, " +
                      "13-Employee.GetEmplByAgeAsync , 14- Employee.GetEmplByDepIdAsync , 15- Employee.GetAllEmplByDepNameAsync , 16- Employee.GetAllEmplCountAsync");
x: string optionStr = Console.ReadLine();

    bool isCorrectOption = int.TryParse(optionStr, out int option);
    if (isCorrectOption)
    {
        switch (option)
        {
            case (int)OperationType.CreateDepartment:
                await departmentController.CreateAsync();
                break;
            case (int)OperationType.GetAllDepartment:
                await departmentController.GetAllAsync();
                break;
            case (int)OperationType.DeleteDepartment:
                await departmentController.DeleteAsync();
                break;
            case (int)OperationType.GetByIdDepartment:
                await departmentController.GetByIdAsync();
                break;
            case (int)OperationType.UpdateDepartment:
                await departmentController.UpdateAsync();
                break;
            case (int)OperationType.SearchAsyncDepartment:
                await departmentController.SearchAsync();
                break;
            case (int)OperationType.GetAllEmployee:
                await employeeController.GetAllAsync();
                break;
            case (int)OperationType.CreateEmployee:
                await employeeController.CreateAsync();
                break;
            case (int)OperationType.DeleteEmployee:
                await employeeController.DeleteAsync();
                break;
            case (int)OperationType.GetByIdEmployee:
                await employeeController.GetByIdAsync();
                break;
            case (int)OperationType.SearchEmpByNameOrSurname:
                await employeeController.SearchEmpByNameOrSurnameAsync();
                break;
            case (int)OperationType.UpdateEmployee:
                await employeeController.UpdateAsync();
                break;
            case (int)OperationType.GetEmplByAge:
                await employeeController.GetEmplByAgeAsync();
                break;
            case (int)OperationType.GetEmplByDepId:
                await employeeController.GetEmplByDepIdAsync();
                break;
            case (int)OperationType.GetAllEmplByDepName:
                await employeeController.GetAllEmplByDepNameAsync();
                break;
            case (int)OperationType.GetAllEmplCount:
                await employeeController.GetAllEmplCountAsync();
                break;

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


