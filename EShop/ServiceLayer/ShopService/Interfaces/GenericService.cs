using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ShopService.Interfaces
{
    public class GenericService
    {
        protected readonly ShopContext _context;

        public GenericService(ShopContext context)
        {
            _context = context;
        }
        public virtual async Task Create<T>(T model) where T : class
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
        }
        public virtual async Task Update<T>(T model) where T : class
        {
            _context.Update(model);
            await _context.SaveChangesAsync();
        }
        public virtual async Task Delete<T>(T model) where T : class
        {
            _context.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
