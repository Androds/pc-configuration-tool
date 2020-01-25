﻿using PCConfiguration.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PCConfiguration.Core.Interfaces
{
    public interface IGenericService<TRepository, TEntity> where TRepository: IGenericRepository<TEntity>
        where TEntity: class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Create(TEntity obj);

        /// <summary>
        /// Gets or sets the repository used to execute the database operations.
        /// </summary>
        TRepository Repository { get; set; }
    }
}
