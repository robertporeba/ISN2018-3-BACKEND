using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace isn2018_3_backend.Infrastructure.Migrations
{
    public partial class TaskTableFileColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "DataFile",
                table: "Task",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataFile",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Task");
        }
    }
}
