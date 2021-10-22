using Microsoft.EntityFrameworkCore;
using TheBezitEstateApp.Data.Entities;

namespace TheBezitEstateApp.Data.DatabaseContexts.ApplicationDbContext
{
    public class ApplicationDatabase : DbContext
    {
        public ApplicationDatabase(DbContextOptions<ApplicationDatabase> options)
        :base(options)       
        {            
        }

        public DbSet<Property> Properties {get; set;}

        public DbSet<Contact> Contacts {get; set;}
        
    }
}