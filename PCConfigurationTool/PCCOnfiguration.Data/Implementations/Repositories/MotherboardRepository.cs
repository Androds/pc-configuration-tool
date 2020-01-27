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

        /// <summary>
        /// Initializes a new instance of the <see cref="MotherboardRepository"/> class.
        /// </summary>
        /// <param name="_context">The context.</param>
        public MotherboardRepository(PcDbContext _context)
        {
            this._context = _context;
        }

        /// <inheritdoc/>
        public void Create(Motherboard motheboard)
        {
            if(motheboard != null && this._context != null)
            {
                this._context.Motherboards.Add(motheboard);
                this._context.SaveChanges();
            }
        }

        /// <inheritdoc/>
        public IEnumerable<Motherboard> GetAll()
        {
            if(this._context != null)
            {
                return this._context.Motherboards.Include(m => m.FormFactor).Include(m => m.SocketType).ToList();
            }

            return new List<Motherboard>();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Motherboard>> GetAllAsync()
        {
            if (this._context != null)
            {
                return await this._context.Motherboards.Include(m => m.FormFactor).Include(m => m.SocketType).ToListAsync();
            }

            return await Task.FromResult<IEnumerable<Motherboard>>(null);
        }

        /// <inheritdoc/>
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
