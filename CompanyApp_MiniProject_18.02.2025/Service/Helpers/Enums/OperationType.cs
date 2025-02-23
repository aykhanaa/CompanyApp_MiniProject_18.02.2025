using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers.Enums
{
    public enum OperationType
    {
        CreateDepartment = 1,
        GetAllDepartment,
        DeleteDepartment,
        GetByIdDepartment,
        UpdateDepartment,
        SearchAsyncDepartment,
        GetAllEmployee,
        CreateEmployee,
        DeleteEmployee,
        GetByIdEmployee,
        SearchEmpByNameOrSurname,
        UpdateEmployee,
        GetEmplByAge,
        GetEmplByDepId,
        GetAllEmplByDepName,
        GetAllEmplCount,

    }
}
