using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheBezitEstateApp.Web.Models;

namespace TheBezitEstateApp.Web.Controllers
{
    public class PropertiesController : Controller
    {
    
        [HttpGet]
         public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Add(PropertyModel model )
        {
            throw new NotImplementedException();
        }

       
    }
}