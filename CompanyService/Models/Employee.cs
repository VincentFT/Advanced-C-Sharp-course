using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyService.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public uint Age { get; set; }
        public double Salary { get; set; }
        public int DepartmentId { get; set; }
    }
}