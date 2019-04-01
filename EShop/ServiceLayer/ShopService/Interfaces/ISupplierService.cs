using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ShopService.Interfaces
{
    public interface ISupplierService
    {
        IQueryable<Supplier> GetSuppliers();
        Task<Supplier> GetSupplierById(int? id);
        Task Create<T>(T model) where T : class;
        Task Update<T>(T model) where T : class;
        Task Delete<T>(T model) where T : class;
    }
}
