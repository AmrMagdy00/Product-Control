using Microsoft.Data.SqlClient;
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
            var updateQuery = @"
        UPDATE Products 
        SET Title = @Title, 
            Description = @Description, 
            Price = @Price, 
            ImageUrl = @ImageUrl, 
            Category = @Category
        WHERE Id = @Id";

            var parameters = new[]
            {
        new SqlParameter("@Id", product.Id),
        new SqlParameter("@Title", product.Title),
        new SqlParameter("@Description", product.Description),
        new SqlParameter("@Price", product.Price),
        new SqlParameter("@ImageUrl", product.ImageUrl),
        new SqlParameter("@Category", product.Category)
    };

            await _context.Database.ExecuteSqlRawAsync(updateQuery, parameters);


            return product;
        }


        public async Task<Product> AddAsync(Product product)
        {
            //await _context.Products.AddAsync(product);
            var productQuery = "INSERT INTO Products (Title, Description, Price, ImageUrl, Category) VALUES (@Title, @Description, @Price, @ImageUrl, @Category)";

            var parameters = new[]
            {
        new SqlParameter("@Title", product.Title),
        new SqlParameter("@Description", product.Description),
        new SqlParameter("@Price", product.Price),
        new SqlParameter("@ImageUrl", product.ImageUrl),
        new SqlParameter("@Category", product.Category),
    };

            await _context.Database.ExecuteSqlRawAsync(productQuery, parameters);

            await _context.SaveChangesAsync();

            return product;

        }

    }
}
