using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly ApplicationDbContext _context;

        public AccountController(
            ILogger<AccountController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == model.Email);
                if (user != null && user.Password == model.Password) // Note: Hash passwords in production
                {
                    _logger.LogInformation("User logged in.");

                    // Store user information in session
                    HttpContext.Session.SetString("UserName", user.Name);
                    HttpContext.Session.SetInt32("UserId", user.Id);

                    // Redirect to Dashboard
                    return RedirectToAction("Dashboard", new { id = user.Id });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: /Account/Register
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        // POST: /Account/Register

        
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new User(model.Name, model.Email, model.Phone, model.Password, "Customer");

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                _logger.LogInformation("User created a new account with password.");
                return RedirectToAction("Login", "Account");
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }



        // GET: /User/Dashboard
        public async Task<IActionResult> Dashboard(int id)
        {
            var user = await _context.Users
                .Include(u => u.Orders)
                .SingleOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            var products = await _context.Products.ToListAsync();
            ViewBag.Products = products;

            return View(user);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}
