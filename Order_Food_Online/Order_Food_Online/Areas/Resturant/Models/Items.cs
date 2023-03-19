using System.ComponentModel.DataAnnotations;

namespace Order_Food_Online.Areas.Resturant.Models
{
    public class Items
    {
        [Key]
        public int ItemsId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ItemName { get; set; } = string.Empty;
        [Required]

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }


    }
}
