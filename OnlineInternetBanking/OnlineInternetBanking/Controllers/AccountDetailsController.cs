using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineInternetBanking.Repositories;
using OnlineInternetBanking.Entities;

namespace OnlineInternetBanking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountDetailsController : ControllerBase
    {
        private IAccountDetailsRepository _repository;
        public AccountDetailsController(IAccountDetailsRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("AccountCreation/account")]
        public IActionResult CreateAccount(AccountDetail account)
        {
            try
            {
                _repository.CreateAccount(account);
                return Ok("Account Created!");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("DepositMoney/AccountNo/amount")]
        public IActionResult DepositAmount(string AccountNo, double amount)
        {
            try
            {
                var msg = _repository.DepositAmount(AccountNo, amount);
                return Ok(msg);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("WithdrawMoney/AccountNo/amount")]
        public IActionResult WithdrawAmount(string AccountNo, double amount)
        {
            try
            {
               var msg = _repository.WithdrawAmount(AccountNo,amount);
                return Ok(msg);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("MoneyTransfer/SourceAccountNo/DestinationAccountNo/amount")]
        public IActionResult TransferAmount(string SourceAccountNo, string DestinationAccountNo, double amount)
        {
            try
            {
                if (amount > 0)
                {
                    var msg = _repository.TransferAmount(SourceAccountNo, DestinationAccountNo, amount);
                    return Ok(msg);
                }
                else
                {
                    return BadRequest("No Amount In Your Account!");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("ChangePassword/AccountNo/OldPassword/NewPassword")]
        public IActionResult ChangePassword(string AccountNo, string OldPassword, string NewPassword)
        {
            try
            {
                var password = _repository.ChangePassword(AccountNo, OldPassword, NewPassword);
                return Ok(password);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
