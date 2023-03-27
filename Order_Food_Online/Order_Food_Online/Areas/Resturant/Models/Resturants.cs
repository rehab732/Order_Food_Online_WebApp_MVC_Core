using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order_Food_Online.Areas.Resturant.Models
{
    public class Resturants
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string RestName { get; set; } = string.Empty;
        public City City { get; set; }

        [Required]
        public string RestLocation { get; set; } = string.Empty;

        public virtual List<Items>? items { get; set; }
    }
}
