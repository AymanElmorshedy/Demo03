using Demo03.Dbcontexts;
using Demo03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Demo03.Data
{
    internal static class CompanyDbContextSeed
    {
        public static bool DataSeeding(ApplicationDbContext dbContext)
        {
            try
            {
                if (!dbContext.Employees.Any())
                {
                    var EmployeesData = File.ReadAllText("Files\\employees.json");
                    var Employees = JsonSerializer.Deserialize<List<Employee>>(EmployeesData);
                    if (Employees?.Count > 0)
                    {
                        //foreach (var Employee in Employees)
                        //{
                        //    dbContext.Employees.Add(Employee);
                        //}
                        dbContext.AddRange(Employees);
                        dbContext.SaveChanges();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
