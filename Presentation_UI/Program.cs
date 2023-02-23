using Data_PLL;
using Data_PLL.Entities;
using Domain_BLL;
using Domain_BLL.Implementations;


public class program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Team 2\n*****Developers*****");
        string[] list = new string[] { "Okonkwo", "Chinenye Maryrose Okeke", "Nnamani Stephen O" };

        foreach (string name in list)
        {
            Console.WriteLine($"> Dev {name}");
        }


        var bankOperations = new BankOperations();

        var customers = new List<Customers>()
        {
            new Customers
            {
                FirstName = "Alice",
                LastName = "Smith",
                AccountName = "ASmith",
                AccountNumber = "1234567891",
                Pin = "2345",
                Balance = 1500.00m,
                DateCreated = DateTime.Now
            },
            new Customers
            {
                FirstName = "Bob",
                LastName = "Johnson",
                AccountName = "BJohnson",
                AccountNumber = "1234567892",
                Pin = "3456",
                Balance = 2000.00m,
                DateCreated = DateTime.Now
            },
            new Customers
            {
                FirstName = "Charlie",
                LastName = "Brown",
                AccountName = "CBrown",
                AccountNumber = "1234567893",
                Pin = "4567",
                Balance = 2500.00m,
                DateCreated = DateTime.Now
            },
            new Customers
            {
                FirstName = "David",
                LastName = "Lee",
                AccountName = "DLee",
                AccountNumber = "1234567894",
                Pin = "5678",
                Balance = 3000.00m,
                DateCreated = DateTime.Now
            },
            new Customers
            {
                FirstName = "Emily",
                LastName = "Chen",
                AccountName = "EChen",
                AccountNumber = "1234567895",
                Pin = "6789",
                Balance = 3500.00m,
                DateCreated = DateTime.Now
            }
        };

        foreach (var customer in customers)
        {
            await bankOperations.InsertCustomer(customer);
            Console.WriteLine("inserted successfully");
        }


    }
}

