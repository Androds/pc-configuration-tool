using Microsoft.EntityFrameworkCore;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System.Collections.Generic;
using System.Linq;
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
        public void Create(Motherboard motheboard)
        {
            if(motheboard != null && this._context != null)
            {
                this._context.Motherboards.Add(motheboard);
                this._context.SaveChanges();
            }
        }

        public IEnumerable<Motherboard> GetAll()
        {
            if(this._context != null)
            {
                return this._context.Motherboards.Include(m => m.FormFactor).Include(m => m.SocketType).ToList();
            }

            return new List<Motherboard>();
        }

        public async Task<IEnumerable<Motherboard>> GetAllAsync()
        {
            if (this._context != null)
            {
                return await this._context.Motherboards.Include(m => m.FormFactor).Include(m => m.SocketType).ToListAsync();
            }

            return await Task.FromResult<IEnumerable<Motherboard>>(null);
        }

        public async Task<Motherboard> GetByIdAsync(int id)
        {
            if (this._context != null && id > 0)
            {
                return await this._context.Motherboards.Where(c => c.Id == id).FirstOrDefaultAsync();
            }

            return await Task.FromResult<Motherboard>(null);
        }
    }
}
