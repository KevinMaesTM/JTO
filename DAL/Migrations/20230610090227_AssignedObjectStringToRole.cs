using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JTO_DAL.Migrations
{
    public partial class AssignedObjectStringToRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssignedObject",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedObject",
                table: "Roles");
        }
    }
}
