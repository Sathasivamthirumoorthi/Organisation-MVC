using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organization.Models
{

    public class Product{
         public Product() { 
            Employees = new List<Employee>();
            Customers = new List<Customer>();
        }

        public int ProductID { get; set; }

        [Display(Name = "Name")]
        public string ProductName { get; set; }

        [Display(Name = "Manager Name")]
        public string ProductManagerName { get; set; }

        [Display(Name = "Revenue")]
        public int ProductRevenue { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Customer> Customers { get; set; }

    }

}