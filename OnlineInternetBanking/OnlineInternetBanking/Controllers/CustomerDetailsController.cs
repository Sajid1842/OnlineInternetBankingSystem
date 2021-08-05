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
    public class CustomerDetailsController : ControllerBase
    {
        private ICustomerDetailsRepository _repository;
        public CustomerDetailsController(ICustomerDetailsRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("AddCustomerDetails/customer")]
        public IActionResult AddCustomerDetails(CustomerDetail customer)
        {
            try
            {
                _repository.AddCustomerDetails(customer);
                return Ok("Customer Added Successfully");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("Add Nominee Details/nominee")]
        public IActionResult AddNomineeDetails(NomineeDetail nominee)
        {
            try
            {
                _repository.AddNomineeDetails(nominee);
                return Ok("Nominee Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet]
        [Route("ViewCustomertDetails/aadharNo")]
        public IActionResult GetCustomerByAadharNumber(decimal aadharNo)
        {
            CustomerDetail customer = _repository.GetCustomerByAadharNumber(aadharNo);
            if (customer != null)
            {
                return Ok(customer);
            }
            else
            {
                return NotFound("Details Not Found.\n Enter Aadhar Number Correctly");
            }
        }
        [HttpPut]
        [Route("UpdateCustomerDetails/customer")]
        public IActionResult UpdateCustomerDetails(CustomerDetail customer)
        {
            try
            {
                _repository.UpdateCustomerDetails(customer);
                return Ok("Your Details Updated Successfully");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("Update Nominee Deatils/nominee")]
        public IActionResult UpdateNomineedetails(NomineeDetail nominee)
        {
            try
            {
                _repository.UpdateNomineedetails(nominee);
                return Ok("Nominee Details Updated");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("ViewAccountDetails/accountNo/customerID")]
        public IActionResult ViewAccountDetails(string accountNo, int customerID)
        {
            AccountDetail account = _repository.ViewAccountDetails(accountNo, customerID);
            if (account != null)
            {
                return Ok(account);
            }
            else
            {
                return NotFound("Details Not Found");
            }
        }

    }
}
