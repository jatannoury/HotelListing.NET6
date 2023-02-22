using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Models.Users
{
    public class ApiUserModel : LoginModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(15,ErrorMessage ="Your Password is limited to {2} to {1} characters",MinimumLength =6)] // minimum length is 6 and maximum is 15
        public string Password { get; set; }

    }
}
