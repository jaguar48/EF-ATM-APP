using Data_PLL;
using Data_PLL.Entities;
using Domain_BLL.Interfaces;
using Domain_BLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.Implementations
{
    public class CustomerOperation : ICustomerOperations
    {

        private readonly AtmDbContextFactory _atmDb;

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

        public async Task<CustomerViewModel> DepositAsync(string accountNumber, string pin, decimal amount)
        {

            using var context = _atmDb.CreateDbContext(null);

            var customer = await context.Customers.SingleOrDefaultAsync(x => x.AccountNumber == accountNumber && x.Pin == pin);

            if (customer == null)
            {
                Console.WriteLine("Invalid account number or PIN.");
                return null;
            }
            if (amount == 0)
            {
                Console.WriteLine("Invalid amount.");
                return null;
            }


            customer.Balance += amount;
            await context.SaveChangesAsync();

            var customerViewModel = new CustomerViewModel
            {

                AccountNumber = customer.AccountNumber,
                Balance = customer.Balance
            };

            Console.WriteLine($"You have successfully made a deposit of {amount}. New balance is {customer.Balance:C}.");
            return customerViewModel;
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


        public async Task TransferAsync(string accountNumber, string pin, string receiverAccountNo, decimal TransferAmount)
        {

            using (var context = _atmDb.CreateDbContext(null))
            {
                var customer = await context.Customers.SingleOrDefaultAsync(x => x.AccountNumber == accountNumber && x.Pin == pin);
                
                if (receiverAccountNo == customer.AccountNumber)
                {
                    Console.WriteLine("You can't Transfer to self :("); 
                }

                Console.Write("Narration: ");
                string remark = Console.ReadLine();

                if (customer == null)
                {
                   Console.WriteLine("Invalid account number or PIN.");
                    
                }


                if (TransferAmount <= 0)
                {
                    Console.WriteLine("Invalid amount to Transfer.");
                    
                }

                if (TransferAmount > customer.Balance)
                {
                    Console.WriteLine("Insufficient funds.");
                }

                var receiver = await context.Customers.FirstOrDefaultAsync(x => x.AccountNumber == receiverAccountNo);
                if (receiver == null)
                {
                    Console.WriteLine("Sorry, but the receiver's account could not be found");
                    
                }
                
                Console.WriteLine($"\nYou are about to send {TransferAmount:C} to {receiver.AccountName}\n" +
                    $"press any key to continue");
               
                Console.ReadKey();

                customer.Balance -= TransferAmount;
                receiver.Balance += TransferAmount;

                await context.SaveChangesAsync();

                Console.WriteLine($"Transfer Successful!");
                
            }
        }

        public async Task<CustomerViewModel> WithdrawAsync(string accountNumber, string pin, decimal amount)
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

                var customerViewModel = new CustomerViewModel
                {
                    
                    AccountNumber = customer.AccountNumber,
                    Balance = customer.Balance
                };

                Console.WriteLine($"Withdrawal of {amount} successful. New balance is {customer.Balance:C}.");
                return customerViewModel;
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
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Error: Multiple customers with the same account number and PIN.");
                   
                }
            }
        }






    }
}

