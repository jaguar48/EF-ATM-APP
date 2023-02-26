using Data_PLL;
using Data_PLL.Entities;
using Domain_BLL.Interfaces;
using Domain_BLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
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
            using (var context = _atmDb.CreateDbContext(null))
            {
                var customer = await context.Customers.SingleOrDefaultAsync(x => x.AccountNumber == accountNumber && x.Pin == pin);

                if (customer == null)
                {
                    Console.WriteLine("Invalid account number or PIN.");
                    return null;
                }

                if (TransferAmount <= 0)
                {
                    Console.WriteLine("Invalid amount to withdraw.");
                    return null;
                }

                if (TransferAmount > customer.Balance)
                {
                    Console.WriteLine("Insufficient funds.");
                    return null;
                }
                var receiver = await context.Customers.FirstOrDefaultAsync(x => x.AccountNumber == accountNumber);

                customer.Balance -= TransferAmount;
                receiver.Balance += TransferAmount;

                await context.SaveChangesAsync();

                var customerViewModel = new CustomerViewModel
                {

                    AccountNumber = customer.AccountNumber,
                    Balance = customer.Balance
                };

                string output = $"Withdrawal of {TransferAmount} successful. New balance is {customer.Balance:C}.";
                return output;
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

                string output = $"Withdrawal of {amount} successful. New balance is {customer.Balance:C}.";
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

    }
}

