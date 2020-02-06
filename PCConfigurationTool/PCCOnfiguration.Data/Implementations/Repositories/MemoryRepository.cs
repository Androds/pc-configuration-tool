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

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryRepository"/> class.
        /// </summary>
        /// <param name="_context">The context.</param>
        public MemoryRepository(PcDbContext _context)
        {
            this._context = _context;
        }

        /// <inheritdoc/>
        public void Create(Memory memory)
        {
            if (this._context != null && memory != null)
            {
                this._context.Memories.Add(memory);
                this._context.SaveChanges();
            }

        }

        /// <inheritdoc/>
        public IEnumerable<Memory> GetAll()
        {
            if (this._context != null)
            {
                return this._context.Memories.Include(m => m.Type).Include(m => m.CASLatency).AsNoTracking().ToList();
            }
            return new List<Memory>();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Memory>> GetAllAsync()
        {
            if (this._context != null)
            {
                return await this._context.Memories.Include(m => m.Type).Include(m => m.CASLatency).AsNoTracking().ToListAsync();
            }

            return await Task.FromResult<IEnumerable<Memory>>(null);
        }

        /// <inheritdoc/>
        public async Task<Memory> GetByIdAsync(int id)
        {
            if (this._context != null && id > 0)
            {
                return await this._context.Memories.Where(c => c.Id == id).AsNoTracking().FirstOrDefaultAsync();
            }

            return await Task.FromResult<Memory>(null);
        }
    }
}
