using EmployeeProject.Models;
using EmployeeProject.ViewModels;
using System;

namespace EmployeeProject.Services
{
    public class EmployeeService : IEmployeeService
    {
        private EmployeeContext _context;
       
        public EmployeeService(EmployeeContext context)
        {
            _context = context;
        }

       
        public List<EmployeeClass> GetEmployeesList()
        {
            List<EmployeeClass> empList;
            try
            {
                empList = _context.Set<EmployeeClass>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return empList;
        }

       
        public EmployeeClass GetEmployeeDetailsById(int empId)
        {
            EmployeeClass emp;
            try
            {
                emp = _context.Find<EmployeeClass>(empId);
            }
            catch (Exception)
            {
                throw;
            }
            return emp;
        }

       
        public ResponseModel SaveEmployee(EmployeeClass employeeModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                EmployeeClass _temp = GetEmployeeDetailsById(employeeModel.EmployeeId);
                if (_temp != null)
                {
                    _temp.Designation = employeeModel.Designation;
                    _temp.EmployeeFirstName = employeeModel.EmployeeFirstName;
                    _temp.EmployeeLastName = employeeModel.EmployeeLastName;
                    _temp.Salary = employeeModel.Salary;
                    _context.Update<EmployeeClass>(_temp);
                    model.Messsage = "Employee Update Successfully";
                }
                else
                {
                    _context.Add<EmployeeClass>(employeeModel);
                    model.Messsage = "Employee Inserted Successfully";
                }
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        
        public ResponseModel DeleteEmployee(int employeeId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                EmployeeClass _temp = GetEmployeeDetailsById(employeeId);
                if (_temp != null)
                {
                    _context.Remove<EmployeeClass>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Employee Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Employee Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
    }
    
}
