using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiPlusMicroService.Services.Order.Core.Application.Features.CQRS.Commands
{
    public class RemoveAdressCommandRequest:IRequest
    {
        public RemoveAdressCommandRequest(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
