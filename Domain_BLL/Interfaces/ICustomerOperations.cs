
using Data_PLL.Entities;
using Domain_BLL.Models;

namespace Domain_BLL.Interfaces
{
    public interface ICustomerOperations
    {
        Task<Customers> Login(string accountNumber, string pin);
        Task<CustomerViewModel> WithdrawAsync(string accountNumber, string pin, decimal amount);
        Task CheckBalanceAsync(string accountNumber, string pin);
        void Deposit();
        void Transfer();    
        void RechargeCard();
        void PayBills();
    }
}
