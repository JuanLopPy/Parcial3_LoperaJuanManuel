using Parcial3.DAL;
using Parcial3.DAL.Entities;
using Parcial3.Enum;
using Parcial3.Helpers;
using Parcial3.Models;
using Parcial3.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial3.DAL;
using Parcial3.Helpers;
using Parcial3.Models;
using ECommerce_Sat.Models;
using System.Diagnostics.Metrics;
using Parcial3;

namespace ECommerce_Sat.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserHelper _userHelper;
        private readonly DataBaseContext _context;


        public AccountController(IUserHelper userHelper, DataBaseContext context)
        {
            _userHelper = userHelper;
            _context = context;

        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new LoginViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _userHelper.LoginAsync(loginViewModel);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Email o contraseña incorrectos.");
            }
            return View(loginViewModel);
        }
        public async Task<IActionResult> Logout()
        {
            await _userHelper.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Unauthorized()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            Guid emptyGuid = new Guid();

            AddUserViewModel addUserViewModel = new()
            {

                UserType = UserType.User,
            };

            return View(addUserViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {

                User user = await _userHelper.AddUserAsync(addUserViewModel);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Este correo ya está siendo usado.");

                    return View(addUserViewModel);
                }

                //Autologeamos al nuevo usuario que se registra
                LoginViewModel loginViewModel = new()
                {
                    Password = addUserViewModel.Password,
                    RememberMe = false,
                    Username = addUserViewModel.Username
                };

                var login = await _userHelper.LoginAsync(loginViewModel);

                if (login.Succeeded) return RedirectToAction("Index", "Home");
            }


            return View(addUserViewModel);
        }



        public async Task<IActionResult> EditUser()
        {
            User user = await _userHelper.GetUserAsync(User.Identity.Name);

            if (user == null) return NotFound();

            EditUserViewModel editUserViewModel = new()
            {
                Address = user.Address,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Document = user.Document
            };

            return View(editUserViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(EditUserViewModel editUserViewModel)
        {


            return View(editUserViewModel);
        }


        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                if (changePasswordViewModel.OldPassword == changePasswordViewModel.NewPassword)
                {
                    ModelState.AddModelError(string.Empty, "Debes ingresar una contraseña diferente.");
                    return View(changePasswordViewModel);
                }

                User user = await _userHelper.GetUserAsync(User.Identity.Name);

                if (user != null)
                {
                    IdentityResult result = await _userHelper.ChangePasswordAsync(user, changePasswordViewModel.OldPassword, changePasswordViewModel.NewPassword);
                    if (result.Succeeded) return RedirectToAction("EditUser");
                    else ModelState.AddModelError(string.Empty, result.Errors.FirstOrDefault().Description);
                }
                else ModelState.AddModelError(string.Empty, "Usuario no encontrado");
            }

            return View(changePasswordViewModel);
        }


     

    }
}


    
