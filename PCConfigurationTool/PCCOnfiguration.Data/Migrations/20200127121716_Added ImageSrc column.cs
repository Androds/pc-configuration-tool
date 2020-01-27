using Microsoft.EntityFrameworkCore.Migrations;

namespace PCConfiguration.Data.Migrations
{
    public partial class AddedImageSrccolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageSrc",
                table: "VideoCards",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageSrc",
                table: "Storages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageSrc",
                table: "PowerSupplies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageSrc",
                table: "Motherboards",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageSrc",
                table: "Memories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageSrc",
                table: "CPUs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageSrc",
                table: "CPUCoolers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageSrc",
                table: "Cases",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageSrc",
                table: "VideoCards");

            migrationBuilder.DropColumn(
                name: "ImageSrc",
                table: "Storages");

            migrationBuilder.DropColumn(
                name: "ImageSrc",
                table: "PowerSupplies");

            migrationBuilder.DropColumn(
                name: "ImageSrc",
                table: "Motherboards");

            migrationBuilder.DropColumn(
                name: "ImageSrc",
                table: "Memories");

            migrationBuilder.DropColumn(
                name: "ImageSrc",
                table: "CPUs");

            migrationBuilder.DropColumn(
                name: "ImageSrc",
                table: "CPUCoolers");

            migrationBuilder.DropColumn(
                name: "ImageSrc",
                table: "Cases");
        }
    }
}
