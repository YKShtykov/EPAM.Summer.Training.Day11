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
    public class SquareMatrix<T>
    {
      /// <summary>
      /// Number of elements in each Column\Row
      /// </summary>
      public int Range { get; set; }
      /// <summary>
      /// rule forr adding two items
      /// </summary>
      public static Func<T, T, T> Adder;

      /// <summary>
      /// Event is run when element in matrix is changed
      /// </summary>
      public event EventHandler<EventArgs> Changed = delegate { };

      private T[,] storage;

      public SquareMatrix() {}

      public SquareMatrix(int Range)
      {
         this.Range = Range;
         storage = new T[Range,Range];
      }

      public SquareMatrix(T[,] array):this(array.GetLength(0))
      {         
         for (int i = 0; i < Range; i++)
         {
            for (int j = 0; j < Range; j++)
            {
               storage[i, j] = array[i, j];
            }
         }
      }

      public virtual T this[int i, int j]
      {
         get
         {
            return storage[i, j];
         }
         set
         {
            storage[i, j] = value;
         }
      }

      /// <summary>
      /// overloaded + operator
      /// </summary>
      /// <param name="lhs"></param>
      /// <param name="rhs"></param>
      /// <returns>new square matrix, each element of it is result of addinf operation</returns>
      public static SquareMatrix<T> operator+(SquareMatrix<T> lhs, SquareMatrix<T> rhs)
      {
         SquareMatrix<T> result = new SquareMatrix<T>(lhs.Range);
         for (int i = 0; i < lhs.Range; i++)
         {
            for (int j = 0; j < lhs.Range; j++)
            {
               result[i, j] = Adder(lhs[i, j], rhs[i, j]);               
            }
         }

         return result;
      }

      /// <summary>
      /// Change element [i,j] on new value
      /// </summary>
      /// <param name="i"></param>
      /// <param name="j"></param>
      /// <param name="value"></param>
      public void Change(int i, int j, T value)
      {
         if (i>=0&&i<Range&&j>=0&&j<Range)
         {
            storage[i, j] = value;
            OnChanged(new ElementEventArgs(i, j));
         }         
      }

      protected void OnChanged(ElementEventArgs e)
      {
         Changed(this, e);
      }
   }

   /// <summary>
   /// Report of event
   /// </summary>
   /// <typeparam name="T"></typeparam>
   public class ElementEventArgs: EventArgs
   {
      public int I { get; set; }
      public int J { get; set; }

      public ElementEventArgs(int i, int j)
      {
         I = i;
         J = j;
      }
   }
}
