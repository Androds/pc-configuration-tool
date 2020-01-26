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

        public async Task<decimal> CalculatePrice(int id, int quantity)
        {
            var entity = await this.GetByIdAsync(id);
            var totalPrice = entity.Price * quantity;
            return totalPrice;
        }

        public async Task<Motherboard> GetByIdAsync(int id)
        {
            return await this.Repository.GetByIdAsync(id);
        }
    }
}
