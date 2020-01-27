using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCConfiguration.Data.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity: class
    {
        IEnumerable<TEntity> GetAll();
        void Create(TEntity obj);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
    }
}
