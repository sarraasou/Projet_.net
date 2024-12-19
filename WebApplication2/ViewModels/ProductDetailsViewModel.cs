using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class ProductDetailsViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public int UserId { get; set; } // Ajouté pour passer l'ID de l'utilisateur
    }
}


