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
    public class MotherboardRepository : IRepository<Motherboard>
    {
        private PcDbContext _context = null;
                
        public MotherboardRepository(PcDbContext _context)
        {
            this._context = _context;
        }
        public void Create(Motherboard obj)
        {
            this._context.Motherboards.Add(obj);
            this._context.SaveChanges();
        }

        public IEnumerable<Motherboard> GetAll()
        {
            return this._context.Motherboards.Include(m => m.FormFactor).Include(m=> m.SocketType).ToList();
        }

        public async Task<IEnumerable<Motherboard>> GetAllAsync()
        {
            return await this._context.Motherboards.Include(m => m.FormFactor).Include(m => m.SocketType).ToListAsync();
        }

        public async Task<Motherboard> GetByIdAsync(int id)
        {
            return await this._context.Motherboards.Where(c => c.Id == id).FirstOrDefaultAsync();
        }
    }
}
