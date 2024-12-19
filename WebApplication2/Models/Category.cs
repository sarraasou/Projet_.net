using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }              // Identifiant unique de la catégorie

        [Required]
        [StringLength(100)]
        public string Name { get; set; }         // Nom de la catégorie

        [StringLength(500)]
        public string Description { get; set; }   // Description de la catégorie

        [Url]
        public string ImageUrl { get; set; }      // URL ou chemin de l'image de la catégorie

        public ICollection<Product> Products { get; set; }
    }
}
