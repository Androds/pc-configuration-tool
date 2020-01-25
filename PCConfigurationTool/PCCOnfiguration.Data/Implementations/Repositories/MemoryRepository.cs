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
    public class MemoryRepository : IRepository<Memory>
    {
        private PcDbContext _context = null;
                
        public MemoryRepository(PcDbContext _context)
        {
            this._context = _context;
        }
        public void Create(Memory obj)
        {
            this._context.Memories.Add(obj);
            this._context.SaveChanges();
        }

        public IEnumerable<Memory> GetAll()
        {
            return this._context.Memories.Include(m => m.Type).Include(m=> m.CASLatency).ToList();
        }

        public async Task<IEnumerable<Memory>> GetAllAsync()
        {
            return await this._context.Memories.Include(m => m.Type).Include(m => m.CASLatency).ToListAsync();
        }
    }
}
