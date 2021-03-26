using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace PrancaBeauty.Infrastructure.EfCore.Migrations
{
    public partial class mig8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a5f885aa-e04c-459b-a656-aceb0110bf83"));

            migrationBuilder.AddColumn<string>(
                name: "Abbr",
                table: "TblLanguage",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "PageName", "ParentId", "Sort" },
                values: new object[] { new Guid("18d98e1a-0f7b-434c-a7dc-acf70112d292"), "b1b265ae-2c8e-4e57-9b49-ca9baebd4753", "دسترسی مدیر کل", "FullControl", "FULLCONTROL", "FullControl", null, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("18d98e1a-0f7b-434c-a7dc-acf70112d292"));

            migrationBuilder.DropColumn(
                name: "Abbr",
                table: "TblLanguage");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "PageName", "ParentId", "Sort" },
                values: new object[] { new Guid("a5f885aa-e04c-459b-a656-aceb0110bf83"), "61861598-49ed-4cc5-a4e8-bdd5f8639834", "دسترسی مدیر کل", "FullControl", "FULLCONTROL", "FullControl", null, 0 });
        }
    }
}
