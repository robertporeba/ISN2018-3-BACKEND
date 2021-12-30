using Microsoft.EntityFrameworkCore.Migrations;

namespace isn2018_3_backend.Infrastructure.Migrations
{
    public partial class taskcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Task");
        }
    }
}
