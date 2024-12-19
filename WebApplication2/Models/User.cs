using System.Collections.Generic;

namespace WebApplication2.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        // Navigation property for orders
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Cart> Carts { get; set; } = new List<Cart>();

        // Default constructor
        public User()
        {
        }

        // Parameterized constructor
        public User(string name, string email, string phone, string password, string role)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Password = password;
            Role = role;
        }
    }
}
