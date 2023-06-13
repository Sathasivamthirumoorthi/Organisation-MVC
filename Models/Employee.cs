using System.ComponentModel.DataAnnotations.Schema;

namespace Organization.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public decimal EmployeeSalary { get; set; }
        public decimal EmployeeAge { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department? Department { get; set; }

        

    }

}
