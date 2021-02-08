using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrancaBeauty.Infrastructure.EfCore.Migrations
{
    public partial class min2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AccessLevelId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TblAccessLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAccessLevels", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "PageName", "ParentId", "Sort" },
                values: new object[] { new Guid("63729005-6a77-4ebb-abe5-acc9013d35b2"), "12c5b963-b803-4d6d-85a1-af124d5d746e", "دسترسی مدیر کل", "FullControl", "FULLCONTROL", "FullControl", null, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AccessLevelId",
                table: "AspNetUsers",
                column: "AccessLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TblAccessLevels_AccessLevelId",
                table: "AspNetUsers",
                column: "AccessLevelId",
                principalTable: "TblAccessLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TblAccessLevels_AccessLevelId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TblAccessLevels");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AccessLevelId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("63729005-6a77-4ebb-abe5-acc9013d35b2"));

            migrationBuilder.DropColumn(
                name: "AccessLevelId",
                table: "AspNetUsers");
        }
    }
}
