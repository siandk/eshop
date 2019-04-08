using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ShopService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ShopService.Concrete
{
    public class CustomerService : GenericService, ICustomerService
    {
        public CustomerService(ShopContext _context) : base(_context) { }
        public IQueryable<Customer> GetByGuid(string guid)
        {
            return _context.Customers.Where(c => c.UserGuid == guid);
        }
        public IQueryable<Customer> GetCustomers()
        {
            return _context.Customers.Include(c => c.ContactInfo);
        }
        public IQueryable<Customer> GetCustomerById(int customerId)
        {
            return _context.Customers.Include(c => c.ContactInfo).Where(c => c.CustomerId == customerId);
        }
    }
}
