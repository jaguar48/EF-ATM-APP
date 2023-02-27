using Data_PLL;
using Data_PLL.Entities;
using Domain_BLL;
using Domain_BLL.Implementations;
using System.Net.NetworkInformation;


public class program
{
    public static async Task Main(string[] args)
    {
        CustomerOperation customerOperation = new CustomerOperation();
        await customerOperation.Customeroperation();

        Console.WriteLine("Group 2");

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
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Exit");

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
                    while(!Decimal.TryParse(Console.ReadLine(), out depositAmount))
                    {
                        Console.WriteLine("Invalid amount. Please enter a number.");
                    }
                    await customerOperation.DepositAsync(loggedUser.AccountNumber, loggedUser.Pin, depositAmount);
                    break;
                case 4:
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please enter a number between 1 and 4.");
                    break;
            }
        }
    }

}

