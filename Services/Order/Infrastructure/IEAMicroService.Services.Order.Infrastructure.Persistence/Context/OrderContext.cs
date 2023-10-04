﻿using AkademiPlusMicroService.Services.Order.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IEAMicroService.Services.Order.Infrastructure.Persistence.Context
{
    public class OrderContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost,1433;database=AkademiPlusOrderDb;user=sa;password=123456aA*;");
        }
        public DbSet<Ordering> Orderings { get; set; }
        public DbSet<Adress> Addresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
