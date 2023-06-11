using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JTO_DAL.Migrations
{
    public partial class IsActiveAddedToTraining : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Trainings",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Trainings");
        }
    }
}
