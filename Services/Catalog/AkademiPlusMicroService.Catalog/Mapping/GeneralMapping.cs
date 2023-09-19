using AkademiPlusMicroService.Catalog.DTOs.CategoryDTOs;
using AkademiPlusMicroService.Catalog.DTOs.ProductDTOs;
using AkademiPlusMicroService.Catalog.Models;
using AutoMapper;

namespace AkademiPlusMicroService.Catalog.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, ResultCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();

            CreateMap<Product, ResultProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
        }
    }
}
