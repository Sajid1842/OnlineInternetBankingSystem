using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineInternetBanking.Entities;
using OnlineInternetBanking.Repositories;

namespace OnlineInternetBanking.Repositories
{
    public interface IAdministratorRepository
    {
        List<TransactionDetail> ViewReportsByAccountNo(string AccountNo);
        
        List<CustomerDetail> GetAllCustomerDetails();
        List<NomineeDetail> GetAllNominees();
        List<AccountDetail> GetAllAccountDetails();
        void DeleteCustomerInfo(int CustomerID);
       
        string  CalculateInterest(string AccountNo);
    }
}
