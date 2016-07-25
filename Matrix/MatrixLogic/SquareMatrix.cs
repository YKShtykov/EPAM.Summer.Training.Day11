using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLogic
{
   /// <summary>
   /// Generic square matrix
   /// </summary>
   /// <typeparam name="T"></typeparam>
   public class SquareMatrix<T> : Matrix<T>
   {
      /// <summary>
      /// rule forr adding two items
      /// </summary>
      public static Func<T, T, T> Adder;

      private T[,] storage;

      public SquareMatrix() { }

      public SquareMatrix(int Range)
      {
         this.Size = Range;
         storage = new T[Range, Range];
      }

      public SquareMatrix(T[,] array) : this(array.GetLength(0))
      {
         for (int i = 0; i < Size; i++)
         {
            for (int j = 0; j < Size; j++)
            {
               storage[i, j] = array[i, j];
            }
         }
      }

      /// <summary>
      /// overloaded + operator
      /// </summary>
      /// <param name="lhs"></param>
      /// <param name="rhs"></param>
      /// <returns>new square matrix, each element of it is result of addinf operation</returns>
      public static SquareMatrix<T> Add(SquareMatrix<T> lhs, SquareMatrix<T> rhs)
      {
         if (ReferenceEquals(Adder, null)) Adder = (a, b) => (dynamic)a + b;
         try
         {
            SquareMatrix<T> result = new SquareMatrix<T>(lhs.Size);
            for (int i = 0; i < lhs.Size; i++)
            {
               for (int j = 0; j < lhs.Size; j++)
               {
                  result[i, j] = Adder(lhs[i, j], rhs[i, j]);
               }
            }

            return result;
         }
         catch (RuntimeBinderException e)
         {
            throw new InvalidOperationException();
         }
      }

      public override T GetValue(int i, int j)
      {
         return storage[i, j];
      }

      public override void SetValue(int i, int j, T value)
      {
         storage[i, j] = value;
      }
   }

   /// <summary>
   /// Report of event
   /// </summary>
   /// <typeparam name="T"></typeparam>
   public class ElementEventArgs : EventArgs
   {
      public int I { get; set; }
      public int J { get; set; }

      public ElementEventArgs(int i, int j)
      {
         I = i;
         J = j;
      }
   }

   public abstract class Matrix<T>
   {
      public int Size { get; set; }

      public event EventHandler<EventArgs> Changed = delegate { };

      public T this[int i, int j]
      {
         get
         {
            if (i < 0 || i > Size) throw new ArgumentException();
            if (j < 0 || j > Size) throw new ArgumentException();

            return GetValue(i, j);
         }
         set
         {
            if (i < 0 || i > Size) throw new ArgumentException();
            if (j < 0 || j > Size) throw new ArgumentException();

            SetValue(i, j, value);
         }
      }

      public abstract T GetValue(int i, int j);

      public abstract void SetValue(int i, int j, T value);

      public void Change(int i, int j, T value)
      {
         if (i < 0 || i > Size) throw new ArgumentException();
         if (j < 0 || j > Size) throw new ArgumentException();

         SetValue(i, j, value);
         OnChanged(new ElementEventArgs(i, j));
      }

      protected void OnChanged(ElementEventArgs e)
      {
         Changed(this, e);
      }
   }
}
