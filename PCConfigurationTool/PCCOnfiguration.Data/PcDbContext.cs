using Microsoft.EntityFrameworkCore;
using PCCOnfiguration.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCCOnfiguration.Data
{
    public class PcDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=./;Database=PcConfiguration;Trusted_Connection=True;");
        }

        public DbSet<Case> Cases { get; set; }
        public DbSet<CPU> CPUs { get; set; }
        public DbSet<CPUCooler> CPUCoolers { get; set; }
        public DbSet<Memory> Memories { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<PowerSupply> PowerSupplies { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<VideoCard> VideoCards { get; set; }
        public DbSet<CaseType> CaseTypes { get; set; }
        public DbSet<MemoryLatency> MemoryLatencies { get; set; }
        public DbSet<MemoryType> MemoryTypes { get; set; }
        public DbSet<MotherboardFormFactor> MotherboardFormFactors { get; set; }
        public DbSet<MotherboardSocketType> MotherboardSocketTypes { get; set; }
        public DbSet<PowerSupplyFormFactor> PowerSupplyFormFactors { get; set; }
        public DbSet<StorageFormFactor> StorageFormFactors { get; set; }
        public DbSet<StorageInterface> StorageInterfaces { get; set; }
        public DbSet<StorageType> StorageTypes { get; set; }
        public DbSet<VideoCardInterface> VideoCardInterfaces { get; set; }
    }
}
