using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Examination.ViewModels;
using Examination.data;
using Microsoft.EntityFrameworkCore;

namespace Examination.Controllers
{
    public class AccountController : Controller
    {
        ExamContext db;
        public AccountController(ExamContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = db.Users.Include(s => s.Roles).FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

            if (!ModelState.IsValid || user == null)  
            {
                ModelState.AddModelError("","Invalid email or password");//add an error to the model state

                return View(model);
            }
          
            Claim claim1 = new Claim(ClaimTypes.Name, user.Name);
            Claim claim2 = new Claim(ClaimTypes.Email, user.Email);
 
            List<Claim> claims = new List<Claim>();
            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }
            
            ClaimsIdentity claimsIdentity1 = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            claimsIdentity1.AddClaim(claim1);
            claimsIdentity1.AddClaim(claim2);
            claimsIdentity1.AddClaims(claims);//AddClaims : as roles are list
            ClaimsPrincipal claimsPrincipal1 = new ClaimsPrincipal();
            claimsPrincipal1.AddIdentity(claimsIdentity1);
            await HttpContext.SignInAsync(claimsPrincipal1);
            string controller = ""; // any default value
            if (User.IsInRole("Admin"))
            {
                controller = "User";
            }
            else if (User.IsInRole("Student"))
            {
                controller ="Exam";// demand Home action
            }
            else // Instructor 
            {
                controller = "Report";// i will modify it ,any controller here should  implement Home action and view 
            }
            return RedirectToAction("Home", controller);
        }
        public async Task<IActionResult> Logout()
        {
            // delete user Cookie
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }
    }
}
