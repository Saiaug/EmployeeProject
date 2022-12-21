using EmployeeProject.Models;
using EmployeeProject.ViewModels;

namespace EmployeeProject.Services
{
    public interface IEmployeeService
    {
        List<EmployeeClass> GetEmployeesList();

        
        EmployeeClass GetEmployeeDetailsById(int empId);

       
        ResponseModel SaveEmployee(EmployeeClass employeeModel);


        
        ResponseModel DeleteEmployee(int employeeId);
    }
}

