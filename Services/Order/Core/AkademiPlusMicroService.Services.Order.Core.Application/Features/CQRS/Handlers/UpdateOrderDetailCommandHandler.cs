using AkademiPlusMicroService.Services.Order.Core.Application.DTOs.AdressDtos;
using AkademiPlusMicroService.Services.Order.Core.Application.DTOs.OrderDetailDtos;
using AkademiPlusMicroService.Services.Order.Core.Application.DTOs.OrderingDtos;
using AkademiPlusMicroService.Services.Order.Core.Application.Features.CQRS.Commands;
using AkademiPlusMicroService.Services.Order.Core.Application.Interfaces;
using AkademiPlusMicroService.Services.Order.Core.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiPlusMicroService.Services.Order.Core.Application.Features.CQRS.Handlers
{
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommandRequest, UpdateOrderDetailDto>
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly IMapper _mapper;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateOrderDetailDto> Handle(UpdateOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            var value = new OrderDetail
            {
               ProductAmount = request.ProductAmount,
               OrderDetailId = request.OrderDetailId,
               ProductId = request.ProductId,
               ProductName = request.ProductName,
               ProductPrice = request.ProductPrice,
               OrderingId = request.OrderingId
            };
            await _repository.UpdateAsync(value);
            return _mapper.Map<UpdateOrderDetailDto>(value);
        }
    }
}
