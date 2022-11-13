using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using NPMS.Models;
using NPMS.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NPMS.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<AccountController> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _logger = logger;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }




        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Copy data from RegisterViewModel to IdentityUser
                var user = new IdentityUser(model.Username)
                {
                    Email = model.Email
                };
                //string message = $"Attempting to Register a user {model.Username}";
                _logger.LogInformation((EventId)101,"Attempting to register a user {user} on {date}",model.Username,DateTime.UtcNow);

                // Store user data in AspNetUsers database table
                var result = await userManager.CreateAsync(user, model.Password);

                // If user is successfully created, sign-in the user using
                // SignInManager and redirect to index action of HomeController
                if (result.Succeeded)
                {
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action("ConfirmEmail", "Email", new { token, email = model.Email }, Request.Scheme);
                    EmailHelper emailHelper = new EmailHelper();
                    bool emailResponse = emailHelper.SendEmail(model.Email, confirmationLink);
                    if (emailResponse)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Email Failed");
                    }
                    bool emailStatus = await userManager.IsEmailConfirmedAsync(user);
                    if (emailStatus)
                    {
                        await signInManager.SignInAsync(user, isPersistent: false);
                        //message = $"Successfully registered user {model.Username}";
                        _logger.LogInformation((EventId)102, "Successfully registered a user {user} on {date}", model.Username, DateTime.UtcNow);
                    }
                    else
                    {
                        //ModelState.AddModelError(string.Empty, "Verify the User");
                        return View("Error", "Email");
                    }
                }
                    
                    
                

                // If there are any errors, add them to the ModelState object
                // which will be displayed by the validation summary tag helper
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl)
        {

            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                _logger.LogInformation((EventId)103, "Sign in attempt by user {user} on {date}", model.Username, DateTime.UtcNow);
                var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure:true);
                if(result.Succeeded)
                {
                 return RedirectToAction("Index", "Home");
                        
                }
               
                if(result.IsLockedOut)
                {
                    //message = $"The user {model.Username} account is locked.";
                    //_logger.LogWarning(message);
                    _logger.LogWarning((EventId)104, "User {user} attempting to login on {date} when locked out", model.Username, DateTime.UtcNow);
                    return View("Lockout");
                }
                else
                {
                    _logger.LogWarning((EventId)105, "Failed attempt by user {user} on {date}", model.Username, DateTime.UtcNow);
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                    

                }
            }
            return View(model);
        }
        [Authorize]
        [HttpGet]
        public IActionResult ChangePassword() => View(new ChangePasswordViewModel());
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await userManager.ChangePasswordAsync(await userManager.GetUserAsync(User), model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    _logger.LogWarning((EventId)110, "Password changed by user {user} on {date}", await userManager.GetUserAsync(User), DateTime.UtcNow);
                    return View("ChangePasswordSuccess");
                }

                foreach (var error in result.Errors)
                {
                    _logger.LogWarning((EventId)111, "Password change failed by user {user} on {date}", await userManager.GetUserAsync(User), DateTime.UtcNow);
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
    }
}
