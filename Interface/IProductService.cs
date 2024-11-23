using Product_Control.Dto;
using Product_Control.Models;

namespace Product_Control.Interface
{
    public interface IProductService
    {
          
        Task<List<ProductDto>> GetAllAsync();

        IQueryable<Product> GetAllQuerable();

        Task<ProductDto> FindAsync(int productID);

        Task<bool> Delete(ProductDto product);

        Task<bool> UpdateAsync(ProductDto product);

        Task<ProductDto> AddAsync(ProductDto product);
    }
}
