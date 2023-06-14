using System.ComponentModel.DataAnnotations;

namespace Organization.Models
{
    public class Department
    {
        public Department() { 
            Employees = new List<Employee>();
        }
        public int DepartmentID { get; set; }

        [Display(Name = "Name")]
        public string? DepartmentName { get; set; }

        [Display(Name = "Location")]
        public string? DepartmentLocation { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}
