using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortieralgorithmen
{
    /// <summary>
    /// Implements the Quick Sort algorithm for integer arrays.
    /// </summary>
    public class QuickSort : SortingAlgorithm
    {
        public override string Name => "Quick Sort";

        /// <summary>
        /// Sorts an array of integers in ascending order using Quick Sort.
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        public override void Sort(int[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Recursively sorts a subarray using Quick Sort logic.
        /// </summary>
        /// <param name="array">Array to sort.</param>
        /// <param name="start">Starting index of the subarray.</param>
        /// <param name="end">Ending index of the subarray.</param>
        private void Sort(int[] array, int start, int end)
        {
            if (end <= start) return;

            int pivot = Partition(array, start, end);

            Sort(array, start, pivot - 1);
            Sort(array, pivot + 1, end);
        }

        /// <summary>
        /// Partitions the array around a pivot element such that values less than pivot come before it,
        /// and values greater come after it.
        /// </summary>
        /// <param name="array">Array to partition.</param>
        /// <param name="start">Starting index of the partition.</param>
        /// <param name="end">Ending index of the partition.</param>
        /// <returns>Final index of the pivot element.</returns>
        private int Partition(int[] array, int start, int end)
        {
            int pivot = array[end];
            int i = start - 1;
            int temp;

            for (int j = start; j <= end - 1; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            i++;
            temp = array[i];
            array[i] = array[end];
            array[end] = temp;

            return i;
        }
    }
}
