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
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;
        public ProductController(IGenericRepository<Product> productRepository,
                                IGenericRepository<ProductBrand> productBrandRepository,
                                IGenericRepository<ProductType> productTypeRepository
        )
        {
            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
        }
        [HttpGet]
        public async Task<IReadOnlyList<Product>> GetAllProduct()
        {
            return await  _productRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Product> GetProduct(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        [HttpGet("brand")]
        public async Task<IReadOnlyList<ProductBrand>> GetAllBrands()
        {
            return await _productBrandRepository.GetAllAsync();
        }

        [HttpGet("types")]
        public async Task<IReadOnlyList<ProductType>> GetAllTypes(){
            return await _productTypeRepository.GetAllAsync();
        }
    }
}