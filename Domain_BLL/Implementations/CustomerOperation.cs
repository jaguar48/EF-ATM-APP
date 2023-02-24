using Data_PLL;
using Data_PLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.Implementations
{
    public class CustomerOperation
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

<<<<<<< HEAD

        public async Task<Customers> Login(string accountNumber, string pin)
        {
            Customers LoggedCustomer;
            using (var context = _atmDb.CreateDbContext(null))
            {
                // Query the database using LINQ syntax
                var customers = await context.Customers.Where(c => c.AccountNumber.Contains(accountNumber) && c.Pin.Contains(pin)).FirstOrDefaultAsync();

                // Do something with the results
                LoggedCustomer = customers;
            }
            return LoggedCustomer;
        }

public void Deposit()
        {
            throw new NotImplementedException();
        }

        public void PayBills()
        {
            throw new NotImplementedException();
        }

        public void RechargeCard()
        {
            throw new NotImplementedException();
        }

        public void Transfer()
        {
            throw new NotImplementedException();
        }

        public void Withdrawal()
        {
            throw new NotImplementedException();
        }
=======
            
>>>>>>> 98946fad6a83dfbc214a39eed36ee1dd8b0300b3
    }
}

