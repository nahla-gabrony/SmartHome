using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Data.ViewModels.Account
{
    public class SignUpViewModel
    {
        public string Id { get; set; }

        public int HomeUserId { get; set; }

        [Required(ErrorMessage = "Please Enter User First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter User Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter User Email")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email")]
        public string Email { get; set; }

        [Compare("ConfirmPassword", ErrorMessage = "Password don't match")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Please Enter User Home Address")]
        [Display(Name = "Home Address")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Please Enter User Phone Number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public int UserType { get; set; }

        public IFormFile CoverPhoto { get; set; }

        public string ExistPhoto { get; set; }

        public IList<string> Roles { get; set; } = new List<string>();
    }
}
