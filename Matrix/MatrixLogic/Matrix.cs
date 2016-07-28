using System;

namespace MatrixLogic
{
   public interface IMatrixVisitor<T>
   {
      SquareMatrix<T> Visit(SquareMatrix<T> lhs, SquareMatrix<T> rhs);
      SquareMatrix<T> Visit(SquareMatrix<T> lhs, DiagonalMatrix<T> rhs);
      SquareMatrix<T> Visit(SquareMatrix<T> lhs, SymmetricMatrix<T> rhs);

      DiagonalMatrix<T> Visit(DiagonalMatrix<T> lhs, DiagonalMatrix<T> rhs);
      SquareMatrix<T> Visit(DiagonalMatrix<T> lhs, SquareMatrix<T> rhs);
      SymmetricMatrix<T> Visit(DiagonalMatrix<T> lhs, SymmetricMatrix<T> rhs);

      SymmetricMatrix<T> Visit(SymmetricMatrix<T> lhs, DiagonalMatrix<T> rhs);
      SquareMatrix<T> Visit(SymmetricMatrix<T> lhs, SquareMatrix<T> rhs);
      SymmetricMatrix<T> Visit(SymmetricMatrix<T> lhs, SymmetricMatrix<T> rhs);
   }

   public abstract class Matrix<T>
   {
      public int Size { get; protected set; }

      /// <summary>
      /// Event runs when matrih has been changed
      /// </summary>
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

      /// <summary>
      /// Visitor method
      /// </summary>
      /// <param name="visitor"></param>
      /// <param name="matrix"></param>
      /// <returns></returns>
      public Matrix<T> Accept(IMatrixVisitor<T> visitor, Matrix<T> matrix)
      {
         return visitor.Visit((dynamic)this, (dynamic)matrix);
      }

      protected abstract T GetValue(int i, int j);

      protected abstract void SetValue(int i, int j, T value);

      /// <summary>
      /// Changes matrix element
      /// </summary>
      /// <param name="i"></param>
      /// <param name="j"></param>
      /// <param name="value"></param>
      public void Change(int i, int j, T value)
      {
         if (i < 0 || i > Size) throw new ArgumentException();
         if (j < 0 || j > Size) throw new ArgumentException();

         SetValue(i, j, value);
         OnChanged(new ElementEventArgs() { I = i, J = j });
      }

      protected void OnChanged(ElementEventArgs e)
      {
         Changed(this, e);
      }
   }

   /// <summary>
   /// Event report
   /// </summary>
   /// <typeparam name="T"></typeparam>
   public class ElementEventArgs : EventArgs
   {
      public int I { get; set; }
      public int J { get; set; }
   }
}
