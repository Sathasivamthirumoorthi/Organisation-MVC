using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organization.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        [Display(Name = "Name")]
        public string ?EmployeeName { get; set; }

        [Display(Name = "Salary")]
        public decimal EmployeeSalary { get; set; }

        [Display(Name = "Age")]
        public decimal EmployeeAge { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        [ForeignKey("Product")]
        public int ProductID {get; set;}
        public Department? Department { get; set; }

        public Product? Product {get; set;}

        

    }

}
