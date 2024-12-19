using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class CartViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Cart> Carts { get; set; }
    }
}
