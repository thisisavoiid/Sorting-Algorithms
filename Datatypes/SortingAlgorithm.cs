using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortieralgorithmen
{
    /// <summary>
    /// Base class for all sorting algorithms.
    /// Defines the structure and contract for sorting implementations.
    /// </summary>
    public abstract class SortingAlgorithm
    {
        /// <summary>
        /// Gets the name of the sorting algorithm.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Sorts the provided array in-place according to the algorithm's logic.
        /// </summary>
        /// <param name="array">The integer array to sort.</param>
        public abstract void Sort(int[] array);
    }
}
