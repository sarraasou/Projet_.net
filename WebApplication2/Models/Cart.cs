using System.Collections.Generic;

namespace WebApplication2.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Change to int to match User.Id
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public User User { get; set; }

        public Cart()
        {
        }

        public Cart(int id, int userId, List<CartItem> cartItems)
        {
            Id = id;
            UserId = userId;
            Items = cartItems;
        }
    }
}
