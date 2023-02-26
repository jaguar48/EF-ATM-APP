
using Data_PLL.Entities;
using Domain_BLL.Models;

namespace Domain_BLL.Interfaces
{
    public interface ICustomerOperations
    {
        Task<Customers> Login(string accountNumber, string pin);
        Task<string> WithdrawAsync(string accountNumber, string pin, decimal amount);
        Task CheckBalanceAsync(string accountNumber, string pin);
        void Deposit();
        Task<string> Transfer(string accountNumber, string pin, string receiverAcc, decimal TransferAmount);    
        void RechargeCard();
        void PayBills();
    }
}
