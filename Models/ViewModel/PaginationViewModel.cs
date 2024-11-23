using Product_Control.Dto;

namespace Product_Control.Models.ViewModel
{
    public class PaginationViewModel
    {
        public IEnumerable<ProductDto> Products { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        string selectedCategory { get; set; }
    }
}
