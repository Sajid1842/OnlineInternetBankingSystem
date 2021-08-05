using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineInternetBanking.Entities;
using OnlineInternetBanking.Repositories;
using Microsoft.EntityFrameworkCore;

namespace OnlineInternetBanking.Repositories
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private Sprint1Context sprint1Context = null;
        public AdministratorRepository(Sprint1Context sprint1Context)
        {
            this.sprint1Context = sprint1Context;
        }

        public string CalculateInterest(string AccountNo)
        {
            var account = sprint1Context.AccountDetails.SingleOrDefault(s => s.AccountNumber == AccountNo);
            int interest = 0;
            int r = 5;
            account.InterestAmount = interest + Convert.ToDecimal(Convert.ToDouble((account.TotalBalance * r * 1) / (12 * 100)));
            sprint1Context.SaveChanges();
            return "Interest Calculated.";
        }

       
        public List<TransactionDetail> ViewReportsByAccountNo(string AccountNo)
        {
            try
            {
                List<TransactionDetail> reportByAccountNo = sprint1Context.TransactionDetails.Where(a => a.AccountNumber == AccountNo).ToList();
                return reportByAccountNo;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public void DeleteCustomerInfo(int CustomerID)
        {
            CustomerDetail customer = sprint1Context.CustomerDetails.SingleOrDefault(c => c.CustomerId == CustomerID);
            sprint1Context.CustomerDetails.Remove(customer);
            sprint1Context.SaveChanges();
        }
       
        public List<CustomerDetail> GetAllCustomerDetails()
        {
            return sprint1Context.CustomerDetails.ToList();
        }

        public List<NomineeDetail> GetAllNominees()
        {
            return sprint1Context.NomineeDetails.ToList();
        }

        public List<AccountDetail> GetAllAccountDetails()
        {
            return sprint1Context.AccountDetails.ToList();
        }



    }
}
