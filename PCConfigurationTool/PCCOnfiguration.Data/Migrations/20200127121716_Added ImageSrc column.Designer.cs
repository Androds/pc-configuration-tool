﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PCConfiguration.Data;

namespace PCConfiguration.Data.Migrations
{
    [DbContext(typeof(PcDbContext))]
    [Migration("20200127121716_Added ImageSrc column")]
    partial class AddedImageSrccolumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PCConfiguration.Data.Models.CPU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BoostClock")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoreClock")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CoresCount")
                        .HasColumnType("int");

                    b.Property<string>("ImageSrc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IntegratedGPU")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("CPUs");
                });

            modelBuilder.Entity("PCConfiguration.Data.Models.CPUCooler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FanRPM")
                        .HasColumnType("int");

                    b.Property<string>("ImageSrc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoiseLevel")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double>("Size")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("CPUCoolers");
                });

            modelBuilder.Entity("PCConfiguration.Data.Models.Case", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("ExternalBays")
                        .HasColumnType("smallint");

                    b.Property<string>("ImageSrc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("InternalBays")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PowerSupply")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<bool>("Window")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("TypeId")
                        .IsUnique();

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("PCConfiguration.Data.Models.ConnectionInterface", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Interfaces");
                });

            modelBuilder.Entity("PCConfiguration.Data.Models.FormFactor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FormFactors");
                });

            modelBuilder.Entity("PCConfiguration.Data.Models.Memory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CASLatencyId")
                        .HasColumnType("int");

                    b.Property<string>("ImageSrc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("Modules")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CASLatencyId")
                        .IsUnique();

                    b.HasIndex("TypeId")
                        .IsUnique();

                    b.ToTable("Memories");
                });

            modelBuilder.Entity("PCConfiguration.Data.Models.MemoryLatency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MemoryLatencies");
                });

            modelBuilder.Entity("PCConfiguration.Data.Models.Motherboard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FormFactorId")
                        .HasColumnType("int");

                    b.Property<string>("ImageSrc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("MaxRam")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<short>("RamSlots")
                        .HasColumnType("smallint");

                    b.Property<int>("SocketTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FormFactorId")
                        .IsUnique();

                    b.HasIndex("SocketTypeId")
                        .IsUnique();

                    b.ToTable("Motherboards");
                });

            modelBuilder.Entity("PCConfiguration.Data.Models.PCItemType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PCItemType");
                });

            modelBuilder.Entity("PCConfiguration.Data.Models.PowerSupply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("Efficiency")
                        .HasColumnType("smallint");

                    b.Property<int>("FormFactorId")
                        .HasColumnType("int");

                    b.Property<string>("ImageSrc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Modular")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<short>("Wattage")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("FormFactorId")
                        .IsUnique();

                    b.ToTable("PowerSupplies");
                });

            modelBuilder.Entity("PCConfiguration.Data.Models.Storage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("Cache")
                        .HasColumnType("smallint");

                    b.Property<string>("Capacity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FormFactorId")
                        .HasColumnType("int");

                    b.Property<string>("ImageSrc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InterfaceId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FormFactorId")
                        .IsUnique();

                    b.HasIndex("InterfaceId")
                        .IsUnique();

                    b.HasIndex("TypeId")
                        .IsUnique();

                    b.ToTable("Storages");
                });

            modelBuilder.Entity("PCConfiguration.Data.Models.VideoCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("BoostSpeed")
                        .HasColumnType("smallint");

                    b.Property<string>("Chipset")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("CoreSpeed")
                        .HasColumnType("smallint");

                    b.Property<string>("ImageSrc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InterfaceId")
                        .HasColumnType("int");

                    b.Property<int>("MemorySize")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("InterfaceId")
                        .IsUnique();

                    b.ToTable("VideoCards");
                });

            modelBuilder.Entity("PCConfiguration.Data.Models.Case", b =>
                {
                    b.HasOne("PCConfiguration.Data.Models.PCItemType", "Type")
                        .WithOne("Case")
                        .HasForeignKey("PCConfiguration.Data.Models.Case", "TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PCConfiguration.Data.Models.Memory", b =>
                {
                    b.HasOne("PCConfiguration.Data.Models.MemoryLatency", "CASLatency")
                        .WithOne("Memory")
                        .HasForeignKey("PCConfiguration.Data.Models.Memory", "CASLatencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PCConfiguration.Data.Models.PCItemType", "Type")
                        .WithOne("Memory")
                        .HasForeignKey("PCConfiguration.Data.Models.Memory", "TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PCConfiguration.Data.Models.Motherboard", b =>
                {
                    b.HasOne("PCConfiguration.Data.Models.FormFactor", "FormFactor")
                        .WithOne("Motherboard")
                        .HasForeignKey("PCConfiguration.Data.Models.Motherboard", "FormFactorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PCConfiguration.Data.Models.PCItemType", "SocketType")
                        .WithOne("Motherboard")
                        .HasForeignKey("PCConfiguration.Data.Models.Motherboard", "SocketTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PCConfiguration.Data.Models.PowerSupply", b =>
                {
                    b.HasOne("PCConfiguration.Data.Models.FormFactor", "FormFactor")
                        .WithOne("PowerSupply")
                        .HasForeignKey("PCConfiguration.Data.Models.PowerSupply", "FormFactorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PCConfiguration.Data.Models.Storage", b =>
                {
                    b.HasOne("PCConfiguration.Data.Models.FormFactor", "FormFactor")
                        .WithOne("Storage")
                        .HasForeignKey("PCConfiguration.Data.Models.Storage", "FormFactorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PCConfiguration.Data.Models.ConnectionInterface", "Interface")
                        .WithOne("Storage")
                        .HasForeignKey("PCConfiguration.Data.Models.Storage", "InterfaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PCConfiguration.Data.Models.PCItemType", "Type")
                        .WithOne("Storage")
                        .HasForeignKey("PCConfiguration.Data.Models.Storage", "TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PCConfiguration.Data.Models.VideoCard", b =>
                {
                    b.HasOne("PCConfiguration.Data.Models.ConnectionInterface", "Interface")
                        .WithOne("VideoCard")
                        .HasForeignKey("PCConfiguration.Data.Models.VideoCard", "InterfaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
