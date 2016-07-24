using System;
using System.Collections.Generic;

namespace BinaryTreeLogic
{
   /// <summary>
   /// Class Collection Binary tree
   /// </summary>
   /// <typeparam name="T"></typeparam>
   public sealed class BinarySearchTree<T>
   {
      private Node<T> root;

      /// <summary>
      /// Algoritm of comparison two items of collection
      /// </summary>
      public readonly Comparison<T> comparer;

      public BinarySearchTree(IEnumerable<T> items, Comparison<T> comparer )
      {
         this.comparer = comparer;
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

      /// <summary>
      /// Metod for inorder walk of tree
      /// </summary>
      /// <returns> collection of items</returns>
      public IEnumerable<T> InorderTreeWalk()
      {
         List<T> result = new List<T>();
         InorderTreeWalk(root, result);

         return result;
      }

      /// <summary>
      /// Metod for preorder walk of tree
      /// </summary>
      /// <returns> collection of items</returns>
      public IEnumerable<T> PreorderTreeWalk()
      {
         List<T> result = new List<T>();
         PreorderTreeWalk(root, result);

         return result;
      }

      /// <summary>
      /// Metod for postorder walk of tree
      /// </summary>
      /// <returns> collection of items</returns>
      public IEnumerable<T> PostorderTreeWalk()
      {
         List<T> result = new List<T>();
         PostorderTreeWalk(root, result);

         return result;
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
         Node<T> node = root;
         while (node != null && comparer(item, node.Item) != 0)
         {
            if (comparer(item, node.Item) > 0) node = node.Right;
            if (comparer(item, node.Item) <= 0) node = node.Left;
         }
         return node.Item;
      }


      private void InorderTreeWalk(Node<T> node, List<T> list)
      {
         if (node != null)
         {
            InorderTreeWalk(node.Left, list);
            list.Add(node.Item);
            InorderTreeWalk(node.Right, list);
         }
      }

      private void PreorderTreeWalk(Node<T> node, List<T> list)
      {
         if (node != null)
         {
            list.Add(node.Item);
            InorderTreeWalk(node.Left, list);
            InorderTreeWalk(node.Right, list);
         }
      }

      private void PostorderTreeWalk(Node<T> node, List<T> list)
      {
         if (node != null)
         {
            InorderTreeWalk(node.Left, list);
            InorderTreeWalk(node.Right, list);
            list.Add(node.Item);
         }
      }
   }

   public class Node<T>
   {
      public T Item { get; set; }
      public Node<T> Left { get; set; }
      public Node<T> Right { get; set; }

      public Node(T item)
      {
         Item = item;
      }
   }
}
