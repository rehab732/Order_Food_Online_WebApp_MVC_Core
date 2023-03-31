using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Order_Food_Online.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required(ErrorMessage = "Must Enter Your First Name")]
        [StringLenght(100)]
        public string FirstName { get; set; }



        [Required(ErrorMessage = "Must Enter Your Last Name")]
        [StringLenght(100)]
        public string LastName { get; set; }


        public byte[]? ProfilePicture { get; set; }

        public string CardNum { get; set; }

        public Gender Gender { get; set; }


        [Required]
        [MinimumAge(20, 50, ErrorMessage = "Your Age Must Be Between (20,50)")]
        public int Age { get; set; }

        [Required]
        public UserCity City { get; set; }


    }
}
