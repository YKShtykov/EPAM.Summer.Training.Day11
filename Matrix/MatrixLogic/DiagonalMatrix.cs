using Microsoft.CSharp.RuntimeBinder;
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
   class DiagonalMatrix<T> : Matrix<T>
   {
      private T[] storage;

      public static Func<T, T, T> Adder;

      public DiagonalMatrix(int size)
      {
         Size = size;
         storage = new T[size];
      }

      public DiagonalMatrix(T[] array) : this(array.Length)
      {
         for (int i = 0; i < Size; i++)
         {
            storage[i] = array[i];
         }
      }

      public override T GetValue(int i, int j)
      {
         if (i == j) return storage[i];
         return default(T);
      }

      public override void SetValue(int i, int j, T value)
      {
         if (i == j) storage[i] = value;
      }

      /// <summary>
      /// Overloaded operation + 
      /// </summary>
      /// <param name="lhs"></param>
      /// <param name="rhs"></param>
      /// <returns>new Diagonal matrix, each element of it is result of addinf operation</returns>
      public static DiagonalMatrix<T> Add(DiagonalMatrix<T> lhs, DiagonalMatrix<T> rhs)
      {
         if (ReferenceEquals(Adder, null)) Adder = (a, b) => (dynamic)a + b;
         try
         {
            DiagonalMatrix<T> result = new DiagonalMatrix<T>(lhs.Size);
            for (int i = 0; i < lhs.Size; i++)
            {
               result[i,i] = Adder(lhs[i,i], rhs[i,i]);

            }

            return result;
         }
         catch (RuntimeBinderException e)
         {
            throw new InvalidOperationException();
         }
      }


   }
}
