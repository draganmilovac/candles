using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IReadOnlyList<Product>> GetProductAsync();
         Task<Product> GetProductByIdAsync(int id);
         Task<IReadOnlyList<ProductBrand>> GetProductBrands();
         Task<IReadOnlyList<ProductType>> GetProductTypes();
    }
}