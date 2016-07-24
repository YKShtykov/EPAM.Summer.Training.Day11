using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryTreeLogic;

namespace BinarySearchTreeLogicTests
{
   [TestClass]
   public class BinaryTreeTest
   {
      [TestMethod]
      public void IntTree()
      {
         //arrange 
         int[] array = { 1, 6, 4, -100, 50, 60, 5 };
         BinarySearchTree<int> tree = new BinarySearchTree<int>(array, new Comparison<int>((a, b) => a.CompareTo(b)));

         //Act
         int actual = tree.TreeMaximum();

         //Assert
         Assert.AreEqual(60, actual);

      }

      [TestMethod]
      public void IntTreeSearch()
      {
         //arrange 
         int[] array = { 1, 6, 4, -100, 50, 60, 5 };
         BinarySearchTree<int> tree = new BinarySearchTree<int>(array, new Comparison<int>((a, b) => a.CompareTo(b)));

         //Act
         int actual = tree.TreeSearch(-100);

         //Assert
         Assert.AreEqual(-100, actual);

      }

      [TestMethod]
      public void StringTreeSearch()
      {
         //arrange 
         string[] array = { "one", "two", "five", "seven" };
         BinarySearchTree<string> tree = new BinarySearchTree<string>(array, new Comparison<string>((a, b) => a.CompareTo(b)));

         //Act
         string actual = tree.TreeSearch("five");

         //Assert
         Assert.AreEqual("five", actual);
      }
      public int PointComparer(Point lhs, Point rhs)
      {
         if (lhs.Y > rhs.Y && lhs.X > rhs.X) return 1;
         if (lhs.Y < rhs.Y && lhs.X < rhs.X) return -1;
         return 0;

      }
      [TestMethod]
      public void PointTreeSearch()
      {
         //arrange 
         Point[] array = { new Point { X = 5, Y = 9 },
                           new Point { X = 3, Y = -100 },
                           new Point { X = 55, Y = 49 },
                           new Point { X = 1, Y = 99 } };
         BinarySearchTree<Point> tree = new BinarySearchTree<Point>(array, PointComparer);

         //Act
         Point actual = tree.TreeMaximum();

         //Assert
         Assert.AreEqual(55, actual.X);
      }

      [TestMethod]
      public void BookTreeSearch()
      {
         //arrange 
         Book[] array = { new Book("Arthur Clark","Rama",300,10),
                          new Book("Bertran Rassel","Tesaurus",100,5) };
         BinarySearchTree<Book> tree = new BinarySearchTree<Book>(array, new Comparison<Book>((lhs,rhs)=>lhs.CompareTo(rhs)));

         //Act
         Book actual = tree.TreeMaximum();

         //Assert
         Assert.AreEqual(10, actual.Cost);
      }
   }

   
   public struct Point
   {
      public int X { get; set; }
      public int Y { get; set; }
   }
}
