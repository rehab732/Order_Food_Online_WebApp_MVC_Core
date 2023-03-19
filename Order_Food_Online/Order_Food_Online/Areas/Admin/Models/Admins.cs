using System.ComponentModel.DataAnnotations;

namespace Order_Food_Online.Areas.Admin.Models
{
    public class Admins
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
