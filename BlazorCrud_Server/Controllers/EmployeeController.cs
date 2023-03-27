using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using BlazorCrud_Server.Models;
using BlazorCrud_Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DbBlazorwebapicrud1Context _dbContext;

        public EmployeeController(DbBlazorwebapicrud1Context dbContext)
        {
            _dbContext = dbContext;
        }

        // Method to Get Employee List
        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            var responseApi = new ResponseAPI<List<EmployeeDTO>>();
            var employeeDTOList = new List<EmployeeDTO>();

            try
            {
                foreach (var item in await _dbContext.Employees.Include(d => d.Department).ToListAsync())
                {
                    employeeDTOList.Add(new EmployeeDTO
                    {
                        EmployeeId = item.EmployeeId,
                        EmployeeName = item.EmployeeName,
                        DepartmentId = item.DepartmentId,
                        Salary = item.Salary,
                        ContractDate = item.ContractDate,
                        Department = new DepartmentDTO()
                        {
                            DepartmentId = item.Department.DepartmentId,
                            DepartmentName = item.Department.DepartmentName,
                        }
                    });
                }

                responseApi.IsCorrect = true;
                responseApi.Value = employeeDTOList;

            }
            catch (Exception ex)
            {
                responseApi.IsCorrect = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }

        // Method to Get Employee By Id
        [HttpGet]
        [Route("Search/{id}")]
        public async Task<IActionResult> Search(int id)
        {
            var responseApi = new ResponseAPI<EmployeeDTO>();
            var employeeDTO = new EmployeeDTO();

            try
            {
                var dbEmployee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);

                if (dbEmployee != null) {
                    employeeDTO.EmployeeId = dbEmployee.EmployeeId;
                    employeeDTO.EmployeeName = dbEmployee.EmployeeName;
                    employeeDTO.DepartmentId = dbEmployee.DepartmentId;
                    employeeDTO.Salary = dbEmployee.Salary;
                    employeeDTO.ContractDate = dbEmployee.ContractDate;

                    responseApi.IsCorrect = true;
                    responseApi.Value = employeeDTO;
                }
                else
                {
                    responseApi.IsCorrect = false;
                    responseApi.Message = "Employee was not found!";
                }

            }
            catch (Exception ex)
            {
                responseApi.IsCorrect = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }

        // Method to Add New Employee
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(EmployeeDTO employee)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbEmployee = new Employee { 
                    EmployeeName = employee.EmployeeName,
                    DepartmentId = employee.DepartmentId,
                    Salary = employee.Salary,
                    ContractDate = employee.ContractDate,
                };

                _dbContext.Employees.Add(dbEmployee);
                await _dbContext.SaveChangesAsync();

                if (dbEmployee.EmployeeId != 0)
                {
                    responseApi.IsCorrect = true;
                    responseApi.Value = dbEmployee.EmployeeId;
                }
                else
                {
                    responseApi.IsCorrect = true;
                    responseApi.Message = "Could not add the employee";
                }            

            }
            catch (Exception ex)
            {
                responseApi.IsCorrect = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }

        // Method to Edit a Employee
        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(EmployeeDTO employee, int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbEmployee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
                
                if (dbEmployee != null)
                {
                    dbEmployee.EmployeeName = employee.EmployeeName;
                    dbEmployee.DepartmentId = employee.DepartmentId;
                    dbEmployee.Salary = employee.Salary;
                    dbEmployee.ContractDate = employee.ContractDate;

                    _dbContext.Employees.Update(dbEmployee);
                    await _dbContext.SaveChangesAsync();

                    responseApi.IsCorrect = true;
                    responseApi.Value = dbEmployee.EmployeeId;
                }
                else
                {
                    responseApi.IsCorrect = true;
                    responseApi.Message = "Could not find the employee";
                }

            }
            catch (Exception ex)
            {
                responseApi.IsCorrect = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }

        // Method to Delete a Employee
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbEmployee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);

                if (dbEmployee != null)
                {
                    _dbContext.Employees.Remove(dbEmployee);
                    await _dbContext.SaveChangesAsync();

                    responseApi.IsCorrect = true;
                }
                else
                {
                    responseApi.IsCorrect = true;
                    responseApi.Message = "Could not find the employee";
                }

            }
            catch (Exception ex)
            {
                responseApi.IsCorrect = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }
    }
}
