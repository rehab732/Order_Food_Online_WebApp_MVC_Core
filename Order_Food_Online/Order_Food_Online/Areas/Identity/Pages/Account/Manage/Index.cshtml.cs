using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Order_Food_Online.Models;
using System.IO;

namespace Order_Food_Online.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "First Name")]
            public string ?FirstName { get; set; }
            [Required]
            [Display(Name = "Last Name")]
            public string? LastName { get; set; }

            [Required]
            [MinimumAge(20, 50)]
            [Display(Name = "Age")]
            public int Age { get; set; }

            [Required]
            [Display(Name = "Card Number")]
            public string? CardNum { get; set; }

            [Required]
            [Display(Name = "Gender")]
            public Gender Gender { get; set; }


            [Required]
            [Display(Name = "City")]
            public UserCity City { get; set; }

            [Display(Name ="Profile Picture")]
            public byte[] ?ProfilePicture { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string? PhoneNumber { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                CardNum = user.CardNum,
                Gender = user.Gender,
                City = user.City,
                PhoneNumber =phoneNumber,
                ProfilePicture=user.ProfilePicture
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var firstName = user.FirstName;
            var lastName = user.LastName;
            var Age = user.Age;
            var CardNum = user.CardNum;
            var Gender = user.Gender;
            var City = user.City;

            if (Input.FirstName != firstName)
            {
                user.FirstName = Input.FirstName;
                await _userManager.UpdateAsync(user);

            }
            if (Input.LastName != lastName)
            {
                user.LastName = Input.LastName;
                await _userManager.UpdateAsync(user);

            }
            if (Input.Age != Age)
            {
                user.Age = Input.Age;
                await _userManager.UpdateAsync(user);

            }
            if (Input.City != City)
            {
                user.City = Input.City;
                await _userManager.UpdateAsync(user);

            }
            if (Input.Gender != Gender)
            {
                user.Gender = Input.Gender;
                await _userManager.UpdateAsync(user);

            }
            if (Input.CardNum != CardNum)
            {
                user.CardNum = Input.CardNum;
                await _userManager.UpdateAsync(user);

            }


            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files.FirstOrDefault();
                using (var dataSream = new MemoryStream())
                {
                    await file.CopyToAsync(dataSream);
                    user.ProfilePicture = dataSream.ToArray();
                }
                await _userManager.UpdateAsync(user);
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
