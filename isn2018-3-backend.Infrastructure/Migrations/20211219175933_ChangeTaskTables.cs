using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace isn2018_3_backend.Infrastructure.Migrations
{
    public partial class ChangeTaskTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataFile",
                table: "Task");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "DataFile",
                table: "Task",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
