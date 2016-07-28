namespace MatrixLogic
{
   /// <summary>
   /// Generic square matrix
   /// </summary>
   /// <typeparam name="T"></typeparam>
   public class SquareMatrix<T> : Matrix<T>
   {
      private T[,] storage;

      public SquareMatrix(int size)
      {
         Size = size;
         storage = new T[size, size];
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

      protected override T GetValue(int i, int j)
      {
         return storage[i, j];
      }

      protected override void SetValue(int i, int j, T value)
      {
         storage[i, j] = value;
      }
   }    
}
