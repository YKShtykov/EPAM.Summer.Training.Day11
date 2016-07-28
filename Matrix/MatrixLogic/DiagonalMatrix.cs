namespace MatrixLogic
{
   /// <summary>
   /// Diagonal matrix class
   /// </summary>
   /// <typeparam name="T"></typeparam>
   public class DiagonalMatrix<T> : Matrix<T>
   {
      private T[] storage;

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

      protected override T GetValue(int i, int j)
      {
         if (i == j) return storage[i];
         return default(T);
      }

      protected override void SetValue(int i, int j, T value)
      {
         if (i == j) storage[i] = value;
      }
   }
}
