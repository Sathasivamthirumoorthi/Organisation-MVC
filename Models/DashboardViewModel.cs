namespace Organization.Models
{
    public class DashboardViewModel
    {
        public int TotalProducts { get; set; }
        public int TotalCustomers { get; set; }

        public int TotalDepartments { get; set; }
        public int TotalEmployees { get; set; }

        public int[] TotalRevenues { get; set; }

        public int[] TotalProductEmployeeCount { get; set; }
        public string[] Products { get; set; }
    }
}
