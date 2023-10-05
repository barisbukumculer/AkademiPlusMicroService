using AkademiPlusMicroService.Services.Order.Core.Application.DTOs.AdressDtos;
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
    public class GetAdressQueryHandler : IRequestHandler<GetAdressQueryRequest, ResultAdressDto>
    {
        private readonly IRepository<Adress> _repository;
        private readonly IMapper _mapper;

        public GetAdressQueryHandler(IRepository<Adress> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResultAdressDto> Handle(GetAdressQueryRequest request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<ResultAdressDto>(value);
        }
    }
}
