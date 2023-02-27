using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_UI.Utility
{
    public static class LineAndColorModes
    {
        public static void Display(string text) 
        {
            Yellow();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("\t" + text);
            Console.WriteLine("--------------------------------------------------");
            ResetColor();
        }

        public static void Yellow()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        public static void Red()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        public static void ResetColor() 
        {
            Console.ResetColor();
        }
    }
}
