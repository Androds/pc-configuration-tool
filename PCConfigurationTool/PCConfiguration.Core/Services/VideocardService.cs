using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCConfiguration.Core.Services
{
    public class VideoCardService : IService<IRepository<VideoCard>, VideoCard>
    {
        /// <summary>
        /// Gets or sets the repository used to execute the database operations.
        /// </summary>
        public IRepository<VideoCard> Repository { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoCardService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public VideoCardService(IRepository<VideoCard> repository)
        {
            this.Repository = repository;
        }

        /// <summary>
        /// Creates the specified <see cref="VideoCard"/>.
        /// </summary>
        /// <param name="videoCard">The video card.</param>
        public void Create(VideoCard videoCard)
        {
            if(videoCard != null)
            {
                this.Repository.Create(videoCard);
            }
        }

        /// <summary>
        /// Gets all video cards asynchronously.
        /// </summary>
        /// <returns>Collection of <see cref="VideoCard"/></returns>
        public async Task<IEnumerable<VideoCard>> GetAllAsync()
        {
            if(this.Repository != null)
            {
                return await this.Repository.GetAllAsync();
            }

            return await Task.FromResult<IEnumerable<VideoCard>>(null);
        }

        /// <summary>
        /// Calculates the price of the <see cref="VideoCard"/> by given quantity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns>The price of the <see cref="VideoCard"/></returns>
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

        /// <summary>
        /// Gets the <see cref="VideoCard"/> by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>An instance of the <see cref="VideoCard"/></returns>
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
