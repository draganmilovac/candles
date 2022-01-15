using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IReadOnlyList<Product>> GetAllProduct()
        {
            return await  _repository.GetProductAsync();
        }

        [HttpGet("{id}")]
        public async Task<Product> GetProduct(int id)
        {
            return await _repository.GetProductByIdAsync(id);
        }

        [HttpGet("brand")]
        public async Task<IReadOnlyList<ProductBrand>> GetAllBrands()
        {
            return await _repository.GetProductBrands();
        }

        [HttpGet("types")]
        public async Task<IReadOnlyList<ProductType>> GetAllTypes(){
            return await _repository.GetProductTypes();
        }
    }
}