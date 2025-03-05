using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]


namespace Demo03.Models
{
    internal class Employee
    {
        [Key]
        public int ÈmpId { get; set; }
        public string? EmpName { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public int? Test { get; set; }
        public required string  PhoneNumber { get; set; }
        public string? Password { get; set; }
        public Address EmpAddress { get; set; }
        [InverseProperty(nameof(Department.Manager))]
        public virtual Department? ManegedDepartment { get; set; }
        [InverseProperty(nameof(Department.Employees))]
        public virtual Department EmployeeDepartment { get; set; }
        [ForeignKey(nameof(EmployeeDepartment))]
        public int? DepartmentId { get; set; }
    }
}
