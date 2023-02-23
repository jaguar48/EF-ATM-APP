using Data_PLL;
using Data_PLL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Domain_BLL.Implementations
{
    public class BankOperations
    {
        private readonly AtmDbContextFactory _atmDb;


    
        public BankOperations()
        {
            _atmDb = new AtmDbContextFactory();
        }

        public async Task InsertCustomer(Customers customer)
        {
            if (!IsValidCustomer(customer))
            {
                Console.WriteLine("Invalid customer data. Please check your input.");
                return;
            }
            using (var context = _atmDb.CreateDbContext(null))
            {
               
                await context.Customers.AddRangeAsync(customer);
                await context.SaveChangesAsync();
            }
        }

        private bool IsValidCustomer(Customers customer)
        {
            
            if (!long.TryParse(customer.AccountNumber, out _))
            {
                Console.WriteLine("Invalid account number. Please enter a valid number.");
                return false;
            }

           
            if (customer.Pin.Length > 4)
            {
                Console.WriteLine("Invalid PIN. PIN must be up to 4 digits long.");
                return false;
            }

            return true;
        }
    }
}
