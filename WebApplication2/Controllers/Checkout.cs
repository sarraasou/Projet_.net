using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class Checkout : Controller
    {
        // GET: Checkout
        public ActionResult Index()
        {
            return View();
        }

    }
}