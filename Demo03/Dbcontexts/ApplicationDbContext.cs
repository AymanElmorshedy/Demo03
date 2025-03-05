using Demo03.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo03.Dbcontexts
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<Employee>  Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer("Server=.;Database=Demo;Trusted_Connection=true;TrustServerCertificate=true");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .OwnsOne(e => e.EmpAddress, Address => Address.WithOwner());

            modelBuilder.Entity<Department>()
                .Ignore(d=>d.Serial);

            modelBuilder.Entity<Department>()
                .HasData(
                new Department() {DeptId=4,DeptName="Design",DateOfCreation=new DateOnly(2024,12,13) },
                     new Department() {DeptId=5,DeptName="Sotware",DateOfCreation=new DateOnly(2024,1,13) }
                );

            modelBuilder.Entity<Employee>()
                .Ignore(e => e.Test);
        }

    }
}
