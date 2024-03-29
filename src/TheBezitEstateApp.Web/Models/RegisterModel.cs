using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TheBezitEstateApp.Web.Models
{
    public class RegisterModel
    {
        [DisplayName("FullName")]
        [Required]
        public string FullName {get; set;}

        [DisplayName("Email Address")]
        [Required]
        [EmailAddress]
        public string Email {get; set;}

        [Required]
        [DataType(DataType.Password)]
        public string Password {get; set;}

        [DisplayName("Confirm Password")]
        [Required]
        [Compare(nameof(Password))] //this is used to compare if the two password are same
        public string ConfirmPassword {get; set;} 
    }
}