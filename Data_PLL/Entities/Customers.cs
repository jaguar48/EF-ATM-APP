﻿

namespace Data_PLL.Entities
{
    public class Customers : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string Pin { get; set; }
        public decimal Balance { get; set; }
        public DateTime DateCreated { get; set; }



        public IEnumerable<TransactionHistory> TransactionHistories { get; set; } = new List<TransactionHistory>();

    }
}
