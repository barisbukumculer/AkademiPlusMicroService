
namespace AkademiPlusMicroService.WebUI.DTOs.ProductDTOs
{
    public class UpdateProductDTO
    {
        public string ProductId { get; set; }
        public string ProducctName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Desciption { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryId { get; set; }
    }
}
