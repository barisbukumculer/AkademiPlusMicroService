using AkademiPlusMicroService.Services.Order.Core.Application.DTOs.AdressDtos;
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
    public class UpdateAdressCommandHandler:IRequestHandler<UpdateAdressCommandRequest,UpdateAdressDto>
    {
        private readonly IRepository<Adress> _repository;
        private readonly IMapper _mapper;

        public UpdateAdressCommandHandler(IRepository<Adress> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateAdressDto> Handle(UpdateAdressCommandRequest request, CancellationToken cancellationToken)
        {
            var value = new Adress
            {
                AdressId = request.AdressId,
                City = request.City,
                Detail = request.Detail,
                District = request.District,
                UserId = request.UserId,
            };
            await _repository.UpdateAsync(value);
            return _mapper.Map<UpdateAdressDto>(value);
        }
    }
}
