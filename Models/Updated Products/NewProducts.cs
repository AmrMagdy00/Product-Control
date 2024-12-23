namespace Product_Control.Models
{
    public class NewProducts
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; } = "https://img.freepik.com/free-vector/warehouse-staff-wearing-uniform-loading-parcel-box-checking-product-from-warehouse-delivery-logistic-storage-truck-transportation-industry-delivery-logistic-business-delivery_1150-60909.jpg?t=st=1732200457~exp=1732204057~hmac=3ed132c21bbf6a955d71ba836aafbbf40aa6e6bd395dc996f392405d365f2f35&w=1800";

        public string? Category { get; set; } = "Other";

        public bool IsNotified { get; set; } = false;
    }
}
