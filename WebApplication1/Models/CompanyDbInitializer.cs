using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class CompanyDbInitializer : DropCreateDatabaseAlways<CompanyContext>
    {
        protected override void Seed(CompanyContext db)
        {

            db.Departments.Add(new Department { Id = 1, Name = "Отдел 1" });
            db.Departments.Add(new Department { Id = 2, Name = "Отдел 2" });
            db.Departments.Add(new Department { Id = 3, Name = "Отдел 3" });

            db.Employees.Add(new Employee { Id = 1, DepartmentId = 1, Name = "Иван", Surname = "Иванов", Age = 33, Salary = 1000000.0 });
            db.Employees.Add(new Employee { Id = 2, DepartmentId = 2, Name = "Петр", Surname = "Петров", Age = 23, Salary = 2000000.0 });
            db.Employees.Add(new Employee { Id = 3, DepartmentId = 2, Name = "Сидор", Surname = "Сидоров", Age = 33, Salary = 5000000.0 });
            db.Employees.Add(new Employee { Id = 4, DepartmentId = 3, Name = "Иван", Surname = "Петров", Age = 33, Salary = 8000000.0 });
            db.Employees.Add(new Employee { Id = 5, DepartmentId = 3, Name = "Сидор", Surname = "Иванов", Age = 33, Salary = 3000000.0 });
            db.Employees.Add(new Employee { Id = 6, DepartmentId = 3, Name = "Петр", Surname = "Сидоров", Age = 33, Salary = 2000000.0 });

            base.Seed(db);
        }
    }
}