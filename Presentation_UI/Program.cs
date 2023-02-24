using Data_PLL;
using Data_PLL.Entities;
using Domain_BLL;
using Domain_BLL.Implementations;


public class program
{
    public static async Task Main(string[] args)
    {
        //Console.WriteLine("Team 2\n*****Developers*****");
        //string[] list = new string[] { "Okonkwo", "Chinenye Maryrose Okeke", "Nnamani Stephen O" };

        //foreach (string name in list)
        //{
        //    Console.WriteLine($"> Dev {name}");
        //}

        CustomerOperation customerOperation = new CustomerOperation();

        //await customerOperation.Customeroperation();
        string accountNumber;
        string pin;
        Console.Write("Enter your Account Number: ");
        accountNumber = Console.ReadLine();
        Console.Write("Enter your Login Pin: ");
        pin = Console.ReadLine();
<<<<<<< HEAD
        Customers loggedUser = await customerOperation.Login(accountNumber, pin);
        Console.WriteLine($"Welcome {loggedUser.AccountName}");
=======
        customerOperation.Login(accountNumber, pin);
        

        
               
>>>>>>> 98946fad6a83dfbc214a39eed36ee1dd8b0300b3
    }
}

