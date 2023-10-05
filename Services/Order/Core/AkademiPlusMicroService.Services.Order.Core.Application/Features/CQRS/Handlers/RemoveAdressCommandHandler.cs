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
    public class RemoveAdressCommandHandler : IRequestHandler<RemoveAdressCommandRequest>
    {
        private readonly IRepository<Adress> _repository;

        public RemoveAdressCommandHandler(IRepository<Adress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAdressCommandRequest request, CancellationToken cancellationToken)
        {
         var value=  await _repository.GetByIdAsync(request.Id);
            _repository.DeleteAsync(value);
        }
    }
}
