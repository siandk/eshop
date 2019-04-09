using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities;
using EshopApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ShopService.Interfaces;

namespace EshopApi.Controllers
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
        [HttpGet]
        public async Task<ActionResult<List<CustomerDto>>> Get()
        {
            List<CustomerDto> customers = await _customerService.GetCustomers().Select(c => new CustomerDto(c)).ToListAsync();
            return Ok(customers);
        }
        [HttpGet("{customerId}")]
        public async Task<ActionResult<CustomerDto>> Get(int customerId, bool includeOrders = false)
        {
            var customerQuery = _customerService.GetCustomerById(customerId);
            if (includeOrders)
            {
                customerQuery.Include(c => c.Orders);
            }
            CustomerDto customer = new CustomerDto(await customerQuery.FirstOrDefaultAsync());
            return customer != null ? Ok(customer) : StatusCode(StatusCodes.Status404NotFound, "Customer not found");
        }
        [HttpGet("search")]
        public async Task<ActionResult<CustomerDto>> Get(string search)
        {
            CustomerDto customer = new CustomerDto(await _customerService.GetCustomers().Where(c => c.Name.Contains(search)).FirstOrDefaultAsync());
            return customer != null ? Ok(customer) : StatusCode(StatusCodes.Status404NotFound, "Customer not found");
        }
        [HttpPost]
        public async Task<ActionResult<CustomerDto>> Post(CustomerDto customer)
        {
            await _customerService.Create(customer.ToCustomer());

            return Created($"/api/customer/{customer.CustomerId}", customer);
        }
        [HttpPut]
        public async Task<ActionResult> Put(CustomerDto customer)
        {
            await _customerService.Update(customer.ToCustomer());
            return Ok();
        }
        [HttpDelete("{customerId}")]
        public async Task<ActionResult> Delete(int customerId)
        {
            Customer customer = await _customerService.GetCustomerById(customerId).FirstOrDefaultAsync();
            if (customer == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Customer not found");
            }
            await _customerService.Delete(customer);
            return Ok();

        }
    }
}