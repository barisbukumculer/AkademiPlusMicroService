﻿using AkademiPlusMicroService.Services.Order.Core.Application.DTOs.OrderingDtos;
using AkademiPlusMicroService.Services.Order.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiPlusMicroService.Services.Order.Core.Application.Features.CQRS.Commands
{
    public class CreateOrderingCommandRequest:IRequest<CreateOrderingDto>
    {
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
