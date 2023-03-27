using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using BlazorCrud_Server.Models;
using BlazorCrud_Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DbBlazorwebapicrud1Context _dbContext;

        public DepartmentController(DbBlazorwebapicrud1Context dbContext)
        {
            _dbContext = dbContext;
        }

        // Method to Get Department List
        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            var responseApi = new ResponseAPI<List<DepartmentDTO>>();
            var departmentDTOList = new List<DepartmentDTO>();

            try
            {
                foreach(var item in await _dbContext.Departments.ToListAsync())
                {
                    departmentDTOList.Add(new DepartmentDTO
                    {
                        DepartmentId = item.DepartmentId,
                        DepartmentName = item.DepartmentName,
                    });
                }

                responseApi.IsCorrect = true;
                responseApi.Value = departmentDTOList;

            }catch (Exception ex) {
                responseApi.IsCorrect = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }
    }
}
