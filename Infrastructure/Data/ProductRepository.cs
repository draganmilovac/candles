using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<Product>> GetProductAsync()
        {
           return await _context.Products
           .Include(x => x.ProductBrand)
           .Include(m=>m.ProductType)
           .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
            .Include(x => x.ProductBrand)
            .Include(m=>m.ProductType)
            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrands()
        {
            return await _context.ProductBrands.ToListAsync();
        }
        public async Task<IReadOnlyList<ProductType>> GetProductTypes()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}