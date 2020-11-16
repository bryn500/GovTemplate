using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DfESurveyTool.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyModelStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyModelStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyModel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    MyModelStatusId = table.Column<int>(nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MyModel_MyModelStatus_MyModelStatusId",
                        column: x => x.MyModelStatusId,
                        principalTable: "MyModelStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MyModelStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 0, "New" },
                    { 5, "Processing" },
                    { 10, "Complete" },
                    { 99, "Error" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyModel_MyModelStatusId",
                table: "MyModel",
                column: "MyModelStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MyModel_Name",
                table: "MyModel",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MyModelStatus_Name",
                table: "MyModelStatus",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyModel");

            migrationBuilder.DropTable(
                name: "MyModelStatus");
        }
    }
}
