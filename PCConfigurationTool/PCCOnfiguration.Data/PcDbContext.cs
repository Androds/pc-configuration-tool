using Microsoft.EntityFrameworkCore;
using PCConfiguration.Data.Models;

namespace PCConfiguration.Data
{
    public class PcDbContext : DbContext
    {
        /// <summary>
        /// <para>
        /// Override this method to configure the database (and other options) to be used for this context.
        /// This method is called for each instance of the context that is created.
        /// The base implementation does nothing.
        /// </para>
        /// <para>
        /// In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" /> may or may not have been passed
        /// to the constructor, you can use <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured" /> to determine if
        /// the options have already been set, and skip some or all of the logic in
        /// <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" />.
        /// </para>
        /// </summary>
        /// <param name="optionsBuilder">A builder used to create or modify options for this context. Databases (and other extensions)
        /// typically define extension methods on this object that allow you to configure the context.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Server=.\;Database=PCConfiguration;Trusted_Connection=True;");
        }

        /// <summary>
        /// Gets or sets the cases.
        /// </summary>
        /// <value>
        /// The cases.
        /// </value>
        public DbSet<Case> Cases { get; set; }

        /// <summary>
        /// Gets or sets the cp us.
        /// </summary>
        /// <value>
        /// The cp us.
        /// </value>
        public DbSet<CPU> CPUs { get; set; }

        /// <summary>
        /// Gets or sets the cpu coolers.
        /// </summary>
        /// <value>
        /// The cpu coolers.
        /// </value>
        public DbSet<CPUCooler> CPUCoolers { get; set; }

        /// <summary>
        /// Gets or sets the memories.
        /// </summary>
        /// <value>
        /// The memories.
        /// </value>
        public DbSet<Memory> Memories { get; set; }

        /// <summary>
        /// Gets or sets the motherboards.
        /// </summary>
        /// <value>
        /// The motherboards.
        /// </value>
        public DbSet<Motherboard> Motherboards { get; set; }

        /// <summary>
        /// Gets or sets the power supplies.
        /// </summary>
        /// <value>
        /// The power supplies.
        /// </value>
        public DbSet<PowerSupply> PowerSupplies { get; set; }

        /// <summary>
        /// Gets or sets the storages.
        /// </summary>
        /// <value>
        /// The storages.
        /// </value>
        public DbSet<Storage> Storages { get; set; }

        /// <summary>
        /// Gets or sets the video cards.
        /// </summary>
        /// <value>
        /// The video cards.
        /// </value>
        public DbSet<VideoCard> VideoCards { get; set; }

        /// <summary>
        /// Gets or sets the case types.
        /// </summary>
        /// <value>
        /// The case types.
        /// </value>
        public DbSet<PCItemType> CaseTypes { get; set; }

        /// <summary>
        /// Gets or sets the memory latencies.
        /// </summary>
        /// <value>
        /// The memory latencies.
        /// </value>
        public DbSet<MemoryLatency> MemoryLatencies { get; set; }

        /// <summary>
        /// Gets or sets the form factors.
        /// </summary>
        /// <value>
        /// The form factors.
        /// </value>
        public DbSet<FormFactor> FormFactors { get; set; }

        /// <summary>
        /// Gets or sets the interfaces.
        /// </summary>
        /// <value>
        /// The interfaces.
        /// </value>
        public DbSet<ConnectionInterface> Interfaces { get; set; }

        /// <summary>
        /// Gets or sets the pc item types.
        /// </summary>
        /// <value>
        /// The pc item types.
        /// </value>
        public DbSet<PCItemType> PCItemTypes { get; set; }
    }
}
