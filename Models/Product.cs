using System.ComponentModel.DataAnnotations.Schema;

namespace Organization.Models
{

    public class Product{
         public Product() { 
            Employees = new List<Employee>();
            Customers = new List<Customer>();
        }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Customer> Customers { get; set; }

    }

}