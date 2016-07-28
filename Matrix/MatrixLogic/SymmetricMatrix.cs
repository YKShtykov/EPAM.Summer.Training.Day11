namespace MatrixLogic
{
   /// <summary>
   /// Symmetric Matrix class
   /// </summary>
   /// <typeparam name="T"></typeparam>
   public class SymmetricMatrix<T> : Matrix<T>
   {
      private T[][] storage;

      public SymmetricMatrix(int size)
      {
         Size = size;
         storage = new T[size][];
         for (int i = 0; i < size; i++)
         {
            storage[i] =new  T[i + 1];
         }
      }

      public SymmetricMatrix(T[][] array):this(array.Length)
      {
         for (int i = 0; i < array.Length; i++)
         {
            for (int j = 0; j < i+1; j++)
            {
               storage[i][j] = array[i][j];
            }
         }
      }

      protected override T GetValue(int i, int j)
      {
         if ((i - j) <= 0) return storage[j][i];
         return storage[i][j];
      }

      protected override void SetValue(int i, int j, T value)
      {
         if ((i - j) <= 0) storage[j][i] = value;
         else storage[i][j] = value;
      }
   }
}
