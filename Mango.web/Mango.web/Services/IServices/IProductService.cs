using Mango.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.web.Services.IServices
{
    interface IProductService
    {
        Task<T> GetProductsAsync<T>();
        Task<T> GetProductsAsync<T>(int id);
        Task<T> CreateProductAsync<T>(ProductDto model);
        Task<T> UpdateProductAsync<T>(ProductDto model);
        Task<T> DeleteProductAsync<T>(int id);
    }
}
