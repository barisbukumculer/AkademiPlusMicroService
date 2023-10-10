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
    public class EfCargoDetailDal : GenericRepository<CargoDetail>, ICargoDetailDal
    {
        private readonly CargoContext _cargoContext;
        public EfCargoDetailDal(CargoContext cargoContext) : base(cargoContext)
        {
            _cargoContext = cargoContext;
        }

        public int TotalCargoCount()
        {
           return _cargoContext.CargoDetails.Count();
        }
    }
}
