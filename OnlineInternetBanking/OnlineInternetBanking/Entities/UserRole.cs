using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternetBanking.Entities
{
    public class UserRole
    {
     
            public int RoleId { get; set; }
            public Role RoleType { get; set; }
            public CustomerDetail Customer { get; set; }
        
    }
}

