using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Product
    {
        public int Id { get; set; }            // Identifiant unique du produit
        public string Name { get; set; }       // Nom du produit
        public string Description { get; set; } // Description du produit

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }     // Prix du produit
        public string ImageUrl { get; set; }   // URL de l'image du produit

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // Navigation properties
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
