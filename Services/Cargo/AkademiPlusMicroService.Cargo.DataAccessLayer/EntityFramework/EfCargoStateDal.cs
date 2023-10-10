using AkademiPlusMicroService.Cargo.DataAccessLayer.Abstract;
using AkademiPlusMicroService.Cargo.DataAccessLayer.Context;
using AkademiPlusMicroService.Cargo.DataAccessLayer.Repository;
using AkademiPlusMicroService.Cargo.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiPlusMicroService.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoStateDal : GenericRepository<CargoState>, ICargoStateDal
    {
        private readonly CargoContext _cargoContext;
        public EfCargoStateDal(CargoContext cargoContext) : base(cargoContext)
        {
        }
    }
}
