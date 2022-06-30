using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HttpStatusCode.Migrations
{
    public partial class initDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "DeleteDate", "Description", "Name", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 30, 11, 59, 1, 740, DateTimeKind.Local).AddTicks(7122), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elektronik", "Elektronik", 0, null },
                    { 2, new DateTime(2022, 6, 30, 11, 59, 1, 740, DateTimeKind.Local).AddTicks(7135), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tekstil", "Tekstil", 0, null },
                    { 3, new DateTime(2022, 6, 30, 11, 59, 1, 740, DateTimeKind.Local).AddTicks(7138), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yiyecek", "Yiyecek", 0, null },
                    { 4, new DateTime(2022, 6, 30, 11, 59, 1, 740, DateTimeKind.Local).AddTicks(7138), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İçecek", "İçecek", 0, null },
                    { 5, new DateTime(2022, 6, 30, 11, 59, 1, 740, DateTimeKind.Local).AddTicks(7138), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nalburiye", "Nalburiye", 0, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
