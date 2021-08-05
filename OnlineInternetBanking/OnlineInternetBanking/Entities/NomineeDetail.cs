using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineInternetBanking.Entities
{
    public partial class NomineeDetail
    {
        public int NomineeId { get; set; }
        public string NomineeName { get; set; }
        public string Relationship { get; set; }
        public int? CustomerId { get; set; }

        public virtual CustomerDetail Customer { get; set; }
    }
}
