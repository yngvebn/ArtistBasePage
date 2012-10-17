using System.ComponentModel.DataAnnotations;

namespace ArtistBasePage.Areas.Admin.ViewModels
{
    public class RegisterNewUserViewModel
    {
        public string Password { get; set; }

        [Compare("Password", ErrorMessage="Passwords doesn't match")]
        public string ComparePassword { get; set; }
        public string Username { get; set; }
    }
}