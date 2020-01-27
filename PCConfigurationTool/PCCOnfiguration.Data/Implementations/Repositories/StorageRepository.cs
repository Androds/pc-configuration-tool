using Microsoft.EntityFrameworkCore;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCConfiguration.Data.Implementations.Repositories
{
    public class StorageRepository : IRepository<Storage>
    {
        private PcDbContext _context = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageRepository"/> class.
        /// </summary>
        /// <param name="_context">The context.</param>
        public StorageRepository(PcDbContext _context)
        {
            this._context = _context;
        }

        /// <inheritdoc/>
        public void Create(Storage storage)
        {
            if (storage != null && this._context != null)
            {
                this._context.Storages.Add(storage);
                this._context.SaveChanges();
            }
        }

        /// <inheritdoc/>
        public IEnumerable<Storage> GetAll()
        {
            if (this._context != null)
            {
                return this._context.Storages.Include(s => s.FormFactor).Include(s => s.Type).Include(s => s.Interface).ToList();
            }

            return new List<Storage>();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Storage>> GetAllAsync()
        {
            if(this._context != null)
            {
                return await this._context.Storages.Include(s => s.FormFactor).Include(s => s.Type).Include(s => s.Interface).ToListAsync();
            }

            return await Task.FromResult<IEnumerable<Storage>>(null);
        }

        /// <inheritdoc/>
        public async Task<Storage> GetByIdAsync(int id)
        {
            if(id > 0 && this._context != null)
            {
                return await this._context.Storages.Where(c => c.Id == id).FirstOrDefaultAsync();
            }

            return await Task.FromResult<Storage>(null);
        }
    }
}
