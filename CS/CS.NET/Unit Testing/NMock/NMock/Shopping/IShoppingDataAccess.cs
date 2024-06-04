using System;

namespace NMockExample.Shopping
{
	public interface IShoppingDataAccess
	{
		string GetProductName(int productID);
			
		int GetUnitPrice(int productID);

		BasketItem[] LoadBasketItems(Guid basketID);

		void SaveBasketItems(Guid basketID, BasketItem[] basketItems);
	}
}
