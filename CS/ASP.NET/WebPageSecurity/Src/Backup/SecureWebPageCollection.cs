using System;
using System.Collections;

namespace Hyper.Web.Security
{
	/// <summary>
	/// The SecureWebPageCollection class houses a collection of SecureWebPageItem instances.
	/// </summary>
	public class SecureWebPageCollection : CollectionBase
	{
		/// <summary>
		/// Initialize an instance of this collection.
		/// </summary>
		public SecureWebPageCollection()
		{
		}

		/// <summary>
		/// Indexer for the collection.
		/// </summary>
		public SecureWebPageItem this [int Index]
		{
			get { return (SecureWebPageItem) List[Index]; }
		}

		/// <summary>
		/// Adds the item to the collection.
		/// </summary>
		/// <param name="Item">The item to add.</param>
		public int Add(SecureWebPageItem Item)
		{
			return List.Add(Item);
		}

		/// <summary>
		/// Returns the index of a specified item in the collection.
		/// </summary>
		/// <param name="Item">The item to find.</param>
		/// <returns>Returns the index of the item.</returns>
		public int IndexOf(SecureWebPageItem Item)
		{
			return List.IndexOf(Item);
		}

		/// <summary>
		/// Returns the index of an item with the specified path in the collection.
		/// </summary>
		/// <param name="Path">The path of the item to find.</param>
		/// <returns>Returns the index of the item with the path.</returns>
		public int IndexOf(string Path)
		{
			// Create a comparer for sorting and searching
			SecureWebPageItemComparer Comparer = new SecureWebPageItemComparer();
			InnerList.Sort(Comparer);
			return InnerList.BinarySearch(Path, Comparer);
		}

		/// <summary>
		/// Inserts an item into the collection at the specified index.
		/// </summary>
		/// <param name="Index">The index to insert the item at.</param>
		/// <param name="Item">The item to insert.</param>
		public void Insert(int Index, SecureWebPageItem Item)
		{
			List.Insert(Index, Item);
		}

		/// <summary>
		/// Removes an item from the collection.
		/// </summary>
		/// <param name="Item">The item to remove.</param>
		public void Remove(SecureWebPageItem Item)
		{
			List.Remove(Item);
		}
	}
}
