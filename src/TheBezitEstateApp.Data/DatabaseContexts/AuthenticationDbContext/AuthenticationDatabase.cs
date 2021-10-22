using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheBezitEstateApp.Data.Entities;

namespace TheBezitEstateApp.Data.DatabaseContexts.AuthenticationDbContext
{
    public class AuthenticationDatabase : IdentityDbContext<ApplicationUser>
    {
        public AuthenticationDatabase(DbContextOptions<AuthenticationDatabase> options)
            :base(options)
        {
            
        }
    }
}