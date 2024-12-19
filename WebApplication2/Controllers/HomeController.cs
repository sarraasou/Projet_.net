using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.ToListAsync();
            var products = await _context.Products.ToListAsync();
            var users = await _context.Users.ToListAsync();

            var model = new HomeViewModel
            {
                Categories = categories,
                Products = products,
                Users = users
            };

            return View(model);
        }
      

        public async Task<IActionResult> ListProduit()
        {
            var produits = await _context.Products.ToListAsync();
            var categories = await _context.Categories.ToListAsync();

            // Vérifier si des produits existent
            if (!produits.Any())
            {
                ViewData["Message"] = "Aucun produit disponible pour le moment.";
            }

            var viewModel = new ListProduitViewModel
            {
                Products = produits,
                Categories = categories
            };

            return View(viewModel); // Passer les produits à la vue
        }

        public async Task<IActionResult> ProduitDetails(int id)
        {
            // Récupérer le produit spécifique par son ID
            var produit = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            // Vérifier si le produit existe
            if (produit == null)
            {
                return NotFound(); // Retourner une page 404 si le produit n'est pas trouvé
            }

            var categories = await _context.Categories.ToListAsync();

            var model = new ProductDetailsViewModel
            {
                Product = produit,
                Categories = categories
            };

            return View(model); // Passer le produit à la vue
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
