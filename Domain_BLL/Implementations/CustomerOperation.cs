using Data_PLL;
using Data_PLL.Entities;
using Domain_BLL.Interfaces;
using Domain_BLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.Implementations
{
    public class CustomerOperation:ICustomerOperations
    {

        private readonly AtmDbContextFactory _atmDb;
        private StringBuilder transactionHistory;

        public CustomerOperation()
        {
            _atmDb = new AtmDbContextFactory();
        }

      
        public async Task  Customeroperation() {
            var customerViewModels = CustomerList.GetCustomers();


            using (var context = _atmDb.CreateDbContext(null))
            {
                foreach (var customer in customerViewModels)
                {

                    var existingCustomer = context.Customers.FirstOrDefault(x => x.AccountNumber == customer.AccountNumber);


                    if (existingCustomer != null)
                    {
                        continue;
                    }

                    var newCustomer = new Customers
                    {
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        AccountName = customer.AccountName,
                        AccountNumber = customer.AccountNumber,
                        Pin = customer.Pin,
                        Balance = customer.Balance,
                        DateCreated = customer.DateCreated
                    };
                    await context.Customers.AddRangeAsync(newCustomer);

                    
                }
                
              
                await context.SaveChangesAsync();
            }
       
        }

        public void Deposit()
        {
            throw new NotImplementedException();
        }

        public async Task<Customers> Login(string accountNumber, string pin)
        {
            Customers LoggedCustomer;
            using (var context = _atmDb.CreateDbContext(null))
            {
               
                var customers = await context.Customers.Where(c => c.AccountNumber.Contains(accountNumber) && c.Pin.Contains(pin)).FirstOrDefaultAsync();

                
                LoggedCustomer = customers;
            }
            return LoggedCustomer;
        }

        public void PayBills()
        {
            throw new NotImplementedException();
        }

        public void RechargeCard()
        {
            throw new NotImplementedException();
        }

        public async Task<string> Transfer(string accountNumber, string pin, string receiverAcc, decimal TransferAmount)
        {

            string transactiontype = "transfer";
            using (var context = _atmDb.CreateDbContext(null))
            {
                var customer = await context.Customers.SingleOrDefaultAsync(x => x.AccountNumber == accountNumber && x.Pin == pin);
                string returnWord;
                if (receiverAcc == customer.AccountNumber)
                {
                    returnWord = "You can't Transfer to self :(";
                    return returnWord;
                }

                Console.Write("Purpose of transfer: ");
                string remark = Console.ReadLine();

                if (customer == null)
                {
                    returnWord = "Invalid account number or PIN.";
                    return returnWord;
                }


                if (TransferAmount <= 0)
                {
                    returnWord = "Invalid amount to Transfer.";
                    return returnWord;
                }

                if (TransferAmount > customer.Balance)
                {
                    returnWord = "Insufficient funds.";
                    return returnWord;
                }

                var receiver = await context.Customers.FirstOrDefaultAsync(x => x.AccountNumber == receiverAcc);
                if(receiver == null)
                {
                    returnWord = "Sorry, but the receiver's account could not be found";
                    return returnWord;
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n{customer.AccountName}, you are about to send {TransferAmount:C} to {receiver.AccountName}\n" +
                    $"press any key to continue");
                Console.ResetColor();
                var key = Console.ReadKey();
                if(key.KeyChar == 0)
                {
                    return null;
                }

                customer.Balance -= TransferAmount;
                receiver.Balance += TransferAmount;
                

                var transactionHistory = new TransactionHistory
                {
                    TransactionDate = DateTime.UtcNow,
                    TransactionType = transactiontype,
                    CustomersId= customer.Id,
                    Remark = remark
                };
                string outputSender = $"{transactionHistory.TransactionDate}\nTransfer of {TransferAmount} successful. New balance is {customer.Balance:C}.";
                Console.WriteLine();
                List<TransactionHistory> history = new List<TransactionHistory>();
                history.Append(transactionHistory);


                await context.SaveChangesAsync();

                return outputSender;
            }
        }

        public async Task<string> WithdrawAsync(string accountNumber, string pin, decimal amount)
        {
            using (var context = _atmDb.CreateDbContext(null))
            {
                var customer = await context.Customers.SingleOrDefaultAsync(x => x.AccountNumber == accountNumber && x.Pin == pin);

                if (customer == null)
                {
                    Console.WriteLine("Invalid account number or PIN.");
                    return null;
                }

                if (amount <= 0)
                {
                    Console.WriteLine("Invalid amount to withdraw.");
                    return null;
                }

                if (amount > customer.Balance)
                {
                    Console.WriteLine("Insufficient funds.");
                    return null;
                }

                customer.Balance -= amount;
                await context.SaveChangesAsync();

                string output = $"{DateTime.UtcNow}\nWithdrawal of {amount} successful. New balance is {customer.Balance:C}.";
                //transactionHistory.Append(output);
                return output;
            }
        }


        public async Task CheckBalanceAsync(string accountNumber, string pin)
        {
            using (var context = _atmDb.CreateDbContext(null))
            {
                try
                {
                    var customer = await context.Customers.SingleOrDefaultAsync(x => x.AccountNumber == accountNumber && x.Pin == pin);

                    if (customer == null)
                    {
                        Console.WriteLine("Invalid account number or PIN.");
                        return;
                    }

                    Console.WriteLine($"Account balance for {customer.AccountName}: {customer.Balance:C}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"{ex.Message} \nError: Multiple customers with the same account number and PIN.");

                }
            }
        }

        public void TransactionHistory()
        {
            Console.WriteLine(transactionHistory);
        }

    }
}

