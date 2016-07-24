using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixLogic;
using System.Diagnostics;

namespace MatrixLogicTests
{
   [TestClass]
   public class MatrixTests
   {
      [TestMethod]
      public void SquareMatrixTest()
      {
         //Arrange
         int[,] lhs = { { 1, 2 }, { 3, 5 } };
         int[,] rhs = { { 4, 3 }, { 2, 0 } };
         SquareMatrix<int> matrix = new SquareMatrix<int>(lhs);
         SquareMatrix<int> secondMatrix = new SquareMatrix<int>(rhs);
         SquareMatrix<int>.Adder = (a, b) => a + b;
         //matrix.Changed +=new EventHandler(DebugMessage);

         //Act
         var result = matrix + secondMatrix;

         //Assert
         for (int i = 0; i < 2; i++)
         {
            for (int j = 0; j < 2; j++)
            {
               Assert.AreEqual(5, result[i, j]);
            }
         }

      }

      public static void DebugMessage(object sender, ElementEventArgs eventArgs)
      {
         Debug.WriteLine("{0},{1} -> {2}", eventArgs.I, eventArgs.J);
      }
   }
}
