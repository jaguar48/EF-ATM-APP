using Data_PLL;
using Data_PLL.Entities;
using Domain_BLL;
using Domain_BLL.Implementations;
using Presentation_UI.Utility;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;

public class program
{
    public static async Task Main(string[] args)
    {
        CustomerOperation customerOperation = new CustomerOperation();
        try
        {
            await customerOperation.Customeroperation();
        }
        catch
        {
            return;
        }
        string accountNumber;
        string pin;
        Console.Write("Enter your Account Number: ");
        accountNumber = Console.ReadLine();
        Console.Write("Enter your Login Pin: ");
        pin = Console.ReadLine();

        Customers loggedUser = await customerOperation.Login(accountNumber, pin);
        if (loggedUser == null)
        {
            Console.WriteLine("Invalid account number or PIN.");
            return;
        }

        Console.WriteLine($"Welcome {loggedUser.AccountName} and Balance is {loggedUser.Balance:C}");

        while (true)
        {
            Console.WriteLine("Enter an option:");
            Console.WriteLine("1. Check balance");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Transfer");
            Console.WriteLine("4. Transaction History");
            Console.WriteLine("5. Exit");

            int option;
            while (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid option. Please enter a number.");
            }

            switch (option)
            {
                case 1:
                    await customerOperation.CheckBalanceAsync(loggedUser.AccountNumber, loggedUser.Pin);
                    break;
               
                case 2:
                    Console.Write("Enter the amount to withdraw: ");
                    decimal withdrawAmount;
                    while (!decimal.TryParse(Console.ReadLine(), out withdrawAmount))
                    {
                        Console.WriteLine("Invalid amount. Please enter a number.");
                    }
                    string outputW = await customerOperation.WithdrawAsync(loggedUser.AccountNumber, loggedUser.Pin, withdrawAmount);
                    LineAndColorModes.Display(outputW);
                    break;
                case 3:
                    Console.Clear();
                    OperationsTable.TransferTable();
                    string receiverAcc;
                    recv:
                    Console.Write("Enter the Receiver's Account: ");
                    receiverAcc = Console.ReadLine();
                    if(receiverAcc.Count() != 10)
                    {
                        Console.WriteLine("Incomplete Receiver's account, try again");
                        goto recv;
                    }
                    here:
                    Console.Write("Enter the amount to Transfer: ");
                    decimal TransferAmount;
                    while (!decimal.TryParse(Console.ReadLine(), out TransferAmount))
                    {
                        Console.WriteLine("Invalid amount. Please enter a number.");
                        
                    }
                    if (TransferAmount < 1)
                    {
                        Console.WriteLine("Invalid amount");
                        goto here;
                    }
                    string outputT = await customerOperation.Transfer(loggedUser.AccountNumber, loggedUser.Pin, receiverAcc, TransferAmount);
                    LineAndColorModes.Display(outputT);
                    break;
                case 4:
                    customerOperation.TransactionHistory();
                    break;
                case 5:
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please enter a number between 1 and 4.");
                    break;
            }
        }
    }

}

