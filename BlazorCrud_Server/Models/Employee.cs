using System;
using System.Collections.Generic;

namespace BlazorCrud_Server.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public int DepartmentId { get; set; }

    public int Salary { get; set; }

    public DateTime ContractDate { get; set; }

    public virtual Department Department { get; set; } = null!;
}
