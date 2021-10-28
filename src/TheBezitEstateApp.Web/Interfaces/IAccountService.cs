using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBezitEstateApp.Web.Models;
using TheBezitEstateApp.Data.Entities;

namespace TheBezitEstateApp.Web.Interfaces
{
    public interface IAccountService
    {
        Task<ApplicationUser> CreateUserAsync(RegisterModel model);

    }
}