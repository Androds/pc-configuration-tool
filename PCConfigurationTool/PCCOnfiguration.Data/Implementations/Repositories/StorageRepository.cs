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
    public class StorageRepository : IRepository<Storage>
    {
        private PcDbContext _context = null;
                
        public StorageRepository(PcDbContext _context)
        {
            this._context = _context;
        }
        public void Create(Storage obj)
        {
            this._context.Storages.Add(obj);
            this._context.SaveChanges();
        }

        public IEnumerable<Storage> GetAll()
        {
            return this._context.Storages.Include(s => s.FormFactor).Include(s=> s.Type).Include(s => s.Interface).ToList();
        }

        public async Task<IEnumerable<Storage>> GetAllAsync()
        {
            return await this._context.Storages.Include(s => s.FormFactor).Include(s => s.Type).Include(s => s.Interface).ToListAsync();
        }

        public async Task<Storage> GetByIdAsync(int id)
        {
            return await this._context.Storages.Where(c => c.Id == id).FirstOrDefaultAsync();
        }
    }
}
