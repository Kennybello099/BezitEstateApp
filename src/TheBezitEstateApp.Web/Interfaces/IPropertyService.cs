using System;
using System.Collections.Generic;
using System.Linq;
using TheBezitEstateApp.Data.Entities;
using System.Threading.Tasks;
using TheBezitEstateApp.Web.Models;

namespace TheBezitEstateApp.Web.Interfaces
{
    public interface IPropertyService
    {
        Task AddProperty(PropertyModel model);

        IEnumerable<Property> GetAllProperties();
    }
}