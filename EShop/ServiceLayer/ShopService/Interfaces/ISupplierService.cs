﻿using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ShopService.Interfaces
{
    public interface ISupplierService : IGenericService
    {
        IQueryable<Supplier> GetSuppliers();
        Task<Supplier> GetSupplierById(int? id);
    }
}
