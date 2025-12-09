using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortieralgorithmen
{
    /// <summary>
    /// Implements the Selection Sort algorithm for integer arrays.
    /// </summary>
    public class SelectionSort : SortingAlgorithm
    {
        /// <summary>
        /// Gets the name of the sorting algorithm.
        /// </summary>
        public override string Name => "Selection Sort";

        /// <summary>
        /// Sorts an array of integers in ascending order using Selection Sort.
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        public override void Sort(int[] array)
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
                        minIndex = j;
                }

                // Swap the found minimum element with the element at the current position
                (array[i], array[minIndex]) = (array[minIndex], array[i]);
            }
        }
    }
}
