using AkademiPlusMicroService.Services.Order.Core.Application.DTOs.AdressDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiPlusMicroService.Services.Order.Core.Application.Features.CQRS.Commands
{
    public class UpdateAdressCommandRequest:IRequest<UpdateAdressDto>
    {
        public int AdressId { get; set; }
        public string UserId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}
