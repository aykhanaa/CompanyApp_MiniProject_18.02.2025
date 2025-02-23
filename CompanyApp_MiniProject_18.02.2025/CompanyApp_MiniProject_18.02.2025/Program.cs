
using Azure;
using CompanyApp_MiniProject_18._02._2025.Controllers;

DepartmentController departmentController = new DepartmentController();
EmployeeController employeeController = new EmployeeController();  
UserController userController = new UserController();


//while (!userController.IsLoggedIn)
//{

//Operation: Console.WriteLine("1. Log in\n2. Register");

//    string operationStr = Console.ReadLine();
//    int operation;
//    bool isCorrectOperationFormat = int.TryParse(operationStr, out operation);
//    if (isCorrectOperationFormat)
//    {
//        switch (operation)
//        {
//            case 1:

//                await userController.LoginAsync();
//                break;

//            case 2:
//                await userController.RegisterAsync();
//                break;
//            default:
//                Console.WriteLine("Operation is wrong, please try again");
//                goto Operation;
//        }
//    }
//    else
//    {
//        Console.WriteLine("Operation format is wrong, try again:");
//        goto Operation;
//    }
//}





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
            case 7:
                await employeeController.GetAllAsync();
                break;
            case 8:
                await employeeController.CreateAsync();
                break;
            case 9:
                await employeeController.DeleteAsync();
                break;
            case 10:
                await employeeController.GetByIdAsync();
                break;
            case 11:
                await employeeController.SearchEmpByNameOrSurnameAsync();
                break;
            case 12:
                await employeeController.UpdateAsync();
                break;
            case 13:
                await employeeController.GetEmplByAgeAsync();
                break;
            case 14:
                await employeeController.GetEmplByDepIdAsync();
                break;
            case 15:
                await employeeController.GetAllEmplByDepNameAsync();
                break;
            case 16:
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


