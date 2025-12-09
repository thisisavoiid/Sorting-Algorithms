using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sortieralgorithmen
{
    public class DataManager
    {
        private static int[] _numbers = new int[0];

        /// <summary>
        /// Gets or sets the array of numbers.
        /// Setting triggers <see cref="RefreshNumbersArray(int[])"/>.
        /// </summary>
        public static int[] Numbers
        {
            get => _numbers;
            set => RefreshNumbersArray(value);
        }

        private static Assembly _executingAssembly = Assembly.GetExecutingAssembly();

        /// <summary>
        /// Updates the internal numbers array with a new array.
        /// Ensures proper resizing when the new array is larger.
        /// </summary>
        /// <param name="newNumbers">The new array to replace the current numbers.</param>
        private static void RefreshNumbersArray(int[] newNumbers)
        {
            // Ensure resizing if new array is larger
            if (newNumbers.Length > _numbers.Length)
            {
                int[] tempNumArray = new int[newNumbers.Length];
                for (int i = 0; i < newNumbers.Length; i++)
                {
                    tempNumArray[i] = newNumbers[i];
                }
                _numbers = tempNumArray;
            }

            _numbers = newNumbers;
        }

        /// <summary>
        /// Retrieves all concrete subclasses of <see cref="SortingAlgorithm"/> in the executing assembly.
        /// </summary>
        /// <returns>Array of <see cref="SortingAlgorithm"/> instances.</returns>
        public static SortingAlgorithm[] GetAllAlgorithms()
        {
            return _executingAssembly
                .GetTypes()
                .Where(t =>
                    t.IsClass &&
                    !t.IsAbstract &&
                    t.IsSubclassOf(typeof(SortingAlgorithm))
                )
                .Select(t => (SortingAlgorithm)Activator.CreateInstance(t))
                .ToArray();
        }
    }
}
