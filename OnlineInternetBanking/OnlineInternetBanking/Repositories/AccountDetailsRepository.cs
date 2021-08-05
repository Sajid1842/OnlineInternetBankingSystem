using OnlineInternetBanking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternetBanking.Repositories
{
    public class AccountDetailsRepository : IAccountDetailsRepository
    {
        private Sprint1Context sprint1Context = null;
        public AccountDetailsRepository(Sprint1Context sprint1Context)
        {
            this.sprint1Context = sprint1Context;
        }
       

        public void CreateAccount(AccountDetail account)
        {
            sprint1Context.AccountDetails.Add(account);
            sprint1Context.SaveChanges();
        }

        public string DepositAmount(string AccountNo, double amount)
        {
            Random rand = new Random();
           
                var account = sprint1Context.AccountDetails.SingleOrDefault(s => s.AccountNumber == AccountNo);
                if (account != null)
                {
                    account.TotalBalance += Convert.ToDecimal(amount);
                    sprint1Context.SaveChanges();
                    TransactionDetail transaction = new TransactionDetail
                    {
                        TransactionDate = DateTime.Now,
                        TransactionAmount = Convert.ToDecimal(amount),
                        TransactionType = "Deposit",
                        AccountNumber = AccountNo,
                        TransactionId = (int)Math.Floor(rand.NextDouble() * 9_000 + 1_000)
                    };
                    AddTransaction(transaction);
                    return "Money Deposited SuccessFully";
                }
                else
                {
                    return "Account Number Doesn't Exist!";
                }
            
        }

       

        public string WithdrawAmount(string AccountNo, double amount)
        {
            Random rand = new Random();
            
                var account = sprint1Context.AccountDetails.SingleOrDefault(a => a.AccountNumber == AccountNo);
                if (account != null)
                {
                    if (Convert.ToDecimal(amount) < account.TotalBalance)
                    {
                        account.TotalBalance -= Convert.ToDecimal(amount);
                        if (account.TotalBalance > account.MinimumBalance)
                        {
                            sprint1Context.SaveChanges();
                            TransactionDetail transaction = new TransactionDetail
                            {
                                AccountNumber = AccountNo,
                                TransactionDate = DateTime.Now,
                                TransactionAmount = Convert.ToDecimal(amount),
                                TransactionType = "Withdraw",
                                TransactionId = (int)Math.Floor(rand.NextDouble() * 9_000 + 1_000)

                            };
                            AddTransaction(transaction);
                            return "Money Withdraw is Successfull!";
                        }
                        else
                        {
                            return "Please Maintain Minimum Balance";
                        }
                    }
                    else
                    {
                        return "Insufficient Amount!";
                    }
                }
                else
                {
                    return "Account Doesn't Exist!";
                }
            
        }

        public void AddTransaction(TransactionDetail transaction)
        {
            sprint1Context.TransactionDetails.Add(transaction);
            sprint1Context.SaveChanges();
        }

        public string TransferAmount(string SourceAcountNo, string DestinationAccountNo, double amount)
        {
            Random rand = new Random();
                var SenderAccountNo = sprint1Context.AccountDetails.SingleOrDefault(a => a.AccountNumber == SourceAcountNo);
                var RecieverAccountNo = sprint1Context.AccountDetails.SingleOrDefault(a => a.AccountNumber == DestinationAccountNo);
                if (SenderAccountNo != null)
                   
                {
                    if (RecieverAccountNo != null)
                    {
                        SenderAccountNo.TotalBalance -= Convert.ToDecimal(amount);
                        RecieverAccountNo.TotalBalance += Convert.ToDecimal(amount);
                        if (SenderAccountNo.TotalBalance > SenderAccountNo.MinimumBalance)
                        {
                            sprint1Context.SaveChanges();
                            TransactionDetail transaction = new TransactionDetail
                            {
                                AccountNumber = SenderAccountNo.AccountNumber,
                                TransactionAmount = Convert.ToDecimal(amount),
                                TransactionDate = DateTime.Now,
                                TransactionType = "Transfer",
                                TransactionId = (int)Math.Floor(rand.NextDouble() * 9_000 + 1_000)

                            };
                            AddTransaction(transaction);
                            return "Transfer Successfull";
                        }
                        else
                        {
                            return "Please Maintain Minimum Balance";
                        }
                    }
                    else
                    {
                        return "Reciever Account Doesn't Exist!";
                    }
                }
                else
                {
                    return "Sender Account Doesn't Exist";
                }
            
           
        }

        public string ChangePassword(string AccountNo, string OldPassword, string NewPassword)
        {
 
            var changepwd = sprint1Context.AccountDetails.SingleOrDefault(i => i.AccountNumber == AccountNo && i.PassWord == OldPassword);
            if(changepwd != null)
            {
                changepwd.PassWord = NewPassword;
                sprint1Context.SaveChanges();
                return "sucesfully changed your password";
            }
            else
            {
                return "Please Check Your Password or AccountNumber!";
            }

        }
    }
}
