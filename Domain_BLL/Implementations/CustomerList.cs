using Data_PLL.Entities;
using Domain_BLL.Models;

namespace Domain_BLL.Implementations
{
    public class CustomerList
    {
        public static List<CustomerViewModel> GetCustomers()
        {
            var customers = new List<CustomerViewModel>()
            {
                new CustomerViewModel
                {
                    FirstName = "Alice",
                    LastName = "Smith",
                    AccountName = "ASmith",
                    AccountNumber = "1234567891",
                    Pin = "2345",
                    Balance = 1500.00m,
                    DateCreated = DateTime.Now
                },
                new CustomerViewModel
                {
                    FirstName = "Bob",
                    LastName = "Johnson",
                    AccountName = "BJohnson",
                    AccountNumber = "1234567892",
                    Pin = "3456",
                    Balance = 2000.00m,
                    DateCreated = DateTime.Now
                },
                new CustomerViewModel
                {
                    FirstName = "Charlie",
                    LastName = "Brown",
                    AccountName = "CBrown",
                    AccountNumber = "1234567893",
                    Pin = "4567",
                    Balance = 2500.00m,
                    DateCreated = DateTime.Now
                },
                new CustomerViewModel
                {
                    FirstName = "David",
                    LastName = "Lee",
                    AccountName = "DLee",
                    AccountNumber = "1234567894",
                    Pin = "5678",
                    Balance = 3000.00m,
                    DateCreated = DateTime.Now
                },
                new CustomerViewModel
                {
                    FirstName = "Emily",
                    LastName = "Chen",
                    AccountName = "EChen",
                    AccountNumber = "1234567895",
                    Pin = "6789",
                    Balance = 3500.00m,
                    DateCreated = DateTime.Now
                },
                new CustomerViewModel
                {
                    FirstName = "ebuka",
                    LastName = "Chene",
                    AccountName = "ebuschen",
                    AccountNumber = "1234567895",
                    Pin = "6789",
                    Balance = 3500.00m,
                    DateCreated = DateTime.Now
                },
                new CustomerViewModel
                {
                    FirstName = "staley",
                    LastName = "Che2n",
                    AccountName = "ebuschen",
                    AccountNumber = "122345678",
                    Pin = "7811",
                    Balance = 35020.00m,
                    DateCreated = DateTime.Now
                },
                new CustomerViewModel
                {
                    FirstName = "bishop",
                    LastName = "okonkwo",
                    AccountName = "bishop",
                    AccountNumber = "4338838337",
                    Pin = "33888",
                    Balance = 325020.00m,
                    DateCreated = DateTime.Now
                },
                 new CustomerViewModel
                {
                    FirstName = "micheal",
                    LastName = "orjiakor",
                    AccountName = "mikeorji",
                    AccountNumber = "27920222",
                    Pin = "33888",
                    Balance = 325020.00m,
                    DateCreated = DateTime.Now
                },
                  new CustomerViewModel
                {
                    FirstName = "jessica",
                    LastName = "okeke",
                    AccountName = "jessykeorji",
                    AccountNumber = "2913533",
                    Pin = "6443",
                    Balance = 36020.00m,
                    DateCreated = DateTime.Now
                },  
                new CustomerViewModel
                {
                    FirstName = "mark",
                    LastName = "essien",
                    AccountName = "essienykeorji",
                    AccountNumber = "55555555",
                    Pin = "5443",
                    Balance = 86020.00m,
                    DateCreated = DateTime.Now
                },
                new CustomerViewModel
                {
                    FirstName = "amaka",
                    LastName = "akwaonu",
                    AccountName = "amakaykeorji",
                    AccountNumber = "666445555",
                    Pin = "7443",
                    Balance = 86020.00m,
                    DateCreated = DateTime.Now
                }

        };

            return customers;

            /* foreach (var customer in customers)
             {



                 await bankOperations.InsertCustomer(customer);
                 Console.WriteLine("inserted correctly");
             }*/

        }

    }
}
