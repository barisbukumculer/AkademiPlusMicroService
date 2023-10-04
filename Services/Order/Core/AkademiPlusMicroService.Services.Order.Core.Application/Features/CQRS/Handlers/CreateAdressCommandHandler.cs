using AkademiPlusMicroService.Services.Order.Core.Application.Features.CQRS.Commands;
using AkademiPlusMicroService.Services.Order.Core.Application.Interfaces;
using AkademiPlusMicroService.Services.Order.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiPlusMicroService.Services.Order.Core.Application.Features.CQRS.Handlers
{
    public class CreateAdressCommandHandler : IRequestHandler<CreateAdressCommandRequest>
    {
        private readonly IRepository<Adress> _repository;

        public CreateAdressCommandHandler(IRepository<Adress> repository)
        {
            _repository = repository;
        }

        public Task Handle(CreateAdressCommandRequest request, CancellationToken cancellationToken)
        {
            var values = new Adress
            {
                City = request.City,
                Detail = request.Detail,
                District = request.District,
                UserId = request.UserId
            };
            return _repository.CreateAsync(values);
        }
    }
}
