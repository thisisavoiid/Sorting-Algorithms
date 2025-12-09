using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortieralgorithmen
{
    /// <summary>
    /// Represents a single option in a menu.
    /// </summary>
    public struct MenuOption
    {
        public string Name;          // Display name of the option
        public object Value;         // Optional value associated with the option
        public bool CaseSensitive;   // Whether option matching is case-sensitive
    }
}
