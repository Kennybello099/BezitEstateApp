using Microsoft.AspNetCore.Identity;

namespace TheBezitEstateApp.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName {get; set;} //we added this property so we can use it in our accountservices
        //Each time you add a new property to your entites,
        //you need to run a new migration. we run run migration to add FullName in our db
    }
}