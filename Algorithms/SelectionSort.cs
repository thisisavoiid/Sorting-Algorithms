using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortieralgorithmen
{
    public class SelectionSort
    {
        /// <summary>
        /// Sorts an array of integers in ascending order using the Selection Sort algorithm.
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        public static void Sort(int[] array)
        {
            int minIndex;
            for (int i = 0; i < array.Length; i++)
            {
                // Assume the current position holds the minimum value
                minIndex = i;

                // Find the index of the minimum value in the remainder of the array
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // Swap the found minimum element with the element at the current position
                (array[i], array[minIndex]) = (array[minIndex], array[i]);
            }
        }
    }
}
