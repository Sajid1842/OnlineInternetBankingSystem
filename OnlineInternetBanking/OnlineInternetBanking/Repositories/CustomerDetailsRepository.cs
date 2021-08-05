using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineInternetBanking.Entities;
using OnlineInternetBanking.Repositories;

namespace OnlineInternetBanking.Repositories
{
    public class CustomerDetailsRepository : ICustomerDetailsRepository
    {
        private Sprint1Context sprint1Context = null;

        public CustomerDetailsRepository(Sprint1Context sprint1Context)
        {
            this.sprint1Context = sprint1Context;
        }
        public void AddCustomerDetails(CustomerDetail customer)
        {
          /*  UserRole user = new UserRole
            {
                Customer = customer,
                RoleType =sprint1Context.Roles.SingleOrDefault(x => x.RoleName == "customer")

            };
            sprint1Context.UserRoles.Add(user);*/
            sprint1Context.CustomerDetails.Add(customer);
            sprint1Context.SaveChanges();
        }
        public void UpdateCustomerDetails(CustomerDetail customer)
        {
            sprint1Context.CustomerDetails.Update(customer);
            sprint1Context.SaveChanges();
        }

        public void AddNomineeDetails(NomineeDetail nominee)
        {
            sprint1Context.NomineeDetails.Add(nominee);
            sprint1Context.SaveChanges();
        }
        public void UpdateNomineedetails(NomineeDetail nominee)
        {
            sprint1Context.NomineeDetails.Update(nominee);
            sprint1Context.SaveChanges();
        }

        public AccountDetail ViewAccountDetails(string accountNo, int customerID)
        {
            AccountDetail account = sprint1Context.AccountDetails.SingleOrDefault(s => s.AccountNumber == accountNo && s.CustomerId == customerID);
            if (account != null)
            {
                return account;
            }
            else
            {
                return null;
            }
        }
        public CustomerDetail GetCustomerByAadharNumber(decimal aadharNo)
        {
            
                var customer = sprint1Context.CustomerDetails.SingleOrDefault(c => c.AadharNo == aadharNo);
                return customer;
            
        }
       /* public List<string> GetRoles(decimal aadharNo)
        {
            var Id = sprint1Context.CustomerDetails.SingleOrDefault(c => c.AadharNo == aadharNo).CustomerId;
            var result = sprint1Context.UserRoles.Where(x => x.Customer.CustomerId == Id).Select(x => x.RoleType.RoleName).ToList();
            return result;
        }*/
        
    }
}
