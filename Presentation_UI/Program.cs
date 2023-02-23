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

        CustomerOperation customerOperation = new CustomerOperation();

        await customerOperation.Customeroperation();

        
               
    }
}

