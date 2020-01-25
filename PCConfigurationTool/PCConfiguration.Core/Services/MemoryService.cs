using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PCConfiguration.Core.Services
{
    public class MemoryService : IService<IRepository<Memory>, Memory>
    { 
        
        public MemoryService(IRepository<Memory> repository)
        {
        this.Repository = repository;
        }
        public IRepository<Memory> Repository { get; set; }

        public void Create(Memory obj)
        {
            this.Repository.Create(obj);
        }

        public async Task<IEnumerable<Memory>> GetAllAsync()
        {
            return await this.Repository.GetAllAsync();
        }
    }
}
