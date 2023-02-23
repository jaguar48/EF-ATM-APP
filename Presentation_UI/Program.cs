using Data_PLL;

public class program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Team 2\n*****Developers*****");
        string[] list = new string[] { "Stanley Okonkwo", "Chinenye Maryrose Okeke", "Nnamani Stephen O" };

        foreach (string name in list)
        {
            Console.WriteLine($"> Dev {name}");
        }


        //Creating Database....Database name = EFCoreAtmAppDatabase
        AtmDbContextFactory atmDb = new();
        var dbContext = atmDb.CreateDbContext(null);
        
    }
}

