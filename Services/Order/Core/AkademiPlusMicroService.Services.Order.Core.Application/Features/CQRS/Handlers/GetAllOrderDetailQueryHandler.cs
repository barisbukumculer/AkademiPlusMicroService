﻿using AkademiPlusMicroService.Services.Order.Core.Application.DTOs.AdressDtos;
using AkademiPlusMicroService.Services.Order.Core.Application.DTOs.OrderDetailDtos;
using AkademiPlusMicroService.Services.Order.Core.Application.Features.CQRS.Queries;
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
    public class GetAllOrderDetailQueryHandler : IRequestHandler<GetAllOrderDetailQueryRequest, List<ResultOrderDetailDto>>
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly IMapper _mapper;

        public GetAllOrderDetailQueryHandler(IRepository<OrderDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ResultOrderDetailDto>> Handle(GetAllOrderDetailQueryRequest request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<ResultOrderDetailDto>>(values);
        }
    }
}
