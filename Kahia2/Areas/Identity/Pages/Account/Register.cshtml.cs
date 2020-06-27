using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Kahia2.Admin.Models;
using Kahia2.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace Kahia2.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<Utilisateur> _signInManager;
        private readonly UserManager<Utilisateur> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(
            UserManager<Utilisateur> userManager,
            SignInManager<Utilisateur> signInManager,
            ILogger<RegisterModel> logger,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            this._roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Mot de Passe")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmation du mot de passe ")]
            [Compare("Password", ErrorMessage = "Le mot de passe et sa confirmation ne correspondent pas.")]
            public string ConfirmPassword { get; set; }

            public string Role { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ViewData["ROLES"] = new SelectList(_roleManager.Roles.ToList(), "NormalizedName", "Name");
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                var user = new Utilisateur { UserName = Input.Email, Email = Input.Email, Role = Input.Role };

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("Utilisateur crée avec un nouveau mot de passe");

                    // Creation des différents roles
                    if (!await _roleManager.RoleExistsAsync("ADMIN"))
                    {
                        await _roleManager.CreateAsync(new IdentityRole("ADMIN"));
                    }

                    if (!await _roleManager.RoleExistsAsync("MEDECIN"))
                    {
                        await _roleManager.CreateAsync(new IdentityRole("MEDECIN"));
                    }

                    if (!await _roleManager.RoleExistsAsync("CHERCHEUR"))
                    {
                        await _roleManager.CreateAsync(new IdentityRole("CHERCHEUR"));
                    }

                    if (user.Role != null)
                    {
                        await _userManager.AddToRoleAsync(user, user.Role.ToString());
                    }

                    if (user.Role != null)
                    {
                        await _userManager.AddToRoleAsync(user, user.Role.ToString());
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "ADMIN");
                    }



                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["ROLES"] = new SelectList(_roleManager.Roles.ToList(), "NormalizedName", "Name");
            return Page();
        }
    }
}