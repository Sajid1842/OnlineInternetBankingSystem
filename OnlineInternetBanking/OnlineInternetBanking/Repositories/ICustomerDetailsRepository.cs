using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineInternetBanking.Entities;

namespace OnlineInternetBanking.Repositories
{
    public interface ICustomerDetailsRepository
    {
        void AddCustomerDetails(CustomerDetail customer);



        void UpdateCustomerDetails(CustomerDetail customer);



        void AddNomineeDetails(NomineeDetail nominee);



        void UpdateNomineedetails(NomineeDetail nominee);



        AccountDetail ViewAccountDetails(string accountNo, int customerID);



        CustomerDetail GetCustomerByAadharNumber(decimal AadharNo);



        /*List<string> GetRoles(decimal AadharNo);*/
    }
}
