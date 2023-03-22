using Order_Food_Online.Areas.Resturant.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order_Food_Online.Areas.Customer.Models
{
    public class Customers
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Must Enter Your First Name")]
        [StringLengthAttribute(30)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Must Enter Your Second Name")]
        [StringLengthAttribute(30)]
        public string SecondName { get; set; } = string.Empty;

        public string CardNum { get; set; } = string.Empty;

        [Required]
        public City City { get; set; }

        [Required]
        [MaxLength(11)]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [MinAge(20,50,ErrorMessage ="Your Age Must Be Between (20,50)")]
        public int Age { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public virtual List<Orders> Orders { get; set; }

    }
}
