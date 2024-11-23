using Product_Control.Models;

namespace Product_Control.Interface
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();

        IQueryable<Product> GetAllQuerableAsync();

        Task<Product> FindAsync(int productID);

        Task<bool> Delete(Product product);

        Task<Product> UpdateAsync(Product product);

        Task<Product> AddAsync(Product product);



    }
}
