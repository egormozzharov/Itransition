using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    [MetadataType(typeof(UserValidation))]
    public partial class User
    {
    }

    public class UserValidation
    {
        [Required(ErrorMessage = "This field must not be empty!")]
        [Display(Name = "UserId")]
        public int UserId { get; set; }


        [Required(ErrorMessage = "You must specify a login.")]
        [Display(
            Name = "Login",
            Description = "Choose something unique so others will know which contributions are yours."
        )]
        public string Login { get; set; }


        [Required(ErrorMessage = "You must specify a password.")]
        [StringLength(10,
            ErrorMessage = "You must specify a password of {2} or more characters.",
            MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", Description = "Passwords must be at least 7 characters long.")]
        public string Password { get; set; }        


        [Required(ErrorMessage = "You must specify an email address.")]
        [DataType(DataType.EmailAddress)]
        [Display(
            Name = "Email address",
            Description = "Your email will not be public. It is required to verify your registration and for " +
                            "password retrieval, important notifications, etc."
        )]
        public string Email { get; set; }

        
    }
}