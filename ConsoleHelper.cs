using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleQuestionnaire
{
    /// <summary>
    /// Helper class for Console
    /// </summary>
    public static class ConsoleHelper
    {
        public static void WriteLineAsColour(object o, ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
            Console.WriteLine(o);
            Console.ResetColor();
        }
    }
}
