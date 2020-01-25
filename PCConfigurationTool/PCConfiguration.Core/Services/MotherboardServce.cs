using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PCConfiguration.Core.Services
{
    public class MotherboardService : IService<IRepository<Motherboard>, Motherboard>
    {
        public IRepository<Motherboard> Repository { get; set; }

        public MotherboardService(IRepository<Motherboard> repository)
        {
            this.Repository = repository;
        }
        public void Create(Motherboard obj)
        {
            this.Repository.Create(obj);
        }

        public async Task<IEnumerable<Motherboard>> GetAllAsync()
        {
            return await this.Repository.GetAllAsync();
        }
    }
}
