﻿using Microsoft.EntityFrameworkCore;
using PCConfiguration.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCConfiguration.Data
{
    public class PcDbContext : DbContext
    {
        public PcDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=PCConfiguration;Trusted_Connection=True;");
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
        public DbSet<FormFactor> FormFactors { get; set; }
        public DbSet<MotherboardSocketType> MotherboardSocketTypes { get; set; }
        public DbSet<ConnectionInterface> Interfaces { get; set; }
        public DbSet<StorageType> StorageTypes { get; set; }
    }
}
