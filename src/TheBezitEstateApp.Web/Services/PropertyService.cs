using System.Threading.Tasks;
using TheBezitEstateApp.Data.Entities;
using TheBezitEstateApp.Data.DatabaseContexts.ApplicationDbContext;
using TheBezitEstateApp.Web.Models;
using System.Collections.Generic;
using TheBezitEstateApp.Web.Interfaces;
using System;

namespace TheBezitEstateApp.Web.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly ApplicationDatabase _dbContext;

        public PropertyService(ApplicationDatabase dbcontext)
        {
            _dbContext = dbcontext;
        }

        public IEnumerable<Property> GetAllProperties()
        {
            return _dbContext.Properties;
        }


        public async Task AddProperty(PropertyModel model)
        {
            var property = new Property
            {
                Id = Guid.NewGuid().ToString(), //it is advise to generate Id in GUID
               Title = model.Title,
               ImageUrl =  model.ImageUrl,
               Price = model.Price,
               Description = model.Description,
               NumberOfRooms = model.NumberOfRooms,
               NumberOfBaths = model.NumberOfBaths,
               NumberOfToilets = model.NumberOfToilets,
               Address = model.Address,
               ContactPhoneNumber =  model.ContactPhoneNumber
            };

            await _dbContext.AddAsync(property); //this add it to the database
            await _dbContext.SaveChangesAsync(); //This save it into the database

            
        }
    }
}