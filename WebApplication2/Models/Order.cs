using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShippingAddress { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        // Foreign key property
        public User User { get; set; }

        public Order()
        {
        }

        public Order(int id, int userId, DateTime orderDate, string shippingAddress, decimal totalPrice)
        {
            Id = id;
            UserId = userId;
            OrderDate = orderDate;
            ShippingAddress = shippingAddress;
            TotalPrice = totalPrice;
        }
    }
}
