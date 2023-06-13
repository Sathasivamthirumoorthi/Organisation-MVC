namespace Organization.Models
{
    public class Department
    {
        public Department() { 
            Employees = new List<Employee>();
        }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}
