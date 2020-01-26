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
        public void Create(VideoCard videoCard)
        {
            if(videoCard != null)
            {
                this.Repository.Create(videoCard);
            }
        }

        public async Task<IEnumerable<VideoCard>> GetAllAsync()
        {
            if(this.Repository != null)
            {
                return await this.Repository.GetAllAsync();
            }

            return await Task.FromResult<IEnumerable<VideoCard>>(null);
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

        public async Task<VideoCard> GetByIdAsync(int id)
        {
            if(id > 0 && this.Repository != null)
            {
                return await this.Repository.GetByIdAsync(id);
            }

            return await Task.FromResult<VideoCard>(null);
        }
    }
}
