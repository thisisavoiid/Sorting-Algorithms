using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Runtime.InteropServices;

namespace Sortieralgorithmen
{
    internal class Program
    {
        private const int _maxRandomLength = 20;      // Maximum array length for random arrays
        private const int _minRandomLength = 5;       // Minimum array length for random arrays
        private const int _maxRandomIntValue = 99;    // Maximum value for random numbers
        private const int _minRandomIntValue = 1;     // Minimum value for random numbers

        private static SortingAlgorithm[] _algorithms = DataManager.GetAllAlgorithms(); // Load all available algorithms

        /// <summary>
        /// Entry point: handles array input, sorting selection, execution, and output display.
        /// </summary>
        static void Main(string[] args)
        {
            string input = string.Empty;
            Random random = new Random();

            // ========================
            // INPUT TYPE SELECTION
            // ========================
            while (!new string[] { "c", "r" }.Contains(input.ToLower()))
            {
                Console.Clear();
                Console.WriteLine("Custom numbers or random numbers? (c/r)");
                input = Console.ReadLine();
            }
            Console.Clear();

            // ========================
            // CUSTOM INPUT
            // ========================
            if (input.ToLower() == "c")
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("You can enter custom numeral values by typing them and hitting enter.");
                    Console.WriteLine("End this process by typing DONE.");
                    Console.WriteLine($"Your array: [{string.Join(", ", DataManager.Numbers)}]");

                    input = Console.ReadLine();

                    if (input.ToLower() == "done")
                        break;

                    if (!LogicLib.IsNumeral(input))
                    {
                        Console.WriteLine("You can't add this item to your array as it is non-numeral!");
                        Thread.Sleep(1000);
                        continue;
                    }

                    // Add input to the existing array
                    int[] tempArray = new int[DataManager.Numbers.Length + 1];
                    for (int i = 0; i < DataManager.Numbers.Length; i++)
                    {
                        tempArray[i] = DataManager.Numbers[i];
                    }
                    tempArray[tempArray.Length - 1] = int.Parse(input);
                    DataManager.Numbers = tempArray;
                }
                Console.Clear();
            }

            // ========================
            // RANDOM INPUT
            // ========================
            if (input.ToLower() == "r")
            {
                int arrayLength = random.Next(_minRandomLength, _maxRandomLength);
                Console.WriteLine("Generating a random array with the following specifications:");
                Console.WriteLine($"Random integer range: {_minRandomIntValue}-{_maxRandomIntValue}");
                Console.WriteLine($"Array size: {arrayLength}");

                int[] tempArray = new int[arrayLength];
                for (int i = 0; i < arrayLength; i++)
                {
                    tempArray[i] = random.Next(_minRandomIntValue, _maxRandomIntValue);
                }
                DataManager.Numbers = tempArray;
            }

            // ========================
            // SELECT ALGORITHM
            // ========================
            MenuOption[] options = _algorithms
                .Select(a => new MenuOption { Name = a.Name })
                .ToArray();

            MenuChoice algorithmSelection = new MenuChoice(
                "Choose the algorithm to use:",
                options,
                true
            );

            int choiceMadeInFlow = algorithmSelection.Execute();
            Console.Clear();

            SortingAlgorithm algorithmToUse = _algorithms[choiceMadeInFlow - 1];
            algorithmToUse.Sort(DataManager.Numbers);

            // ========================
            // OUTPUT ORDER SELECTION
            // ========================
            options = new MenuOption[]
            {
                new MenuOption{ Name= "Descending (e.g. 9-1)"},
                new MenuOption{ Name= "Ascending (e.g. 1-9)"},
                new MenuOption{ Name= "Crossed"}
            };

            MenuChoice outputOrderSelection = new MenuChoice(
                "Which way do you want the output to be displayed?",
                options,
                true
            );

            choiceMadeInFlow = outputOrderSelection.Execute();

            // ========================
            // DISPLAY OUTPUT
            // ========================
            switch (choiceMadeInFlow)
            {
                case 1: // Descending
                    Console.WriteLine("[" + string.Join(", ", DataManager.Numbers.Reverse()) + "]");
                    break;

                case 2: // Ascending
                    Console.WriteLine("[" + string.Join(", ", DataManager.Numbers) + "]");
                    break;

                case 3: // Crossed
                    int[] outputArray = new int[DataManager.Numbers.Length];
                    int i = 0;
                    while (i < DataManager.Numbers.Length)
                    {
                        if (DataManager.Numbers.Length - i > 1)
                        {
                            outputArray[i] = DataManager.Numbers[i];
                            outputArray[i + 1] = DataManager.Numbers[DataManager.Numbers.Length - i - 1];
                        }
                        else
                        {
                            outputArray[i] = DataManager.Numbers[i];
                        }
                        i += 2;
                    }
                    Console.WriteLine("[" + string.Join(", ", outputArray) + "]");
                    break;
            }
        }
    }
}
