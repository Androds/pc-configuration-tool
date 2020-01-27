using Microsoft.EntityFrameworkCore;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCConfiguration.Data.Implementations.Repositories
{
    public class MemoryRepository : IRepository<Memory>
    {
        private PcDbContext _context = null;

        public MemoryRepository(PcDbContext _context)
        {
            this._context = _context;
        }

        public void Create(Memory memory)
        {
            if (this._context != null && memory != null)
            {
                this._context.Memories.Add(memory);
                this._context.SaveChanges();
            }

        }

        public IEnumerable<Memory> GetAll()
        {
            if (this._context != null)
            {
                return this._context.Memories.Include(m => m.Type).Include(m => m.CASLatency).ToList();
            }
            return new List<Memory>();
        }

        public async Task<IEnumerable<Memory>> GetAllAsync()
        {
            if (this._context != null)
            {
                return await this._context.Memories.Include(m => m.Type).Include(m => m.CASLatency).ToListAsync();
            }

            return await Task.FromResult<IEnumerable<Memory>>(null);
        }

        public async Task<Memory> GetByIdAsync(int id)
        {
            if (this._context != null && id > 0)
            {
                return await this._context.Memories.Where(c => c.Id == id).FirstOrDefaultAsync();
            }

            return await Task.FromResult<Memory>(null);
        }
    }
}
