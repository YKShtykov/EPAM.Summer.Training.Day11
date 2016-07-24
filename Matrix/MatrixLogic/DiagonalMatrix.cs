using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLogic
{
   /// <summary>
   /// Diagonal matrix class
   /// </summary>
   /// <typeparam name="T"></typeparam>
   class DiagonalMatrix<T> : SquareMatrix<T>
   {
      private T[] storage;

      public DiagonalMatrix(int Range)
      {
         this.Range = Range;
         storage = new T[Range];
      }

      public DiagonalMatrix(T[] array) : this(array.Length)
      {
         for (int i = 0; i < Range; i++)
         {
            storage[i] = array[i];
         }
      }

      /// <summary>
      /// Overloaded operation + 
      /// </summary>
      /// <param name="lhs"></param>
      /// <param name="rhs"></param>
      /// <returns>new square matrix, each element of it is result of addinf operation</returns>
      public static DiagonalMatrix<T> operator +(DiagonalMatrix<T> lhs, DiagonalMatrix<T> rhs)
      {
         DiagonalMatrix<T> result = new DiagonalMatrix<T>(lhs.Range);
         for (int i = 0; i < lhs.Range; i++)
         {
            result[i] = Adder(lhs[i], rhs[i]);
         }

         return result;
      }

      public override  T this[int i, int j]
      {
         get
         {
            if (i >= 0 && i < Range && j >= 0 && j < Range)
            {
               if (i == j) return storage[i];
               else return default(T);
            }
            throw new ArgumentException();
         }

         set
         {
            if (i >= 0 && i < Range && i==j)
            {
               storage[i] = value;
               OnChanged(new ElementEventArgs(i, j));         
            }
            throw new ArgumentException();
         }
      }

      public T this[int i]
      {
         get
         {
            if (i > 0 && i < Range)
            {
               return storage[i];
            }
            throw new ArgumentException();
         }

         set
         {
            if (i > 0 && i < Range)
            {
               storage[i] = value;
               OnChanged(new ElementEventArgs(i, i));
            }
            throw new ArgumentException();
         }
      }
   }
}
