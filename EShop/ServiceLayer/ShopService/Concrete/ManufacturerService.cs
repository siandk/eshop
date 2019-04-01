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
    public class ManufacturerService : GenericService, IManufacturerService
    {

        public ManufacturerService(ShopContext context) : base(context)
        {
        }
        public async Task<Manufacturer> GetManufacturerById(int? id)
        {
            return await _context.Manufacturers.FirstOrDefaultAsync(m => m.ManufacturerId == id);
        }

        public IQueryable<Manufacturer> GetManufacturers()
        {
            return _context.Manufacturers;
        }
    }
}
