using System.ComponentModel.DataAnnotations.Schema;

namespace Organization.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }


        public DateTime DueDate { get; set; }

        public string Status { get; set; }

        // Foreign Key
        [ForeignKey("Product")]
        public int ProductID { get; set; }

        // Navigation property
        public Product? Product { get; set; }

        // Employee IDs selected for the project
        public ICollection<Employee> SelectedEmployees { get; set; }
    }
}
