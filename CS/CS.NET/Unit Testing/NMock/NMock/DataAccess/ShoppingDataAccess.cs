using System;
using NMockExample.Shopping;

namespace NMockExample.DataAccess
{
	public class ShoppingDataAccess : IShoppingDataAccess
	{
		public string GetProductName(int productID)
		{
			return "";
		}
			
		public int GetUnitPrice(int productID)
		{
			return 0;
		}

		public BasketItem[] LoadBasketItems(Guid basketID)
		{
			return new BasketItem[0];
		}

		public void SaveBasketItems(Guid basketID, BasketItem[] basketItems)
		{
		}
	}
}
