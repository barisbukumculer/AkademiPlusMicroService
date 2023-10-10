using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiPlusMicroService.Cargo.BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        Task<T> TGetByIdAsync(int id);
        Task<List<T>> TGetAllAsync();
        Task TCreateAsync(T entity);
        Task TUpdateAsync(T entity);
        Task TDeleteAsync(T entity);
    }
}
