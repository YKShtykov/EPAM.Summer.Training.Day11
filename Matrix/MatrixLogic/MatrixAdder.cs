using Microsoft.CSharp.RuntimeBinder;
using System;

namespace MatrixLogic
{
   public class MatrixAdder<T> : IMatrixVisitor<T>
   {
      public Func<Matrix<T>, Matrix<T>, Matrix<T>> OperationsHelper = Adder;

      public SquareMatrix<T> Visit(SquareMatrix<T> lhs, SymmetricMatrix<T> rhs)
      {
         return (SquareMatrix<T>) OperationsHelper(lhs,rhs);
      }

      public SquareMatrix<T> Visit(DiagonalMatrix<T> lhs, SquareMatrix<T> rhs)
      {
         return (SquareMatrix<T>)OperationsHelper(lhs, rhs);
      }

      public SquareMatrix<T> Visit(SquareMatrix<T> lhs, DiagonalMatrix<T> rhs)
      {
         return (SquareMatrix<T>)OperationsHelper(lhs, rhs);
      }

      public SquareMatrix<T> Visit(SquareMatrix<T> lhs, SquareMatrix<T> rhs)
      {
         return (SquareMatrix<T>)OperationsHelper(lhs, rhs);
      }

      public SquareMatrix<T> Visit(SymmetricMatrix<T> lhs, SquareMatrix<T> rhs)
      {
         return (SquareMatrix<T>)OperationsHelper(lhs, rhs);
      }

      public SymmetricMatrix<T> Visit(SymmetricMatrix<T> lhs, DiagonalMatrix<T> rhs)
      {
         return (SymmetricMatrix<T>)OperationsHelper(lhs, rhs);
      }

      public SymmetricMatrix<T> Visit(SymmetricMatrix<T> lhs, SymmetricMatrix<T> rhs)
      {
         return (SymmetricMatrix<T>)OperationsHelper(lhs, rhs);
      }

      public SymmetricMatrix<T> Visit(DiagonalMatrix<T> lhs, SymmetricMatrix<T> rhs)
      {
         return (SymmetricMatrix<T>)OperationsHelper(lhs, rhs);
      }

      public DiagonalMatrix<T> Visit(DiagonalMatrix<T> lhs, DiagonalMatrix<T> rhs)
      {
         return (DiagonalMatrix<T>)OperationsHelper(lhs, rhs);
      }



      public static Matrix<T> Adder(Matrix<T> lhs, Matrix<T> rhs)
      {
         if (ReferenceEquals(lhs, null)) throw new ArgumentNullException();
         if (ReferenceEquals(rhs, null)) throw new ArgumentNullException();

         Matrix<T> result = null;

         try
         {
            if ((lhs is SquareMatrix<T>) || (rhs is SquareMatrix<T>))
            {
               result = new SquareMatrix<T>(rhs.Size);
               for (int i = 0; i < rhs.Size; i++)
               {
                  for (int j = 0; j < rhs.Size; j++)
                  {
                     result[i, j] = (dynamic)lhs[i, j] + rhs[i, j];
                  }
               }
            }
            else
            {
               if ((lhs is SymmetricMatrix<T>) || (rhs is SymmetricMatrix<T>))
               {
                  result = new SymmetricMatrix<T>(rhs.Size);
                  for (int i = 0; i < rhs.Size; i++)
                  {
                     for (int j = 0; j < i + 1; j++)
                     {
                        result[i, j] = (dynamic)lhs[i, j] + rhs[i, j];
                     }
                  }
               }
               else
               {
                  result = new DiagonalMatrix<T>(rhs.Size);
                  for (int i = 0; i < rhs.Size; i++)
                  {
                     result[i,i] = (dynamic)lhs[i,i] + rhs[i,i];
                  }
               }
            }

            return result;
         }
         catch (RuntimeBinderException)
         {
            throw new InvalidOperationException();
         }
      }

      public Matrix<T> DoOperation(Matrix<T> lhs, Matrix<T> rhs)
      {
         return lhs.Accept(this,rhs);
      }
   }
}
