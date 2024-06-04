using System;
using System.Configuration;

namespace NMockExample.Shopping
{
	public class BasketItem
	{
		private decimal unitPrice_;
		private int productID_;
		private int quantity_;
		private IShoppingDataAccess dataAccess_;
		private string productName_;

		public BasketItem(int productID, int quantity)
		{
			string typeName =
				ConfigurationSettings.AppSettings["IShoppingDataAccessType"];
			Type t = Type.GetType(typeName);
			IShoppingDataAccess dataAccess =
				(IShoppingDataAccess)Activator.CreateInstance(t);

			Initialize(productID, quantity, dataAccess);
		}

		public BasketItem(int productID,
			int quantity,
			IShoppingDataAccess dataAccess)
		{
			Initialize(productID, quantity, dataAccess);
		}

		public decimal UnitPrice
		{
			get{return this.unitPrice_;}
		}

		public int ProductID
		{
			get{return this.productID_;}
			set
			{
				this.productID_ = value;
				this.unitPrice_ = 
					this.dataAccess_.GetUnitPrice(this.productID_);
				this.productName_ = 
					this.dataAccess_.GetProductName(this.productID_);
			}
		}

		public int Quantity
		{
			get{return this.quantity_;}
			set{this.quantity_ = value;}
		}

		public string ProductName
		{
			get{return this.productName_;}
		}

		public decimal GetPrice()
		{
			return this.unitPrice_ * this.quantity_;
		}

		private void Initialize(int productID,
			int quantity,
			IShoppingDataAccess dataAccess)
		{
			this.dataAccess_ = dataAccess;
			this.ProductID = productID;
			this.Quantity = quantity;
		}
	}
}
