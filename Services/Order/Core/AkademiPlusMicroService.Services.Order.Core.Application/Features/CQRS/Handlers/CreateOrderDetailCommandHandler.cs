using AkademiPlusMicroService.Services.Order.Core.Application.DTOs.AdressDtos;
using AkademiPlusMicroService.Services.Order.Core.Application.DTOs.OrderDetailDtos;
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
    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommandRequest, CreateOrderDetailDto>
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly IMapper _mapper;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateOrderDetailDto> Handle(CreateOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            var values = new OrderDetail
            {
                ProductAmount = request.ProductAmount,
                ProductName = request.ProductName,
                ProductPrice = request.ProductPrice,
                ProductId = request.ProductId,
                OrderingId = request.OrderingId

            };
            var result = await _repository.CreateAsync(values);

            return _mapper.Map<CreateOrderDetailDto>(result);
        }
    }
}
