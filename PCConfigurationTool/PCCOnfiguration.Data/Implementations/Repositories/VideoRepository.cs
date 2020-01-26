using Microsoft.EntityFrameworkCore;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCConfiguration.Data.Implementations.Repositories
{
    public class VideoCardRepository : IRepository<VideoCard>
    {
        private PcDbContext _context = null;
                
        public VideoCardRepository(PcDbContext _context)
        {
            this._context = _context;
        }
        public void Create(VideoCard obj)
        {
            this._context.VideoCards.Add(obj);
            this._context.SaveChanges();
        }

        public IEnumerable<VideoCard> GetAll()
        {
            return this._context.VideoCards.Include(vc => vc.Interface).ToList();
        }

        public async Task<IEnumerable<VideoCard>> GetAllAsync()
        {
            return await this._context.VideoCards.Include(vc => vc.Interface).ToListAsync();
        }

        public async Task<VideoCard> GetByIdAsync(int id)
        {
            return await this._context.VideoCards.Where(c => c.Id == id).FirstOrDefaultAsync();
        }
    }
}
