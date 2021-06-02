using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{
    class Resize
    {
        //method to resize an array when an item is deleted
        public static T[] resizeDelete<T>(T[] array, int count)
        {
            for (int j = 0; j < array.Length - 1; j++)
            {
                array[count + j] = array[count + 1];
            }

            return array;
        }
    }
}
