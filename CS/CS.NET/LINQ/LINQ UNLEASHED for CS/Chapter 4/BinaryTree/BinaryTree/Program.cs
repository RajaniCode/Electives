using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BinaryTreeDemo
{
  class Program
  {
    static void Main(string[] args)
    {
      BinaryTree<int> integers = new BinaryTree<int>();
      integers.AddRange(8, 5, 6, 7, 3, 4, 13, 21, 1, 17);

      // display conceptual tree
      integers.Print();
      Console.ReadLine();
      Console.Clear();

      // write in order
      foreach(var item in integers.Inorder)
        Console.WriteLine(item);
      Console.ReadLine();
    }
  }

  //                   8
  //                  / \
  //                 5   13
  //                / \   \
  //               3   6   21
  //              / \   \  /
  //             1   4  7 17

  public class Node<T> where T : IComparable<T>
  {
    public T data;

    private Node<T> leftNode;
    public Node<T> LeftNode
    {
    	get {	return leftNode; }
    	set { leftNode = value;	}
    }

    private Node<T> rightNode;
    public Node<T> RightNode
    {
    	get {	return rightNode; }
    	set { rightNode = value;	}
    }

    /// <summary>
    /// Initializes a new instance of the Node class.
    /// </summary>
    /// <param name="data"></param>
    public Node(T data)
    {
    		this.data = data;
    }

    public override string ToString()
    {
      return data.ToString();
    }
  }

  public class BinaryTree<T> where T : IComparable<T>
  {
    private Node<T> root;
    public Node<T> Root
    {
    	get {	return root; }
    	set { root = value;	}
    }

    public void Add(T item)
    {
      if( root == null )
      {
        root = new Node<T>(item);
        return;
      }
      Add(item, root);
    }

    private void Add(T item, Node<T> node)
    {
      if(item.CompareTo(node.data) < 0)
      { 
        if(node.LeftNode == null)
          node.LeftNode = new Node<T>(item);
        else
          Add(item, node.LeftNode);
      }
      else if( item.CompareTo(node.data) > 0)
      {
        if(node.RightNode == null)
          node.RightNode = new Node<T>(item);
        else
          Add(item, node.RightNode);
      }

      // silently discard it
    }

    public void AddRange(params T[] items)
    {
      foreach(var item in items)
        Add(item);
    }

    /// <summary>
    /// error in displaying tree - 7 is overwritten 17! 
    /// </summary>
    public void Print()
    {
      Print(root, 0, Console.WindowWidth / 2);
    }

    public IEnumerable<T> Inorder
    {
      get{ return GetInOrder(this.root); }
    }

    IEnumerable<T> GetInOrder(Node<T> node)
    {
      if(node.LeftNode != null)
      {
         foreach(T item in GetInOrder(node.LeftNode))
         {
            yield return item;
         }
      }

      yield return node.data;
 
      if(node.RightNode != null)
      {
         foreach(T item in GetInOrder(node.RightNode))
         {
            yield return item;
         }
      }
   }


    private void Print(Node<T> item, int depth, int offset)
    { 
      if(item == null) return;
      Console.CursorLeft = offset;
      Console.CursorTop = depth;
      Console.Write(item.data);

      if(item.LeftNode != null)
        Print("/", depth + 1, offset - 1);
      Print(item.LeftNode, depth + 2, offset - 3);
      
      if(item.RightNode != null)
        Print("\\", depth + 1, offset + 1);
      Print(item.RightNode, depth + 2, offset + 3);
    }
    
    private void Print(string s, int depth, int offset)
    {
      Console.CursorLeft = offset;
      Console.CursorTop = depth;
      Console.Write(s);
    }
  }
}
