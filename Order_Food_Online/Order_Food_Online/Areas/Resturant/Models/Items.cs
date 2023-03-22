using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order_Food_Online.Areas.Resturant.Models
{
    public class Items
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemsId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ItemName { get; set; } = string.Empty;
        [Required]

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        [ForeignKey("Resturants")]
        public int ResturantId { get; set; }
        public virtual Resturants Resturants { get; set; }

        public virtual List<OrderItems> OrderItems { get; set; }

    }
}
