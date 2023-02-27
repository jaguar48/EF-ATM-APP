using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_UI.Utility
{
    public class OperationsTable
    {
        public static void TransferTable()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("===============================================");
            Console.WriteLine("\t\tTRANSFER");
            Console.WriteLine("===============================================\n");
            LineAndColorModes.ResetColor();
        }

        public static void WithdrawalTable()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("===============================================");
            Console.WriteLine("\t\tWITHDRAW");
            Console.WriteLine("===============================================\n");
            LineAndColorModes.ResetColor();
        }

        public static void DepositTable()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("===============================================");
            Console.WriteLine("\t\tDEPOSIT");
            Console.WriteLine("===============================================\n");
            LineAndColorModes.ResetColor();
        }

        public static void AirtimeTable()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("===============================================");
            Console.WriteLine("\t\tAIRTIME");
            Console.WriteLine("===============================================\n");
            LineAndColorModes.ResetColor();
        }

        public static void PaybillsTable()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("===============================================");
            Console.WriteLine("\t\tPAY BILLS");
            Console.WriteLine("===============================================\n");
            LineAndColorModes.ResetColor();
        }
    }
}
