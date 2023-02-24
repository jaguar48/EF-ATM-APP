﻿
using Data_PLL.Entities;

namespace Domain_BLL.Interfaces
{
    public interface ICustomerOperations
    {
        Task<Customers> Login(string accountNumber, string pin);
        void Withdrawal();
        void Deposit();
        void Transfer();
        void RechargeCard();
        void PayBills();
    }
}
