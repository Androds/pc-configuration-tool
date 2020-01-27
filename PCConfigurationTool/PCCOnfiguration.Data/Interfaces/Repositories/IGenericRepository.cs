using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PCConfiguration.Data.Interfaces.Repositories
{
    public interface IGenericRepository <TEntity> where TEntity: class
    {
        IEnumerable<TEntity> GetAll();
        void Create(TEntity obj);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<decimal> CalculatePrice(int id, int quantity);
    }
}
