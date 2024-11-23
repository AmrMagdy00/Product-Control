using Product_Control.Dto;
using Product_Control.Models;

namespace Product_Control.Mappers
{
    public static class ProductMapper
    {

        public static Product ToProuduct(this ProductDto Dto)
        {
            Product NewProduct = new Product();

            NewProduct.Id = Dto.Id;
            NewProduct.Description = Dto.Description;

            NewProduct.Price = Dto.Price;
            NewProduct.Title = Dto.Title;
            NewProduct.Category = Dto.Category;
            if (Dto.ImageUrl != null)
            {
                NewProduct.ImageUrl = Dto.ImageUrl;

            };

            return NewProduct;


        }

        public static ProductDto ToDto(this Product product)
        {
            return
                new ProductDto
                {
                    Id=product.Id,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    Price = product.Price,
                    Title = product.Title,
                    Category = product.Category,
                };
        }
    }
}
