﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLogic
{
   /// <summary>
   /// Symmetric Matrix class
   /// </summary>
   /// <typeparam name="T"></typeparam>
   class SymmetricMatrix<T>: Matrix<T>
   {
      private T[,] storage;

      public SymmetricMatrix(T[,] array)
      {
         storage = new T[array.Length, array.Length];
         for (int i = 0; i < array.Length; i++)
         {
            for (int j = i; j < array.Length; j++)
            {
               storage[i, j] = array[i, j];
               storage[j, i] = array[i, j];
            }
         }
      }

      public override T GetValue(int i, int j)
      {
         if ((i - j) <= 0) return storage[i, j];
         return storage[j, i];
      }

      public override void SetValue(int i, int j, T value)
      {
         if ((i - j) <= 0) storage[i, j] = value;
      }
   }
}
