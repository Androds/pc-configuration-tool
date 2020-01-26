using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PCConfiguration.Core.Services
{
    public class VideoCardService : IService<IRepository<VideoCard>, VideoCard>
    {
        public IRepository<VideoCard> Repository { get; set; }

        public VideoCardService(IRepository<VideoCard> repository)
        {
            this.Repository = repository;
        }
        public void Create(VideoCard obj)
        {
            this.Repository.Create(obj);
        }

        public async Task<IEnumerable<VideoCard>> GetAllAsync()
        {
            return await this.Repository.GetAllAsync();
        }

        public async Task<decimal> CalculatePrice(int id, int quantity)
        {
            var entity = await this.GetByIdAsync(id);
            var totalPrice = entity.Price * quantity;
            return totalPrice;
        }

        public async Task<VideoCard> GetByIdAsync(int id)
        {
            return await this.Repository.GetByIdAsync(id);
        }
    }
}
