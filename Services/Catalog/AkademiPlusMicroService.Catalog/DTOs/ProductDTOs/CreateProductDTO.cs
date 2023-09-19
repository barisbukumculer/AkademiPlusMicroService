using AkademiPlusMicroService.Catalog.Models;

namespace AkademiPlusMicroService.Catalog.DTOs.ProductDTOs
{
    public class CreateProductDTO
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Desciption { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryId { get; set; }
    }
}
