﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiPlusMicroService.Services.Order.Core.Application.DTOs.OrderDetailDtos
{
    public class ResultOrderDetailDto
    {
        public int OrderDetailId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public int OrderingId { get; set; }
    }
}
