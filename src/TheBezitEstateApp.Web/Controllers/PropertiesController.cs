using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheBezitEstateApp.Web.Interfaces;
using TheBezitEstateApp.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace TheBezitEstateApp.Web.Controllers
{
    // [Authorize]
    public class PropertiesController : Controller
    {
    
        private readonly IPropertyService _properService;
        public PropertiesController(IPropertyService  propertyService)
        {
            _properService = propertyService;
        }

        [AllowAnonymous] //This allow people that are not signed in to access this particular method.
        [HttpGet]
         public IActionResult Index()
        {
            var getProperty = _properService.GetAllProperties();
            return View(getProperty);
        }
        [Authorize] //This will disalow usser to add page if they didnt log in
        [HttpGet] //Remember to commit this to git "Authorize"
        public IActionResult Add()
        {
            return View();
        }

         //The authorize will disalow user to access this if user did not log in
        [HttpPost]
        public async Task<IActionResult> Add(PropertyModel model )
        {
            try
            {
                if(model == null)
                {
                    await _properService.AddProperty(model);
                    
                    return RedirectToAction(nameof(Index)); 
                }
                var errorMessage = "Property already exists!";
                ModelState.AddModelError("", errorMessage);
                return RedirectToAction(nameof(Index)); 

            }
            catch (Exception ex) 
            {
                ModelState.AddModelError("", ex.Message);

                return RedirectToAction(nameof(Index));
            }
        }

       
    }
}