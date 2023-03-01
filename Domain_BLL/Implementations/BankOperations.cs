using Data_PLL;

namespace Domain_BLL.Implementations
{
    public class BankOperations
    {
        private readonly AtmDbContextFactory _atmDb;



        public BankOperations()
        {
            _atmDb = new AtmDbContextFactory();
        }


    }
}
