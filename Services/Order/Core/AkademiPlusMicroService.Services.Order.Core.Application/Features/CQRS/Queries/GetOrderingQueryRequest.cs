using AkademiPlusMicroService.Services.Order.Core.Application.DTOs.OrderingDtos;
using AkademiPlusMicroService.Services.Order.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiPlusMicroService.Services.Order.Core.Application.Features.CQRS.Queries
{
    public class GetOrderingQueryRequest:IRequest<ResultOrderingDto>
    {
        public GetOrderingQueryRequest(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
