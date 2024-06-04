using System;
using System.Collections;
using System.Configuration;

namespace NMockExample.Shopping
{
	public class Basket
	{
		private ArrayList basketItems_;
		private Guid basketID_;
		private IShoppingDataAccess dataAccess_;

		public Basket()
		{
			string typeName =
				ConfigurationSettings.AppSettings["IShoppingDataAccessType"];
			Type t = Type.GetType(typeName);
			IShoppingDataAccess dataAccess =
				(IShoppingDataAccess)Activator.CreateInstance(t);

			Initialize(dataAccess);
		}

		public Basket(IShoppingDataAccess dataAccess)
		{
			Initialize(dataAccess);
		}

		public void AddItem(BasketItem item)
		{
			this.basketItems_.Add(item);
		}

		public void Save()
		{
			this.dataAccess_.SaveBasketItems(this.basketID_,
				(BasketItem[])this.basketItems_.ToArray
				(typeof(BasketItem)));
		}

		public decimal CalculateSubTotal()
		{
			decimal subTotal = 0;

			foreach(BasketItem item in this.basketItems_)
			{
				subTotal += item.GetPrice();
			}

			return subTotal;
		}

		private void Initialize(IShoppingDataAccess dataAccess)
		{
			this.dataAccess_ = dataAccess;
			this.basketItems_ = new ArrayList();
			this.basketID_ = Guid.NewGuid();
		}
	}
}
