using PCConfiguration.Data.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCConfiguration.Core.Interfaces
{
    public interface IService<TRepository, TEntity> where TRepository: IRepository<TEntity>
        where TEntity: class
    {
        Task<decimal> CalculatePrice(int id, int quantity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int Id);
        void Create(TEntity obj);

        /// <summary>
        /// Gets or sets the repository used to execute the database operations.
        /// </summary>
        TRepository Repository { get; set; }
    }
}
