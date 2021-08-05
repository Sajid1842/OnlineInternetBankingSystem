using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineInternetBanking.Entities;
using OnlineInternetBanking.Repositories;

namespace OnlineInternetBanking.Repositories
{
   public interface IAccountDetailsRepository
    {
        void CreateAccount(AccountDetail account);
        string DepositAmount(string AccountNo, double amount);
        string WithdrawAmount(string AccountNo, double amount);
        string TransferAmount(string SourceAccountNo, string DestinationAccountNo, double amount);
        void AddTransaction(TransactionDetail transaction);
        string ChangePassword(string AccountNo, string OldPassword, string NewPassword);
    }
}
