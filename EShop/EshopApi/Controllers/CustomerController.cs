using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ShopService.Interfaces;

namespace EshopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> Get()
        {
            List<Customer> customers = await _customerService.GetCustomers().ToListAsync();
            return Ok(customers);
        }
        [HttpGet("{customerId}")]
        public async Task<ActionResult<Customer>> Get(int customerId, bool includeOrders = false)
        {
            var customerQuery = _customerService.GetCustomerById(customerId);
            if (includeOrders)
            {
                customerQuery.Include(c => c.Orders);
            }
            Customer customer = await customerQuery.FirstOrDefaultAsync();
            return customer != null ? Ok(customer) : StatusCode(StatusCodes.Status404NotFound, "Customer not found");
        }
        [HttpGet("search")]
        public async Task<ActionResult<Customer>> Get(string search)
        {
            Customer customer = await _customerService.GetCustomers().Where(c => c.Name.Contains(search)).FirstOrDefaultAsync();
            return customer != null ? Ok(customer) : StatusCode(StatusCodes.Status404NotFound, "Customer not found");
        }
        [HttpPost]
        public async Task<ActionResult<Customer>> Post(Customer customer)
        {
            await _customerService.Create<Customer>(customer);

            return Created($"/api/customer/{customer.CustomerId}", customer);
        }
        [HttpPut]
        public async Task<ActionResult<Customer>> Put(Customer customer)
        {
            await _customerService.Update<Customer>(customer);
            return Ok();
        }
    }
}