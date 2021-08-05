using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineInternetBanking.Entities
{
    public partial class TransactionDetail
    {
        public int TransactionId { get; set; }
        public string AccountNumber { get; set; }
        public DateTime? TransactionDate { get; set; }
        public decimal TransactionAmount { get; set; }
        public string TransactionType { get; set; }

        public virtual AccountDetail AccountNumberNavigation { get; set; }
    }
}
