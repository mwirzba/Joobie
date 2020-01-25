using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Joobie.Models.JobModels;
using Joobie.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace Joobie.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(
           UserManager<IdentityUser> userManager,
           SignInManager<IdentityUser> signInManager,
           ILogger<RegisterModel> logger,
           IEmailSender emailSender,
           RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress(ErrorMessage = "Zły format adresu email")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "{0} musi mieć co najmniej {2} znaków i maksymanie {1} znaków", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Hasło")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Potwierdź Hasło")]
            [Compare("Password", ErrorMessage = "Hasla muszą się zgadzać")]
            public string ConfirmPassword { get; set; }

            
            [Display(Name = "Nazwa Firmy")]
            public string Name { get; set; }

            [Display(Name = "Nip")]
            public string Nip { get; set; }

        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            string role = Request.Form["rdUserRole"].ToString();

            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    Name = Input.Name,
                    Nip = Input.Nip
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {

                    if (!await _roleManager.RoleExistsAsync(Strings.AdminUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(Strings.AdminUser));
                    }
                    if (!await _roleManager.RoleExistsAsync(Strings.ModeratorUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(Strings.ModeratorUser));
                    }
                    if (!await _roleManager.RoleExistsAsync(Strings.EmployeeUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(Strings.EmployeeUser));
                    }
                    if (!await _roleManager.RoleExistsAsync(Strings.CompanyUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(Strings.CompanyUser));
                    }

                    if (role == Strings.AdminUser)
                    {
                        await _userManager.AddToRoleAsync(user, Strings.AdminUser);
                    }
                    else if (role == Strings.ModeratorUser)
                    {
                        await _userManager.AddToRoleAsync(user, Strings.ModeratorUser);
                    }
                    else if (role == Strings.EmployeeUser)
                    {
                        await _userManager.AddToRoleAsync(user, Strings.EmployeeUser);
                    }
                    else if (role == Strings.CompanyUser)
                    {
                        await _userManager.AddToRoleAsync(user, Strings.CompanyUser);
                    }
                    else
                    {
                        if (Input.Name == null && Input.Nip == null)
                        {
                            await _userManager.AddToRoleAsync(user, Strings.EmployeeUser);
                        }
                        else
                        {
                            await _userManager.AddToRoleAsync(user, Strings.CompanyUser);
                        }
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }

                    return RedirectToAction("Index", "User");

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
