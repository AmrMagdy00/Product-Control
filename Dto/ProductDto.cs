using System.ComponentModel.DataAnnotations;

namespace Product_Control.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Title must be less than 50 characters.")]
        public string Title { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Description must be less than 200 characters.")]
        public string Description { get; set; }

        [Required]
        [Range(100, 999999999999, ErrorMessage = "Product price must be at least $100.")]
        public decimal Price { get; set; }

        [Url(ErrorMessage = "Please Enter Correct Url , Or Leave It Blank")]
        public string? ImageUrl { get; set; }

        public string? Category { get; set; } = "Other";

    }
}
