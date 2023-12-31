﻿using AkademiPlusMicroService.Services.Order.Core.Application.DTOs.AdressDtos;
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
    public class CreateAdressCommandHandler : IRequestHandler<CreateAdressCommandRequest, CreateAdressDto>
    {
        private readonly IRepository<Adress> _repository;
        private readonly IMapper _mapper;

        public CreateAdressCommandHandler(IRepository<Adress> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateAdressDto> Handle(CreateAdressCommandRequest request, CancellationToken cancellationToken)
        {
            var values = new Adress
            {
                City = request.City,
                Detail = request.Detail,
                District = request.District,
                UserId = request.UserId
            };
            var result = await _repository.CreateAsync(values);

            return _mapper.Map<CreateAdressDto>(result);
        }
    }
}
