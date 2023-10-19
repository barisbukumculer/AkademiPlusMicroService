using AkademiPlusMicroService.Discount.Context;
using AkademiPlusMicroService.Discount.DTO_s;
using AkademiPlusMicroService.Discount.Models;
using AkademiPlusMicroService.Shared.DTOs;
using AutoMapper;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AkademiPlusMicroService.Discount.Services
{
    public class DiscountCouponService : IDiscountCouponService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IDbConnection _dbConnection;
        private readonly DapperContext _dapperContext;

        public DiscountCouponService(IConfiguration configuration, IMapper mapper, DapperContext dapperContext)
        {
            _configuration = configuration;
            _mapper = mapper;
            _dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            _dapperContext = dapperContext;
        }

        public async Task<Response<NoContent>> CreateDiscountCoupon(CreateDiscountCouponDTO createDiscountCouponDTO)
        {
            var status = await _dbConnection.ExecuteAsync("insert into DiscountCoupons (UserId,Rate,Code,CreatedDate) values (@UserId,@Rate,@Code,@CreatedDate)",createDiscountCouponDTO);
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", createDiscountCouponDTO.UserId);
            parameters.Add("@Rate", createDiscountCouponDTO.Rate);
            parameters.Add("@Code", createDiscountCouponDTO.Code);
            parameters.Add("@CreatedDate", DateTime.Parse(createDiscountCouponDTO.CreatedDate.ToShortDateString()));

            if (status > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("Bir hata oluştu",500);
            }
        }

        public async Task<Response<NoContent>> DeleteDiscountCoupon(int id)
        {
            var status = await _dbConnection.ExecuteAsync("delete from DiscountCoupons where DiscountCouponId=@DiscountCouponId",new{ DiscountCouponId=id});
            if (status > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("Bir hata oluştu", 500);
            }
        }

        public async Task<Response<GetDiscountCouponDto>> GetDiscountById(int id)
        {

            string sql = "select * from DiscountCoupons where DiscountCouponId = @discountCouponid ";
            var parameters = new DynamicParameters();
            parameters.Add("@discountCouponid", id);
            var status = await _dbConnection.QueryFirstOrDefaultAsync<GetDiscountCouponDto>(sql, parameters);
            return Response<GetDiscountCouponDto>.Success(_mapper.Map<GetDiscountCouponDto>(status), 200);
        }

        public async Task<Response<List<ResultDiscountCouponDTO>>> GetListAll()
        {
            var values = await _dbConnection.QueryAsync<ResultDiscountCouponDTO>("Select * from DiscountCoupons");
            return Response<List<ResultDiscountCouponDTO>>.Success(_mapper.Map<List<ResultDiscountCouponDTO>>(values), 200);
    
    }

        public async Task<Response<NoContent>> UpdateDiscountCoupon(UpdateDiscountCouponDTO updateDiscountCouponDTO)
        {
            string sql ="update DiscountCoupons set UserId=@UserId,Rate=@Rate,Code=@Code,CreatedDate=@CreatedDate where DiscountCouponId=@DiscountCouponId";

            var parameters = new DynamicParameters();
            parameters.Add("@DiscountCouponId", updateDiscountCouponDTO.DiscountCouponId);
            parameters.Add("@UserId", updateDiscountCouponDTO.UserId);
            parameters.Add("@Rate", updateDiscountCouponDTO.Rate);
            parameters.Add("@Code", updateDiscountCouponDTO.Code);
            parameters.Add("@CreatedDate", DateTime.Parse(updateDiscountCouponDTO.CreatedDate.ToShortDateString()));

           await _dbConnection.ExecuteAsync(sql, parameters);

            return Response<NoContent>.Success(200);
        }
    }
}
