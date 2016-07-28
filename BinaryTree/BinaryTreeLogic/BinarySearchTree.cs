using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTreeLogic
{
   /// <summary>
   /// Class Collection Binary tree
   /// </summary>
   /// <typeparam name="T"></typeparam>
   public sealed class BinarySearchTree<T>: IEnumerable<T>
   {
      class Node<TValue>
      {
         public TValue Item { get; set; }
         public Node<TValue> Left { get; set; }
         public Node<TValue> Right { get; set; }

         public Node(TValue item)
         {
            Item = item;
         }
      }

      private Node<T> root;

      /// <summary>
      /// Algoritm of comparison two items of collection
      /// </summary>
      public readonly Comparison<T> comparer;

      public BinarySearchTree(IEnumerable<T> items, Comparison<T> comparer )
      {
         if (ReferenceEquals(comparer, null))
            if (typeof(T) is IComparable) this.comparer = (lhs, rhs) => ((dynamic)lhs).CompareTo(rhs);
            else new ArgumentNullException();

         this.comparer = comparer;

         if (ReferenceEquals(items, null)) throw new ArgumentNullException();

         foreach (var item in items)
         {
            if (root == null)
            {
               root = new Node<T>(item);
            }
            else
            {
               Add(item);
            }            
         }   
      }

      public BinarySearchTree(IEnumerable<T> items, IComparer<T> comparator):this(items, comparator.Compare)
      {
      }

      /// <summary>
      /// Metod for inorder walk of tree
      /// </summary>
      /// <returns> collection of items</returns>
      public IEnumerable<T> InorderTreeWalk()
      {
         return InorderTreeWalk(root);
      }

      /// <summary>
      /// Metod for preorder walk of tree
      /// </summary>
      /// <returns> collection of items</returns>
      public IEnumerable<T> PreorderTreeWalk()
      {
         return PreorderTreeWalk(root);
      }

      /// <summary>
      /// Metod for postorder walk of tree
      /// </summary>
      /// <returns> collection of items</returns>
      public IEnumerable<T> PostorderTreeWalk()
      {
         return PostorderTreeWalk(root);
      }


      /// <summary>
      /// Adding item in tree
      /// </summary>
      /// <param name="item"></param>
      public void Add(T item)
      {
         var currentNode = root;

         while (true)
         {
            if (comparer(item,currentNode.Item) > 0)
            {
               if (currentNode.Right == null)
               {
                  currentNode.Right = new Node<T>(item);
                  break;
               }
               else
               {
                  currentNode = currentNode.Right;
               }              
            }
            else
            {
               if (currentNode.Left == null)
               {
                  currentNode.Left = new Node<T>(item);
                  break;
               }
               else
               {
                  currentNode = currentNode.Left;
               }
            }
         }
      }

      /// <summary>
      /// Find maximum value in tree
      /// </summary>
      /// <returns>maximum item</returns>
      public T TreeMinimum()
      {
         Node<T> node = root;
         while (node.Left != null)
         {
            node = node.Left;
         }
         return node.Item;
      }


      /// <summary>
      /// Find mimimum value in tree
      /// </summary>
      /// <returns>minimum item</returns>
      public T TreeMaximum()
      {
         Node<T> node = root;
         while (node.Right != null)
         {
            node = node.Right;
         }
         return node.Item;
      }

      /// <summary>
      /// find element in tree
      /// </summary>
      /// <param name="item"></param>
      /// <returns></returns>
      public T TreeSearch( T item)
      {
         foreach (T Item in this)
         {
            if (comparer(item, Item) == 0) return item;
         }

         return default(T);        
      }

      /// <summary>
      /// Returns true if binary tree contins item, and false if not
      /// </summary>
      /// <param name="item"></param>
      /// <returns></returns>
      public bool Contains(T item)
      {
         if (comparer(item, TreeSearch(item)) == 0) return true;
         return false;
      }


      private IEnumerable<T> InorderTreeWalk(Node<T> node)
      {
         if (node == null) yield break;
         foreach (var n in InorderTreeWalk(node.Left))
            yield return n;

         yield return node.Item;

         foreach (var n in InorderTreeWalk(node.Right))
            yield return n;
      }

      private IEnumerable<T> PreorderTreeWalk(Node<T> node)
      {
         if (node == null) yield break;
         yield return node.Item;

         foreach (var n in PreorderTreeWalk(node.Left))
            yield return n;

         foreach (var n in PreorderTreeWalk(node.Right))
            yield return n;
      }

      private IEnumerable<T> PostorderTreeWalk(Node<T> node)
      {
         if (node == null) yield break;
         foreach (var n in PreorderTreeWalk(node.Left))
            yield return n;

         foreach (var n in PreorderTreeWalk(node.Right))
            yield return n;

         yield return node.Item;
      }

      public IEnumerator<T> GetEnumerator()
      {
         return InorderTreeWalk().GetEnumerator();
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
         return GetEnumerator();
      }
   }   
}
