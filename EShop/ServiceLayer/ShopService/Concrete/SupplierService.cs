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
    public class SupplierService : GenericService, ISupplierService
    {
        public SupplierService(ShopContext context) : base(context)
        {
        }

        public async Task<Supplier> GetSupplierById(int? id)
        {
            return await _context.Suppliers.FirstOrDefaultAsync(m => m.SupplierId == id);
        }

        public IQueryable<Supplier> GetSuppliers()
        {
            return _context.Suppliers;
        }

    }
}
