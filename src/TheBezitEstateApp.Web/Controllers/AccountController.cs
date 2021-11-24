using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheBezitEstateApp.Web.Models;
using TheBezitEstateApp.Web.Interfaces;
using Microsoft.AspNetCore.Identity;
using TheBezitEstateApp.Data.Entities;

namespace TheBezitEstateApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(IAccountService accountService, 
            SignInManager<ApplicationUser> signInManager)
        {
            _accountService = accountService;
            _signInManager = signInManager;
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
             return LocalRedirect("~/");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {

            try
            {
                //if they pass in the right email and password and if their email/password is wrong it throws error using the false.

                var result = await  _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false ); //this will sign the user in
                if(!result.Succeeded)
                {
                     var errorMessage = "Login failed, please check your details again!";
                     ModelState.AddModelError("", errorMessage);
                    return View();
                }
                return LocalRedirect("~/"); // this will log in the user
               
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }



        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if(!ModelState.IsValid) return View();

            try
            {
               var user = await _accountService.CreateUserAsync(model);
               await _signInManager.SignInAsync(user, isPersistent: false); //this will sign them in after creating the user;
               return LocalRedirect("~/"); //after signng a user in, this will return the user to the homepage of our application

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }           
           
        }
        
    }
}