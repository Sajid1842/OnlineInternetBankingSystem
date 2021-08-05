using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineInternetBanking.Entities
{
    public partial class AccountDetail
    {
        public AccountDetail()
        {
            TransactionDetails = new HashSet<TransactionDetail>();
        }

        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public decimal MinimumBalance { get; set; }
        public decimal TotalBalance { get; set; }
        public int? CustomerId { get; set; }
        public decimal? InterestAmount { get; set; }
        public string PassWord { get; set; }

        public virtual CustomerDetail Customer { get; set; }
        public virtual ICollection<TransactionDetail> TransactionDetails { get; set; }
    }
}
