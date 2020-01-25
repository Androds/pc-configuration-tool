using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PCConfiguration.Core.Services
{
    public class GenericService<TRepository, TEntity> : IGenericService<TRepository, TEntity>
        where TRepository: class, IGenericRepository<TRepository>
        where TEntity : class
    {
        public GenericService(TRepository repository)
        {
            this.Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public IGenericRepository<TRepository> Repository { get;set; }

        public Task CreateAsync(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
