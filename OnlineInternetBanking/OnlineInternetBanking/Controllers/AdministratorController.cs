using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineInternetBanking.Entities;
using OnlineInternetBanking.Repositories;

namespace OnlineInternetBanking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private IAdministratorRepository _repository;
        public AdministratorController(IAdministratorRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        [Route("InterestCalculation/AccountNo")]
        public IActionResult CalculateInterest(string AccountNo)
        {
            try
            {
                string interest_msg = _repository.CalculateInterest(AccountNo);
                return Ok(interest_msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("ViewReportsByAccountNo/AccountNo")]
        public IActionResult ViewReportsByAccountNo(string AccountNo)
        {
            List<TransactionDetail> account = _repository.ViewReportsByAccountNo(AccountNo);
            if(account.Count > 0)
            {
                return Ok(account);
            }
            else
            {
                return NotFound("Please Check Your Account Number");
            }
        }
        [HttpGet]
        [Route("CustomerDeatils")]
        public IActionResult GetAllCustomerDetails()
        {
            return Ok(_repository.GetAllCustomerDetails());
        }
        [HttpGet]
        [Route("NomineeDetails")]
        public IActionResult GetAllNominees()
        {
            return Ok(_repository.GetAllNominees());
        }
        [HttpGet]
        [Route("AccountDetails")]
        public IActionResult GetAllAccountDetails()
        {
            return Ok(_repository.GetAllAccountDetails());
        }
        [HttpDelete]
        [Route("DeleteCustomer/CustomerID")]
        public IActionResult DeleteCustomerInfo(int CustomerID)
        {
            try
            {
                _repository.DeleteCustomerInfo(CustomerID);
                return Ok("Customer Deleted Successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
