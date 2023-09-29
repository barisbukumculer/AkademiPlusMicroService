using AkademiPlusMicroService.Basket.DTO_s;
using AkademiPlusMicroService.Shared.DTOs;

namespace AkademiPlusMicroService.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string userId); 
        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto); 
        Task<Response<bool>> DeleteBasket(string userId); 
    }
}
