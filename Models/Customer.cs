using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organization.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [Display(Name = "Name")]
        public string ?CustomerName { get; set; }

        [Display(Name = "Contact Number")]
        public int CustomerPhoneNumber { get; set; }

        [Display(Name = "Email")]
        public string ?CustomerEmail {get;set;}

        [ForeignKey("Product")]
        public int ProductID {get; set;}
        
        public Product? Product { get; set; }
        

    }

}
