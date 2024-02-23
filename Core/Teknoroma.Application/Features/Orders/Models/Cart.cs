namespace Teknoroma.Application.Features.Orders.Models
{
	public class Cart
	{
		public Dictionary<Guid, CartItem> _myCart = new Dictionary<Guid, CartItem>();

		public void AddItem(CartItem cartItem)
		{
			if (_myCart.ContainsKey(cartItem.ID))
			{
				_myCart[cartItem.ID].Quantity++;
				return;
			}
			_myCart.Add(cartItem.ID, cartItem);
		}

		public void UpdateItem(CartItem cartItem)
		{
			if (_myCart.ContainsKey(cartItem.ID))
			{
				_myCart[cartItem.ID].Quantity = cartItem.Quantity;
				return;
			}
			_myCart.Add(cartItem.ID, cartItem);
		}
		public void DeleteItem(CartItem cartItem)
		{
			if (_myCart.ContainsKey(cartItem.ID))
			{
				_myCart.Remove(cartItem.ID);
				return;
			}
		}
		public void AllDelete()
		{
			if (_myCart.Count > 0)
			{
				_myCart.Clear();
				return;
			}
		}
	}
}
