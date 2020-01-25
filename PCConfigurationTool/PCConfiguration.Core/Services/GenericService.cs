using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PCConfiguration.Core.Services
{
    public class GenericService<TRepository, TEntity> : IGenericService<TRepository, TEntity>
        where TRepository: IGenericRepository<TEntity>
        where TEntity : class
    {
        public GenericService(TRepository repository)
        {
            this.Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public TRepository Repository { get;set; }

        public void Create(TEntity obj)
        {
           this.Repository.Create(obj);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this.Repository.GetAllAsync();
        }
    }
}
