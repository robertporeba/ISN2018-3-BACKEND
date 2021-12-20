using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace isn2018_3_backend.Infrastructure.Migrations
{
    public partial class ChangeTaskTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "FormFile",
                table: "Task",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormFile",
                table: "Task");
        }
    }
}
