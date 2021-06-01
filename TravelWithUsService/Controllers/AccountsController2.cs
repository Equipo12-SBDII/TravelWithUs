using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelWithUs.DBContext.Repositories;
using TravelWithUs.Models;

namespace  TravelWithUsService.Controllers
{

    //Pasar en los redirect to Login la razon por la que tiene que 
    public class AccountController2 : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        //private readonly IShoppingCartRepository shoppingCartRepository;

        public ILogger<AccountController2> logger { get; }

        public AccountController2(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,ILogger<AccountController> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
        }

        public void AccessDenied()
        {
            //redireccionar para una pagina de acceso denegado
        }

        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
                //return RedirectToAction("Index", "Home");
                return NotFound(;)

            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var result = await userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                text = "You have been successfully registered";
                //mostar pagina con este mensaje
                return ok(text)
            }
            text = "Email cannot be confirmed";
            return //algo con error d confirmacion              
        }

        [HttpGet]
        [AllowAnonymous]
        public ViewResult Register()
        {
           //redir
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var u = await userManager.FindByNameAsync(model.UserName);
                if (!(u is null))
                {
                    ViewBag.UserName = $"Username {model.UserName} already in use";
                    return View();
                }
                u = await userManager.FindByEmailAsync(model.Email);
                if (!(u is null))
                {
                    ViewBag.Email = $"Email {model.Email} already in use";
                    return View();
                }

                ShoppingCart shoppingCart = new ShoppingCart();
                shoppingCartRepository.AddEntity(shoppingCart);

                var user = new User {
                    UserName = model.UserName,
                    Email = model.Email,
                    Name = model.Name,
                    LastName = model.LastName,
                    Info = model.Info,
                    ShoppingCartId = shoppingCart.Id,
                    Active = true
                };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    /*Para el login con email
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action("ConfirmEmail", "Account",
                        new { userId = user.Id, token = token }, Request.Scheme);
                    logger.Log(LogLevel.Warning, confirmationLink);                   
                    return View("RegistrationSuccessfulView");
                    //*/

                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage: error.Description);
                    }
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Logout_Get()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        [AllowAnonymous]
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                //var x = await userManager.FindByNameAsync(model.UserName);
                //Arreglar para hacer el RememberMe
                var result = await signInManager.PasswordSignInAsync(model.UserName, 
                                                    model.Password, true, false);
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(ReturnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return Redirect(ReturnUrl);
                }
                ModelState.AddModelError("", errorMessage: "Invalid Login Attempt");
            }
            return View(model);
        }

        [HttpPost]
        [HttpGet]
        public async Task<IActionResult> IsUserNameInUsed(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user is null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Username {username} already in use");
            }
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);
                if (user == null)
                    return RedirectToAction("Login");

                var result = await userManager.ChangePasswordAsync
                    (user, model.CurrentPassword, model.NewPassword);

                if(!result.Succeeded)
                {
                    foreach(var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
                    return View();
                }

                await signInManager.RefreshSignInAsync(user);
                return View("ChangePasswordConfirmation");
            }
            return View(model);
        }
    }
}
