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
         MatrixAdder<int> adder = new MatrixAdder<int>();

         //Act
         var result = adder.DoOperation(matrix, secondMatrix);

         //Assert
         for (int i = 0; i < 2; i++)
         {
            for (int j = 0; j < 2; j++)
            {
               Assert.AreEqual(5, result[i, j]);
            }
         }

      }

      [TestMethod]
      public void StringSquareMatrixTest()
      {
         //Arrange
         string[,] lhs = { { "", "" }, { "Hello", "" } };
         string[,] rhs = { { "", "" }, { " World!", "" } };
         SquareMatrix<string> matrix = new SquareMatrix<string>(lhs);
         SquareMatrix<string> secondMatrix = new SquareMatrix<string>(rhs);
         MatrixAdder<string> adder = new MatrixAdder<string>();

         //Act
         var result = adder.DoOperation(matrix, secondMatrix);

         //Assert
         Assert.AreEqual("Hello World!", result[1, 0]);

      }
   }
}
