using AspNetCoreCookieAuth.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Threading.Tasks;


namespace AspNetCoreCookieAuth.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LogInModel LogInModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var isValid = true; //TODO: refactorizar validando el usuario y el pasaword
                if(!isValid)
                {
                    ModelState.AddModelError("", "username or password is invalid");
                    return Page();
                }

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, LogInModel.Username));
                identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));

                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties{IsPersistent = LogInModel.RememberMe});

                return RedirectToPage("Index");

            }

            return Page();
        }


    }
}