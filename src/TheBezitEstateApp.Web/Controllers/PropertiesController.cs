using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TheBezitEstateApp.Web.Controllers
{
    [Route("[controller]")]
    public class PropertiesController : Controller
    {
        

        public PropertiesController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }

       
    }
}