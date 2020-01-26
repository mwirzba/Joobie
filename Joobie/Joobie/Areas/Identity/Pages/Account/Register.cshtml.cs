using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Joobie.Models.JobModels;
using Joobie.Utility;
using Joobie.Validators;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private readonly string _savePath = "/Joobie/Joobie/wwwroot/CompanyIcons";

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

            [ImageValidation]
            public IFormFile Image { get; set; }

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
                    Nip = Input.Nip,
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
                            string imagePath = "default.png";
                            if (Request.Form.Files.Any())
                            {
                                string uniqueName = await GetUniqueFileName();
                                imagePath = Path.GetFileNameWithoutExtension(uniqueName)
                                    + Path.GetExtension(Input.Image.FileName);
                                bool saveImageSuccess = await SaveImageToDirectory(imagePath);
                                if (saveImageSuccess == false)
                                    ModelState.AddModelError(string.Empty, "Błąd podczas zapisu ikony");
                            }
                            user.CompanyImagePath = imagePath;
                            await _userManager.AddToRoleAsync(user, Strings.CompanyUser);
                        }
                    }
                    _userManager.Options.SignIn.RequireConfirmedAccount = true;
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area="Identity", userId = user.Id, code = code },
                       protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Potwierdź adres e-mail od Joobie :)",
                        $"Proszę o potwierdzenie swojego konta klikając w link <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>Tutaj :)</a>.");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, Strings.EmployeeUser);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private async Task<bool> SaveImageToDirectory(string fileName)
        {
            IFormFile file = Request.Form.Files.First();
            string pathSrc = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            pathSrc += _savePath;
            using (var stream = new FileStream(Path.Combine(pathSrc, fileName), FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return true;
        }

        private async Task<string> GetUniqueFileName()
        {
            string fileName = "";
            await Task.Run(() =>
            {
                fileName = Path.GetRandomFileName();
                string path = Path.Combine("~/wwwroot/CompanyIcons", fileName);
                while (System.IO.File.Exists(path))
                {
                    fileName = Path.GetRandomFileName();
                    path = Path.Combine("~/wwwroot/CompanyIcons", fileName);
                }
            });

            return fileName;
        }
    }
}
