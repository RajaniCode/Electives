using System;
using NUnit.Framework;
using NMock;
using NMock.Constraints;
using NMockExample.Shopping;

namespace NMockExample.UnitTests
{
	[TestFixture]
	public class Tests
	{
		[Test]
		public void Test1()
		{
			DynamicMock dataAccess =
				new DynamicMock(typeof(IShoppingDataAccess));

			Basket b =
				new Basket((IShoppingDataAccess)dataAccess.MockInstance);
			b.Save();
		}

		[Test, ExpectedException(typeof(NullReferenceException))]
		public void Test2()
		{
			DynamicMock dataAccess =
				new DynamicMock(typeof(IShoppingDataAccess));

			BasketItem item = new BasketItem(1, 2,
				(IShoppingDataAccess)dataAccess.MockInstance);
		}

		[Test]
		public void Test3()
		{
			DynamicMock dataAccess =
				new DynamicMock(typeof(IShoppingDataAccess));

			dataAccess.SetupResult("GetUnitPrice", 99, typeof(int));
			dataAccess.SetupResult("GetProductName",
				"The Moon", typeof(int));

			BasketItem item = new BasketItem(1, 2,
				(IShoppingDataAccess)dataAccess.MockInstance);

			Assert.AreEqual(99, item.UnitPrice);
			Assert.AreEqual("The Moon", item.ProductName);
			Assert.AreEqual(198, item.GetPrice());
		}

		[Test]
		public void Test4()
		{
			DynamicMock dataAccess =
				new DynamicMock(typeof(IShoppingDataAccess));

			dataAccess.ExpectAndReturn("GetUnitPrice", 99, 1);
			dataAccess.ExpectAndReturn("GetProductName",
				"The Moon", 1);
			dataAccess.ExpectAndReturn("GetUnitPrice", 47, 5);
			dataAccess.ExpectAndReturn("GetProductName",
				"Love", 5);

			Basket b =
				new Basket((IShoppingDataAccess)dataAccess.MockInstance);

			BasketItem item = new BasketItem(1, 2,
				(IShoppingDataAccess)dataAccess.MockInstance);
			b.AddItem(item);

			item = new BasketItem(5, 1,
				(IShoppingDataAccess)dataAccess.MockInstance);
			b.AddItem(item);

			b.Save();
			
			decimal subTotal = b.CalculateSubTotal();
			Assert.AreEqual(245, subTotal);
		}

		[Test, ExpectedException(typeof(VerifyException))]
		public void Test5()
		{
			DynamicMock dataAccess =
				new DynamicMock(typeof(IShoppingDataAccess));
			dataAccess.Strict = true;

			dataAccess.ExpectAndReturn("GetUnitPrice", 99, 1);
			dataAccess.ExpectAndReturn("GetProductName",
				"The Moon", 1);
			dataAccess.ExpectAndReturn("GetUnitPrice", 47, 5);
			dataAccess.ExpectAndReturn("GetProductName",
				"Love", 5);

			Basket b =
				new Basket((IShoppingDataAccess)dataAccess.MockInstance);

			BasketItem item = new BasketItem(1, 2,
				(IShoppingDataAccess)dataAccess.MockInstance);
			b.AddItem(item);

			item = new BasketItem(5, 1,
				(IShoppingDataAccess)dataAccess.MockInstance);
			b.AddItem(item);

			b.Save();
			
			decimal subTotal = b.CalculateSubTotal();
			Assert.AreEqual(245, subTotal);
		}

		[Test]
		public void Test6()
		{
			DynamicMock dataAccess =
				new DynamicMock(typeof(IShoppingDataAccess));
			dataAccess.Strict = true;

			dataAccess.ExpectAndReturn("GetUnitPrice", 99, 1);
			dataAccess.ExpectAndReturn("GetProductName",
				"The Moon", 1);
			dataAccess.ExpectAndReturn("GetUnitPrice", 47, 5);
			dataAccess.ExpectAndReturn("GetProductName",
				"Love", 5);

			Basket b =
				new Basket((IShoppingDataAccess)dataAccess.MockInstance);

			BasketItem item1 = new BasketItem(1, 2,
				(IShoppingDataAccess)dataAccess.MockInstance);
			b.AddItem(item1);

			BasketItem item2 = new BasketItem(5, 1,
				(IShoppingDataAccess)dataAccess.MockInstance);
			b.AddItem(item2);

			dataAccess.Expect("SaveBasketItems", new IsTypeOf(typeof(Guid)),
				new BasketItem[]{item1, item2});

			b.Save();
			
			decimal subTotal = b.CalculateSubTotal();
			Assert.AreEqual(245, subTotal);
		}

		[Test, ExpectedException(typeof(VerifyException))]
		public void Test7()
		{
			DynamicMock dataAccess =
				new DynamicMock(typeof(IShoppingDataAccess));
			dataAccess.Strict = true;

			dataAccess.ExpectAndReturn("GetUnitPrice", 99, 1);
			dataAccess.ExpectAndReturn("GetProductName",
				"The Moon", 1);
			dataAccess.ExpectAndReturn("GetUnitPrice", 47, 5);
			dataAccess.ExpectAndReturn("GetProductName",
				"Love", 5);

			Basket b =
				new Basket((IShoppingDataAccess)dataAccess.MockInstance);

			BasketItem item1 = new BasketItem(1, 2,
				(IShoppingDataAccess)dataAccess.MockInstance);
			b.AddItem(item1);

			BasketItem item2 = new BasketItem(5, 1,
				(IShoppingDataAccess)dataAccess.MockInstance);
			b.AddItem(item2);

			dataAccess.Expect("SaveBasketItems", new IsTypeOf(typeof(Guid)),
				new BasketItem[]{item1, item2});
	
			decimal subTotal = b.CalculateSubTotal();
			Assert.AreEqual(245, subTotal);

			dataAccess.Verify();
		}

		[Test]
		public void BasketDefaultConstructor()
		{
			Basket b = new Basket();
		}

		[Test]
		public void BasketItemDefaultConstructor()
		{
			BasketItem item = new BasketItem(1, 1);
		}
	}
}
