using WebApplication2.Models;

namespace WebApplication2.Models
{
	public class CartItem
	{
		public int Id { get; set; }
		public int CartId { get; set; }
		public int ProductId { get; set; }
		public int Quantity { get; set; }
		public Product Product { get; set; }
		public Cart Cart { get; set; }
		public int UserId { get; internal set; }

		public CartItem()
		{

		}

		public CartItem(int id, int productId, int quantity)
		{
			Id = id;
			ProductId = productId;
			Quantity = quantity;
		}
	}
}


