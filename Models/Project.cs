using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organization.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Display(Name = "Name")]
        public string ProjectName { get; set; }

        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }

        [Display(Name = "Status")]
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
