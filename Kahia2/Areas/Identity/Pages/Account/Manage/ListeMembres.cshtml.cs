using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kahia2.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Kahia2.Areas.Identity.Pages.Account.Manage
{
    public class ListeMembresModel : PageModel
    {
        private readonly UserManager<Utilisateur> userManager;

        public ListeMembresModel(UserManager<Utilisateur> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IActionResult> OnGet()
        {
            List<Utilisateur> lu = await this.userManager.Users.ToListAsync();
            foreach(Utilisateur u in lu)
            {
                List<string> lr = (List<string>) await this.userManager.GetRolesAsync(u);
                u.Role = lr[0];
            }
            ViewData["USERS"] = lu;
            return Page();
        }
    }
}
