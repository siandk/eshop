﻿using DataLayer.Entities;
using ServiceLayer.ShopService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ShopService.Interfaces
{
    public interface ICategoryService : IGenericService
    {
        IQueryable<Category> GetCategoryTree();
        Task<Category> GetCategoryById(int? id);
    }
}
