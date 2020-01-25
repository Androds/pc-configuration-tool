using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PCConfiguration.Core.Services
{
    public class CPUService : IService<IRepository<CPU>, CPU>
    {
        public IRepository<CPU> Repository { get; set; }

        public CPUService(IRepository<CPU> repository)
        {
            this.Repository = repository;
        }
        public void Create(CPU obj)
        {
            this.Repository.Create(obj);
        }

        public async Task<IEnumerable<CPU>> GetAllAsync()
        {
            return await this.Repository.GetAllAsync();
        }
    }
}
