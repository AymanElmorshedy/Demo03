using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo03.Models
{
    internal class Department
    {
        [Key]
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public DateOnly DateOfCreation { get; set; }
        public int Serial { get; set; }
        [InverseProperty(nameof(Employee.ManegedDepartment))]
        public Employee Manager { get; set; }
        [ForeignKey(nameof(Manager))]
        public int? ManegerId { get; set; }
        [InverseProperty(nameof(Employee.EmployeeDepartment))]
        public ICollection<Employee> Employees { get; set; }

    }
}
