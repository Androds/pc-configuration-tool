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
        public void Create(Storage storage)
        {
            if(storage != null)
            {
                this.Repository.Create(storage);
            }
        }

        public async Task<IEnumerable<Storage>> GetAllAsync()
        {
            if(this.Repository != null)
            {
                return await this.Repository.GetAllAsync();
            }

            return await Task.FromResult<IEnumerable<Storage>>(null);
        }

        public async Task<decimal> CalculatePrice(int id, int quantity)
        {
            if(id > 0 && quantity > 0)
            {
                var entity = await this.GetByIdAsync(id);
                var totalPrice = entity.Price * quantity;
                return totalPrice;
            }

            return await Task.FromResult<decimal>(0);
        }

        public async Task<Storage> GetByIdAsync(int id)
        {
            if(id > 0 && this.Repository != null)
            {
                return await this.Repository.GetByIdAsync(id);
            }

            return await Task.FromResult<Storage>(null);
        }
    }
}
