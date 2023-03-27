using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace BlazorCrud_Shared
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "The field {0} is requerid")]
        public string EmployeeName { get; set; } = null!;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The field {0} is requerid\"")]
        public int DepartmentId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The field {0} is requerid\"")]
        public int Salary { get; set; }

        public DateTime ContractDate { get; set; }

        public DepartmentDTO? Department { get; set; }
    }
}
