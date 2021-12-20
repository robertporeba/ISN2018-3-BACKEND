using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace isn2018_3_backend.Infrastructure.Migrations
{
    public partial class ChangeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormFile",
                table: "Task");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "FormFile",
                table: "Task",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
