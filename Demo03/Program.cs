using Demo03.Data;
using Demo03.Dbcontexts;
using Demo03.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using ApplicationDbContext dbcontext = new ApplicationDbContext();

            #region Data Seeding
            #region Manual Data Seeding
            //Department department01 = new Department()
            //{
            //    DeptName = "HR",
            //    DateOfCreation = new DateOnly(2024, 7, 25)
            //};
            //dbcontext.Add(department01);
            //dbcontext.SaveChanges();

            //List<Department> departments = new List<Department>()
            //{
            //    new Department(){DeptName="IT",DateOfCreation=new DateOnly(2024,5,23) },
            //    new Department(){DeptName="Devolopment",DateOfCreation=new DateOnly(2023,4,30) }
            //};
            //dbcontext.AddRange(departments);
            //dbcontext.SaveChanges();
            #endregion

            #region Dynamic Data Seeding
            //bool Flag = CompanyDbContextSeed.DataSeeding(dbcontext);
            //if (Flag)
            //    Console.WriteLine("Done");
            //else
            //    Console.WriteLine("Unfinshed");
            #endregion
            #endregion

            #region Navigation Properity - RelatedData
            #region EX01
            //var emp01 = dbcontext.Employees.FirstOrDefault(e => e.ÈmpId == 1);

            //if (emp01 is not null)
            //{
            //    Console.WriteLine($"Employee Name : {emp01.EmpName}");
            //    Console.WriteLine($"Department Id Name : {emp01.DepartmentId}");
            //    Console.WriteLine($"Department Name : {emp01.EmployeeDepartment?.DeptName}");//Related Data

            //    var EmpDepartment=dbcontext.Departments.FirstOrDefault(d=>d.DeptId==emp01.DepartmentId);
            //    Console.WriteLine($"Department Name : {EmpDepartment?.DeptName}");//Related Data
            //} 
            #endregion

            #region Eager Loading
            //var emp01WithDepartment = dbcontext.Employees.Include(e => e.EmployeeDepartment).FirstOrDefault(e => e.ÈmpId == 1);

            //if (emp01WithDepartment is not null)
            //{
            //    Console.WriteLine($"Employee Name : {emp01WithDepartment.EmpName}");
            //    Console.WriteLine($"Department Id  : {emp01WithDepartment.DepartmentId}");
            //    Console.WriteLine($"Department Name : {emp01WithDepartment.EmployeeDepartment?.DeptName}");//Related Data Load Eager Loading

            //}

            //var Emp01WithManegedDepartment = dbcontext.Employees.Include(e => e.ManegedDepartment)
            //                                                                                    .FirstOrDefault(e => e.ÈmpId == 1);
            //if (Emp01WithManegedDepartment is not null)
            //{
            //    Console.WriteLine($"Employee Name : {Emp01WithManegedDepartment.EmpName}");
            //    Console.WriteLine($"Department Id  : {Emp01WithManegedDepartment.ManegedDepartment?.DeptId}");
            //    Console.WriteLine($"Maneged Department Name : {Emp01WithManegedDepartment.ManegedDepartment?.DeptName}");//Related Data Load Eager Loading
            //}

            //var EmployeeWithDepartment=dbcontext.Employees.Include(e=>e.EmployeeDepartment)
            //    .ThenInclude(e=>e.Manager)
            //    .FirstOrDefault(e=>e.ÈmpId==3);
            //if (EmployeeWithDepartment is not null)
            //{

            //    Console.WriteLine($"Employee Name : {EmployeeWithDepartment.EmpName}");
            //    Console.WriteLine($"Department Id  : {EmployeeWithDepartment.DepartmentId}");
            //    Console.WriteLine($"Maneged Department Name : {EmployeeWithDepartment.EmployeeDepartment?.DeptName}");//Related Data Load Eager Loading
            //    Console.WriteLine($"Department Maneger Id: {EmployeeWithDepartment.EmployeeDepartment?.Manager?.ÈmpId}");
            //    Console.WriteLine($"Department Maneger Name: {EmployeeWithDepartment.EmployeeDepartment?.Manager?.EmpName}");

            //}

            //var emp01WithDepartment = dbcontext.Employees.Include(e => e.EmployeeDepartment)
            //    .Where(e => e.EmployeeDepartment.DeptName=="HR")
            //    .Select(e=>new {e.EmpName,e.EmployeeDepartment.DeptName })
            //    .ToList();

            //if (emp01WithDepartment is not null)
            //{
            //   foreach (var item in emp01WithDepartment)
            //        Console.WriteLine(item);
            //        //Console.WriteLine($"Emp Name={item.EmpName} :: Department Name={item.EmployeeDepartment?.DeptName}");


            //}
            #endregion

            #region Explcit-Loading
            #region Exampel 01
            //var emp01WithDepartment = dbcontext.Employees.FirstOrDefault(e=>e.ÈmpId==1);
            //if (emp01WithDepartment is not null)
            //{
            //    Console.WriteLine($"Employee Name : {emp01WithDepartment.EmpName}");
            //    Console.WriteLine($"Department Id  : {emp01WithDepartment.DepartmentId}");

            //    dbcontext.Entry( emp01WithDepartment ).Reference(e=>e.EmployeeDepartment).Load();

            //    Console.WriteLine($"Department Name : {emp01WithDepartment.EmployeeDepartment?.DeptName}");//Related Data Load Explcit Loading

            //} 
            #endregion

            #region Exampel 02
            //var dep01 = dbcontext.Departments.FirstOrDefault(d => d.DeptId == 1);
            //if (dep01 is not null)
            //{
            //    Console.WriteLine($"Depatment Name :{dep01.DeptName}");
            //    dbcontext.Entry(dep01).Collection(d => d.Employees).Query().Where(e=>e.Age>25).Load();
            //    foreach(var item in dep01.Employees)
            //        Console.WriteLine(item.EmpName);
            //}
            #endregion
            #endregion

            #region Lazy-Loading
            //var emp01 = dbcontext.Employees.FirstOrDefault(e => e.ÈmpId == 1);

            //if (emp01 is not null)
            //{
            //    Console.WriteLine($"Employee Name : {emp01.EmpName}");
            //    Console.WriteLine($"Department Id Name : {emp01.DepartmentId}");
            //    Console.WriteLine($"Department Name : {emp01.EmployeeDepartment?.DeptName}");//Related Data

                
            //}

            var Dep01=dbcontext.Departments.FirstOrDefault(d=>d.DeptId==1);
            if (Dep01 is not null)
            {
                Console.WriteLine(Dep01.DeptName);
                Console.WriteLine(Dep01.DateOfCreation);

                foreach(var emp in Dep01.Employees)
                    Console.WriteLine($"---------{emp.EmpName}");
            }
            #endregion

            #endregion
        }
    }
}
