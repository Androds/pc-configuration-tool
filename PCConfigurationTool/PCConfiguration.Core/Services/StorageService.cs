using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PCConfiguration.Core.Services
{
    public class StorageService : IService<IRepository<Storage>, Storage>
    {
        public IRepository<Storage> Repository { get; set; }

        public StorageService(IRepository<Storage> repository)
        {
            this.Repository = repository;
        }
        public void Create(Storage obj)
        {
            this.Repository.Create(obj);
        }

        public async Task<IEnumerable<Storage>> GetAllAsync()
        {
            return await this.Repository.GetAllAsync();
        }
    }
}
