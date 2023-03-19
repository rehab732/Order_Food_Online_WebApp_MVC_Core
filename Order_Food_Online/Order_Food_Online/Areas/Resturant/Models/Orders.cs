using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Order_Food_Online.Areas.Customer.Models;
using Order_Food_Online.Areas.Resturant.Models;
namespace Order_Food_Online.Areas.Resturant.Models
{
    public class Orders
    {
        // (order id, restaurant id, customer id, location, total price, Payment method).
        [Key]
        public int Id { get; set; }
        [ForeignKey("Customers")]
        public int CustomerId { get; set; }
        public Customers Customer { get; set; }
        [ForeignKey("Resturants")]
        public int RestaurantId { get; set; }
        public Resturants Restaurant { get; set; }

        [Required]
        public string Location { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItems> OrderItems { get; set; }



    }
}
