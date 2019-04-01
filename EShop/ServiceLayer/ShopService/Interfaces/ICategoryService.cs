using DataLayer.Entities;
using ServiceLayer.ShopService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ShopService.Interfaces
{
    public interface ICategoryService
    {
        IQueryable<Category> GetCategoryTree();
        Task<Category> GetCategoryById(int? id);
        Task Create<T>(T model) where T : class;
        Task Update<T>(T model) where T : class;
        Task Delete<T>(T model) where T : class;
    }
}
