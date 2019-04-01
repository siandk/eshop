using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class FeaturedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Featured",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Products",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Featured",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);
        }
    }
}
