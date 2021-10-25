using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.DTO;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;
        private ResponseDto response;
        public ProductController(IProductRepository repository)
        {
            this._repository = repository;
            this.response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                List<ProductDto> productDtoList = await _repository.GetProducts();
                response.data = productDtoList;
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.errorMessages = new List<string>() { ex.ToString() };
            }
            return response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ResponseDto> Get(int id)
        {
            try
            {
                ProductDto productDto = await _repository.GetProductById(id);
                response.data = productDto;
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.errorMessages = new List<string>() { ex.ToString() };
            }
            return response;
        }

        [HttpPost]
        public async Task<ResponseDto> CreateProduct([FromBody] ProductDto model)
        {
            try
            {
                var result = await _repository.CreateUpdateProduct(model);
                response.data = result;
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.errorMessages = new List<string>() { ex.ToString() };
            }
            return response;
        }

        [HttpPut]
        public async Task<ResponseDto> EditProduct([FromBody] ProductDto model)
        {
            try
            {
                var result = await _repository.CreateUpdateProduct(model);
                response.data = result;
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.errorMessages = new List<string>() { ex.ToString() };
            }
            return response;
        }

        [HttpDelete]
        public async Task<ResponseDto> DeleteProduct(int id)
        {
            try
            {
                var result = await _repository.DeleteProducts(id);
                response.data = result;
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.errorMessages = new List<string>() { ex.ToString() };
            }
            return response;
        }
    }
}
