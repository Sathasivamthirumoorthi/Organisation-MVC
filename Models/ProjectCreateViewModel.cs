namespace Organization.Models
{
    public class ProjectCreateViewModel
    {
        public string ProjectName { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public int ProductID { get; set; }
        public List<string> SelectedEmployees { get; set; }
    }

}
