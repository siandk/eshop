using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ShopService.Interfaces
{
    public interface IGenericService
    {
        Task Create<T>(T model) where T : class;
        Task Update<T>(T model) where T : class;
        Task Delete<T>(T model) where T : class;
    }
}
