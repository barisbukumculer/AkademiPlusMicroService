using AkademiPlusMicroService.Cargo.BusinessLayer.Abstract;
using AkademiPlusMicroService.Cargo.DataAccessLayer.Abstract;
using AkademiPlusMicroService.Cargo.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiPlusMicroService.Cargo.BusinessLayer.Concrete
{
    public class CargoStateManager : ICargoStateService
    {
        private readonly ICargoStateDal _cargoStateDal;

        public CargoStateManager(ICargoStateDal cargoStateDal)
        {
            _cargoStateDal = cargoStateDal;
        }

        public async Task TCreateAsync(CargoState entity)
        {
           await _cargoStateDal.CreateAsync(entity);
        }

        public async Task TDeleteAsync(CargoState entity)
        {
            await _cargoStateDal.DeleteAsync(entity);
        }

        public async Task<List<CargoState>> TGetAllAsync()
        {
         return   await _cargoStateDal.GetAllAsync();
        }

        public Task<CargoState> TGetByIdAsync(int id)
        {
          return _cargoStateDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(CargoState entity)
        {
            await _cargoStateDal.UpdateAsync(entity);
        }
    }
}
