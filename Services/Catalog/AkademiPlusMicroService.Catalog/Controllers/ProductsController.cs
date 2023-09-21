using AkademiPlusMicroService.Catalog.DTOs.CategoryDTOs;
using AkademiPlusMicroService.Catalog.DTOs.ProductDTOs;
using AkademiPlusMicroService.Catalog.Services.CategoryServices;
using AkademiPlusMicroService.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AkademiPlusMicroService.Catalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductsController(IProductService productService)
		{
			_productService = productService;
		}
		[HttpGet]
		public async Task<IActionResult> GetProductList()
		{
			var values = await _productService.GetAllProducts();
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductDTO createProductDTO)
		{
			await _productService.CreateProduct(createProductDTO);
			return Ok("Ürün Eklendi");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteProduct(string id)
		{
			await _productService.DeleteProduct(id);
			return Ok("Ürün Silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateProduct(UpdateProductDTO updateProductDTO)
		{
			await _productService.UpdateProduct(updateProductDTO);
			return Ok("Güncelleme Yapıldı");
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetProductById(string id)
		{
			var values = await _productService.GetByIdProduct(id);
			return Ok(values);
		}
	}
}
