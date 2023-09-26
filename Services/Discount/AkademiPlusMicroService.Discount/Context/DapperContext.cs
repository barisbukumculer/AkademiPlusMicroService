﻿using AkademiPlusMicroService.Discount.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AkademiPlusMicroService.Discount.Context
{
    public class DapperContext:DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=AkademiPlusDiscountDb;user=sa;password=123456aA*");
        }
        public DbSet<DiscountCoupon> DiscountCoupons { get; set; }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
    
}
