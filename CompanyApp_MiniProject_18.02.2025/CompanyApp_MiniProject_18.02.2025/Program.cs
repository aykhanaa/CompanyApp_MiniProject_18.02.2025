
using CompanyApp_MiniProject_18._02._2025.Controllers;

DepartmentController departmentController = new DepartmentController();



while (true)
{
    Console.WriteLine("Department.GetAll-1, Department.Create-2, Department.Delete-3, Department.GetByIdAsync-4, Department.Update-5,Department.Search-6");
x: string optionStr = Console.ReadLine();

    bool isCorrectOption = int.TryParse(optionStr, out int option);
    if (isCorrectOption)
    {
        switch (option)
        {
            case 1:
                await departmentController.GetAllAsync();
                break;
            case 2:
                await departmentController.CreateAsync();
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
            //    await countrycontroller.GetCountriesByPopulation();
            //    break;
            //case 8:
            //    await countrycontroller.GetByPopulation();
            //    break;
            //case 9:
            //    await countrycontroller.GetAllWithSortingAsync();
            //    break;
            //case 10:
            //    await categorycontroller.GetAllAsync();
            //    break;
            //case 11:
            //    await categorycontroller.CreateAsync();
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


