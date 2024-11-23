using Microsoft.EntityFrameworkCore;
using Product_Control.Data;
using Product_Control.Interface;
using Product_Control.Models;

namespace Product_Control.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext Context)
        {
            this._context = Context;

        }


        public async Task<List<Product>> GetAllAsync()
        {

            var Products = await _context.Products.ToListAsync();
            return Products;

        }

        public IQueryable<Product> GetAllQuerableAsync()
        {
            IQueryable<Product> Query = _context.Products.AsQueryable();
            return Query;

        }


        public async Task<Product> FindAsync(int productID)
        {

            var Product = await _context.Products.FindAsync(productID);
            return Product;

        }


        public async Task<bool> Delete(Product product)
        {
            if (product == null)
            {
                return false;
            }
            var Product = _context.Products.Remove(product);
            await _context.SaveChangesAsync();


            return true;
        }

        public async Task<Product> UpdateAsync(Product product)
        {

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;

        }

    }
}
