using Microsoft.EntityFrameworkCore.Migrations;

namespace isn2018_3_backend.Infrastructure.Migrations
{
    public partial class changerelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Priority_PriorityId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Project_ProjectId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Status_StatusId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_PriorityId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_ProjectId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_StatusId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_File_TaskId",
                table: "File");

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Status",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Project",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Priority",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Status_TaskId",
                table: "Status",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_TaskId",
                table: "Project",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Priority_TaskId",
                table: "Priority",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_File_TaskId",
                table: "File",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Priority_Task_TaskId",
                table: "Priority",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Task_TaskId",
                table: "Project",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Status_Task_TaskId",
                table: "Status",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Priority_Task_TaskId",
                table: "Priority");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Task_TaskId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Status_Task_TaskId",
                table: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Status_TaskId",
                table: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Project_TaskId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Priority_TaskId",
                table: "Priority");

            migrationBuilder.DropIndex(
                name: "IX_File_TaskId",
                table: "File");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Priority");

            migrationBuilder.CreateIndex(
                name: "IX_Task_PriorityId",
                table: "Task",
                column: "PriorityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Task_ProjectId",
                table: "Task",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Task_StatusId",
                table: "Task",
                column: "StatusId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_File_TaskId",
                table: "File",
                column: "TaskId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Priority_PriorityId",
                table: "Task",
                column: "PriorityId",
                principalTable: "Priority",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Project_ProjectId",
                table: "Task",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Status_StatusId",
                table: "Task",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
