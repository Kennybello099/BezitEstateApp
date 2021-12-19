using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheBezitEstateApp.Web.Models
{
    public class PropertyModel
    {
        [Required]
        public string Title {get; set;}

        [Required]
        public string ImageUrl {get; set;}

        [Required]
        public double Price {get; set;}

        [Required]
        public string Description {get; set;}

        [Required]
        public int NumberOfRooms {get; set;}

        [Required]
        public int NumberOfBaths {get; set;}

        [Required]
        public int NumberOfToilets {get; set;}

        [Required]
        public string Address {get; set;}

        [Required]
        public string ContactPhoneNumber {get; set;}
    }
    
}