using Microsoft.EntityFrameworkCore;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCConfiguration.Data.Implementations.Repositories
{
    public class VideoCardRepository : IRepository<VideoCard>
    {
        private PcDbContext _context = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoCardRepository"/> class.
        /// </summary>
        /// <param name="_context">The context.</param>
        public VideoCardRepository(PcDbContext _context)
        {
            this._context = _context;
        }
        public void Create(VideoCard videoCard)
        {
            if(videoCard != null && this._context != null)
            {
                this._context.VideoCards.Add(videoCard);
                this._context.SaveChanges();
            }
        }

        /// <inheritdoc/>
        public IEnumerable<VideoCard> GetAll()
        {
            if(this._context != null)
            {
                return this._context.VideoCards.Include(vc => vc.Interface).ToList();
            }

            return new List<VideoCard>();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<VideoCard>> GetAllAsync()
        {
            if(this._context != null)
            {
                return await this._context.VideoCards.Include(vc => vc.Interface).ToListAsync();
            }

            return await Task.FromResult<IEnumerable<VideoCard>>(null);
        }

        /// <inheritdoc/>
        public async Task<VideoCard> GetByIdAsync(int id)
        {
            if(id > 0 && this._context != null)
            {
                return await this._context.VideoCards.Where(c => c.Id == id).FirstOrDefaultAsync();
            }

            return await Task.FromResult<VideoCard>(null);
        }
    }
}
