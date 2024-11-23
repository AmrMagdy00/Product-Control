using Microsoft.EntityFrameworkCore;
using Product_Control.Data;
using Product_Control.Dto;
using Product_Control.Interface;
using Product_Control.Mappers;
using Product_Control.Models;
using Product_Control.Repository;

namespace Product_Control.Services
{
    public class ProductsService : IProductService
    {
        private readonly IProductRepository _ProductRepository;

        public ProductsService(IProductRepository ProductRepository)
        {
            this._ProductRepository = ProductRepository;   
        }
        public async Task <List<ProductDto>> GetAllAsync ()
        {

            var Products = await _ProductRepository.GetAllAsync();
            var ProductsDto = Products.Select(s=>s.ToDto()).ToList();   
            return ProductsDto;    

        }

        public IQueryable<Product> GetAllQuerable()
        {
            IQueryable < Product > Query = _ProductRepository.GetAllQuerableAsync();
            return Query;

        }


        public async Task<ProductDto> FindAsync(int ProductID)
        {

            var Product = await _ProductRepository.FindAsync(ProductID);
            var ProductDto= Product.ToDto();
            return ProductDto;

        }



        public async Task<bool> Delete(ProductDto Dto)
        {
            var Product = Dto.ToProuduct();
            bool Deleted = await _ProductRepository.Delete(Product);


            if (Deleted)
            {
                return true;
            }

            return false;

        }

        public async Task <bool> UpdateAsync (ProductDto Dto)
        {
            var Product = Dto.ToProuduct();

            try
            {
                await _ProductRepository.UpdateAsync(Product);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }


            return true;
        }

        public async Task <ProductDto> AddAsync (ProductDto Dto)
        {
            var Product = Dto.ToProuduct();

            await _ProductRepository.AddAsync(Product);
            var ProductDto = Product.ToDto();

            return ProductDto;

        }



    }
}
