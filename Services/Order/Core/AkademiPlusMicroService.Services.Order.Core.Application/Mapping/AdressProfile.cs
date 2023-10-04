using AkademiPlusMicroService.Services.Order.Core.Application.DTOs.AdressDtos;
using AkademiPlusMicroService.Services.Order.Core.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiPlusMicroService.Services.Order.Core.Application.Mapping
{
    public class AdressProfile:Profile
    {
        public AdressProfile() 
        {
            CreateMap<ResultAdressDto, Adress>().ReverseMap();
            CreateMap<CreateAdressDto, Adress>().ReverseMap();
            CreateMap<UpdateAdressDto, Adress>().ReverseMap();
        }
    }
}
