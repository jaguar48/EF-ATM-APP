using Data_PLL;
using Data_PLL.Entities;
using Domain_BLL;
using Domain_BLL.Implementations;
using System.Net.NetworkInformation;

public class Program
{
    public static async Task Main(string[] args)
    {
        CustomerOperation customerOperation = new CustomerOperation();
        await customerOperation.Customeroperation();

        string accountNumber;
        string pin;
        Customers loggedUser;

        while (true)
        {
            Console.Write("Enter your Account Number: ");
            accountNumber = Console.ReadLine();
            Console.Write("Enter your Login Pin: ");
            pin = Console.ReadLine();

            if (string.IsNullOrEmpty(accountNumber) || string.IsNullOrEmpty(pin))
            {
                Console.WriteLine("Invalid account number or PIN. Please try again.");
                continue;
            }

            loggedUser = await customerOperation.Login(accountNumber, pin);
            if (loggedUser == null)
            {
                Console.WriteLine("Invalid account number or PIN. Please try again.");
                continue;
            }

            Console.WriteLine($"Welcome {loggedUser.AccountName} and Balance is {loggedUser.Balance:C}");
            break;
        }

        while (true)
        {
            Console.WriteLine("Enter an option:");
            Console.WriteLine("1. Check balance");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Transfer");
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
                    await customerOperation.WithdrawAsync(loggedUser.AccountNumber, loggedUser.Pin, withdrawAmount);
                    break;
                case 3:
                    Console.WriteLine("Enter the amount to deposit: ");
                    decimal depositAmount;
                    while (!Decimal.TryParse(Console.ReadLine(), out depositAmount))
                    {
                        Console.WriteLine("Invalid amount. Please enter a number.");
                    }
                    await customerOperation.DepositAsync(loggedUser.AccountNumber, loggedUser.Pin, depositAmount);
                    break;
                case 4:
                    Console.Write("Enter the amount to transfer: ");
                    decimal transferAmount;
                    while (!Decimal.TryParse(Console.ReadLine(), out transferAmount))
                    {
                        Console.WriteLine("Invalid amount. Please enter a number.");
                    }
                    Console.Write("Enter recipient's account number: ");
                    string recipientAccountNumber = Console.ReadLine();
                    await customerOperation.TransferAsync(loggedUser.AccountNumber, loggedUser.Pin, recipientAccountNumber, transferAmount);
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
