using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortieralgorithmen
{
    public class MergeSort
    {
        /// <summary>
        /// Sorts an array of integers in ascending order using the Merge Sort algorithm.
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        public static void Sort(int[] array)
        {
            int length = array.Length;

            if (length <= 1) return;

            int middle = length / 2;

            int[] leftArray = new int[middle];
            int[] rightArray = new int[length - middle];

            int i = 0;
            int j = 0;

            // Split array into left and right halves
            for (; i < length; i++)
            {
                if (i < middle)
                {
                    leftArray[i] = array[i];
                }
                else
                {
                    rightArray[j] = array[i];
                    j++;
                }
            }

            // Recursively sort the halves
            Sort(leftArray);
            Sort(rightArray);

            // Merge the sorted halves back into the original array
            Merge(leftArray, rightArray, array);
        }

        /// <summary>
        /// Merges two sorted arrays into a single sorted array.
        /// </summary>
        /// <param name="leftArray">The left sorted array.</param>
        /// <param name="rightArray">The right sorted array.</param>
        /// <param name="array">The original array to store merged results.</param>
        private static void Merge(int[] leftArray, int[] rightArray, int[] array)
        {
            int leftSize = array.Length / 2;
            int rightSize = array.Length - leftSize;
            int i = 0, l = 0, r = 0;

            // Merge elements from both arrays while elements remain in both
            while (l < leftSize && r < rightSize)
            {
                if (leftArray[l] < rightArray[r])
                {
                    array[i] = leftArray[l];
                    i++;
                    l++;
                }
                else
                {
                    array[i] = rightArray[r];
                    i++;
                    r++;
                }
            }

            // Copy any remaining elements from leftArray
            while (l < leftSize)
            {
                array[i] = leftArray[l];
                i++;
                l++;
            }

            // Copy any remaining elements from rightArray
            while (r < rightSize)
            {
                array[i] = rightArray[r];
                i++;
                r++;
            }
        }
    }
}
