using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using billingSystem.Data;
using billingSystem.Models;
using billingSystem.Services.CustomerService;
using billingSystem.Dtos.CustomersDtos;
using Microsoft.AspNetCore.Authorization;

namespace billingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET All Customers
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
        {
            try
            {
                var customers = await _customerService.GetAllCustomers();
                return Ok(customers);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //Get Customer by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomerById(id);

                if (customer == null)
                {
                    return NotFound();
                }

                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(CreateCustomerDto newCustomer)
        {
            try
            {
                var customer = await _customerService.CreateCustomer(newCustomer);
                return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        //PUT: Update Customer by ID
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, UpdateCustomerDto updatedCustomer)
        {

            try
            {
                var customer = await _customerService.UpdateCustomer(id, updatedCustomer);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: Delete Customer by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                await _customerService.DeleteCustomer(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
