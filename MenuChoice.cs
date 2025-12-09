using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortieralgorithmen
{
    /// <summary>
    /// Represents a menu with selectable options and executes user input.
    /// </summary>
    public class MenuChoice
    {
        private string _prompt;
        private MenuOption[] _options;
        private bool _isEnumerable;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuChoice"/> class.
        /// </summary>
        /// <param name="prompt">The text to display above the menu options.</param>
        /// <param name="options">Array of <see cref="MenuOption"/> objects representing the choices.</param>
        /// <param name="isEnumerable">If true, options are numbered for selection.</param>
        public MenuChoice(string prompt, MenuOption[] options, bool isEnumerable)
        {
            _prompt = prompt;
            _options = options;
            _isEnumerable = isEnumerable;
        }

        /// <summary>
        /// Displays the menu, validates user input, and returns the selected option index.
        /// </summary>
        /// <returns>Selected option index as an integer.</returns>
        public int Execute()
        {
            string input = string.Empty;

            // ========================
            // MENU LOOP
            // ========================
            while (true)
            {
                Console.Clear();
                Console.WriteLine(_prompt);

                // Display all menu options
                for (int i = 0; i < _options.Length; i++)
                {
                    if (_isEnumerable)
                        Console.WriteLine($"[{i + 1}] {_options[i].Name}");
                    else
                        Console.WriteLine($"[{_options[i].Value}] {_options[i].Name}");
                }

                input = Console.ReadLine();

                // ========================
                // INPUT VALIDATION
                // ========================
                if (_isEnumerable)
                {
                    if (!LogicLib.IsNumeral(input))
                    {
                        DebugPrinter.Print(
                            "Your input must be numeric!",
                            DebugPrinter.DebugLevel.Error
                        );
                        Thread.Sleep(2000);
                        continue;
                    }

                    if (!LogicLib.IsInRange(int.Parse(input), 1, _options.Length))
                    {
                        DebugPrinter.Print(
                            "The selection you made is invalid. Try again.",
                            DebugPrinter.DebugLevel.Error
                        );
                        Thread.Sleep(2000);
                        continue;
                    }
                }

                // Return the valid selection
                return int.Parse(input);
            }
        }
    }
}
