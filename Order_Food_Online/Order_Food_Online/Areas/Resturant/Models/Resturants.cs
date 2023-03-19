using System.ComponentModel.DataAnnotations;

namespace Order_Food_Online.Areas.Resturant.Models
{
    public class Resturants
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string RestName { get; set; } = string.Empty;
        public City City { get; set; }
        [Required]
        public string RestLocation { get; set; } = string.Empty;

        public List<Items> items { get; set; }
    }
}
