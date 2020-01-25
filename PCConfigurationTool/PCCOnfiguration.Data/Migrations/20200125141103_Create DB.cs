using Microsoft.EntityFrameworkCore.Migrations;

namespace PCConfiguration.Data.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CPUCoolers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    FanRPM = table.Column<int>(nullable: false),
                    NoiseLevel = table.Column<int>(nullable: false),
                    Size = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUCoolers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CPUs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    CoresCount = table.Column<int>(nullable: false),
                    CoreClock = table.Column<string>(nullable: true),
                    BoostClock = table.Column<string>(nullable: true),
                    IntegratedGPU = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormFactors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormFactors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interfaces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interfaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemoryLatencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemoryLatencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PCItemType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCItemType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PowerSupplies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Efficiency = table.Column<short>(nullable: false),
                    Wattage = table.Column<short>(nullable: false),
                    Modular = table.Column<bool>(nullable: false),
                    FormFactorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerSupplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PowerSupplies_FormFactors_FormFactorId",
                        column: x => x.FormFactorId,
                        principalTable: "FormFactors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Chipset = table.Column<string>(nullable: true),
                    MemorySize = table.Column<int>(nullable: false),
                    CoreSpeed = table.Column<short>(nullable: false),
                    BoostSpeed = table.Column<short>(nullable: false),
                    InterfaceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoCards_Interfaces_InterfaceId",
                        column: x => x.InterfaceId,
                        principalTable: "Interfaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    PowerSupply = table.Column<string>(nullable: true),
                    Window = table.Column<bool>(nullable: false),
                    ExternalBays = table.Column<short>(nullable: false),
                    InternalBays = table.Column<short>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cases_PCItemType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "PCItemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Memories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Speed = table.Column<int>(nullable: false),
                    Modules = table.Column<short>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    CASLatencyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Memories_MemoryLatencies_CASLatencyId",
                        column: x => x.CASLatencyId,
                        principalTable: "MemoryLatencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Memories_PCItemType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "PCItemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Motherboards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    RamSlots = table.Column<short>(nullable: false),
                    MaxRam = table.Column<short>(nullable: false),
                    SocketTypeId = table.Column<int>(nullable: false),
                    FormFactorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motherboards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motherboards_FormFactors_FormFactorId",
                        column: x => x.FormFactorId,
                        principalTable: "FormFactors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motherboards_PCItemType_SocketTypeId",
                        column: x => x.SocketTypeId,
                        principalTable: "PCItemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Capacity = table.Column<string>(nullable: true),
                    Cache = table.Column<short>(nullable: false),
                    FormFactorId = table.Column<int>(nullable: false),
                    InterfaceId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Storages_FormFactors_FormFactorId",
                        column: x => x.FormFactorId,
                        principalTable: "FormFactors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Storages_Interfaces_InterfaceId",
                        column: x => x.InterfaceId,
                        principalTable: "Interfaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Storages_PCItemType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "PCItemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cases_TypeId",
                table: "Cases",
                column: "TypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Memories_CASLatencyId",
                table: "Memories",
                column: "CASLatencyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Memories_TypeId",
                table: "Memories",
                column: "TypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_FormFactorId",
                table: "Motherboards",
                column: "FormFactorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_SocketTypeId",
                table: "Motherboards",
                column: "SocketTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PowerSupplies_FormFactorId",
                table: "PowerSupplies",
                column: "FormFactorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Storages_FormFactorId",
                table: "Storages",
                column: "FormFactorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Storages_InterfaceId",
                table: "Storages",
                column: "InterfaceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Storages_TypeId",
                table: "Storages",
                column: "TypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VideoCards_InterfaceId",
                table: "VideoCards",
                column: "InterfaceId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "CPUCoolers");

            migrationBuilder.DropTable(
                name: "CPUs");

            migrationBuilder.DropTable(
                name: "Memories");

            migrationBuilder.DropTable(
                name: "Motherboards");

            migrationBuilder.DropTable(
                name: "PowerSupplies");

            migrationBuilder.DropTable(
                name: "Storages");

            migrationBuilder.DropTable(
                name: "VideoCards");

            migrationBuilder.DropTable(
                name: "MemoryLatencies");

            migrationBuilder.DropTable(
                name: "FormFactors");

            migrationBuilder.DropTable(
                name: "PCItemType");

            migrationBuilder.DropTable(
                name: "Interfaces");
        }
    }
}
