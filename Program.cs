using System;
using System.Reflection;
using System.Runtime;
using System.Runtime.InteropServices;

namespace Sortieralgorithmen
{
    internal class Program
    {
        // ==================================================
        // CONSTANTS
        // ==================================================
        private const int _maxRandomLength = 20;
        private const int _minRandomLength = 5;
        private const int _maxRandomIntValue = 99;
        private const int _minRandomIntValue = 1;

        // ==================================================
        // MAIN ENTRY
        // ==================================================
        /// <summary>
        /// Entry point: handles array input, sorting selection, execution, and output display.
        /// </summary>
        static void Main(string[] args)
        {
            string input = string.Empty;
            Random random = new Random();
            List<int> numbers = new List<int>();

            // ==================================================
            // INPUT TYPE
            // ==================================================
            while (!new string[] { "c", "r" }.Contains(input.ToLower()))
            {
                Console.Clear();
                Console.WriteLine("Custom numbers or random numbers? (c/r)");
                input = Console.ReadLine();
            }

            Console.Clear();

            // ==================================================
            // CUSTOM INPUT
            // ==================================================
            if (input.ToLower() == "c")
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("You can enter custom numeral values by typing them and hitting enter.");
                    Console.WriteLine("End this procress by typing DONE.");
                    Console.WriteLine($"Your array: [{string.Join(", ", numbers)}]");

                    input = Console.ReadLine();

                    if (input.ToLower() == "done")
                        break;

                    if (!LogicLib.IsNumeral(input))
                    {
                        Console.WriteLine("You can't add this item to your array as it is non-numeral!");
                        Thread.Sleep(1000);
                        continue;
                    }

                    numbers.Add(int.Parse(input));
                }

                Console.Clear();
            }

            // ==================================================
            // RANDOM INPUT
            // ==================================================
            if (input.ToLower() == "r")
            {
                int arrayLength = random.Next(_minRandomLength, _maxRandomLength);

                Console.WriteLine("Generating a random array with the following specifications:");
                Console.WriteLine($"Random integer range: {_minRandomIntValue}-{_maxRandomIntValue}");
                Console.WriteLine($"Array size: {arrayLength}");

                for (int i = 0; i < arrayLength - 1; i++)
                {
                    numbers.Add(random.Next(_minRandomIntValue, _maxRandomIntValue));
                }
            }

            int[] numbersArray = numbers.ToArray();

            // ==================================================
            // SELECT ALGORITHM
            // ==================================================
            input = string.Empty;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose the algorithm to use:");
                Console.WriteLine("1. Merge Sort");
                Console.WriteLine("2. Quick Sort");
                Console.WriteLine("3. Selection Sort");

                input = Console.ReadLine();

                if (!LogicLib.IsNumeral(input))
                {
                    Console.WriteLine("Your selection input must be numeric!");
                    Thread.Sleep(1000);
                    continue;
                }

                if (!LogicLib.IsInRange(int.Parse(input), 1, 3))
                {
                    Console.WriteLine("Your selected algorithm does not exist!");
                    Thread.Sleep(1000);
                    continue;
                }

                break;
            }

            Console.Clear();

            // ==================================================
            // EXECUTE SORT
            // ==================================================
            switch (int.Parse(input))
            {
                case 1: MergeSort.Sort(numbersArray); break;
                case 2: QuickSort.Sort(numbersArray); break;
                case 3: SelectionSort.Sort(numbersArray); break;
            }

            // ==================================================
            // OUTPUT ORDER
            // ==================================================
            input = string.Empty;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Which way do you want the output to be made?");
                Console.WriteLine("1. Descending (e.g. 9-1)");
                Console.WriteLine("2. Ascending (e.g. 1-9)");
                Console.WriteLine("3. Crossed");

                input = Console.ReadLine();

                if (!LogicLib.IsNumeral(input))
                {
                    Console.WriteLine("Your selection input must be numeric!");
                    Thread.Sleep(1000);
                    continue;
                }

                if (!LogicLib.IsInRange(int.Parse(input), 1, 3))
                {
                    Console.WriteLine("Your selected algorithm does not exist!");
                    Thread.Sleep(1000);
                    continue;
                }

                break;
            }

            Console.Clear();

            // ==================================================
            // DISPLAY OUTPUT
            // ==================================================
            switch (int.Parse(input))
            {
                case 1:
                    Console.WriteLine("[" + string.Join(" ", numbersArray.Reverse()) + "]");
                    break;
                case 2:
                    Console.WriteLine("[" + string.Join(" ", numbersArray) + "]");
                    break;
                case 3:
                    {
                        int[] outputArray = new int[numbersArray.Length];
                        int i = 0;
                        while (i < numbersArray.Length)
                        {
                            if (numbersArray.Length - i > 1)
                            {
                                outputArray[i] = numbersArray[i];
                                outputArray[i + 1] = numbersArray[numbersArray.Length - i - 1];
                            }
                            else
                            {
                                outputArray[i] = numbersArray[i];
                            }
                            i += 2;
                        }
                        Console.WriteLine("[" + string.Join(", ", outputArray) + "]");
                        break;
                    }
            }
        }
    }
}
