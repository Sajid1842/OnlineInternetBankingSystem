using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineInternetBanking.Entities
{
    public partial class CustomerDetail
    {
        public CustomerDetail()
        {
            AccountDetails = new HashSet<AccountDetail>();
            NomineeDetails = new HashSet<NomineeDetail>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public decimal PhoneNo { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }
        public decimal AadharNo { get; set; }
        public string AccountType { get; set; }

        public virtual ICollection<AccountDetail> AccountDetails { get; set; }
        public virtual ICollection<NomineeDetail> NomineeDetails { get; set; }
    }
}
