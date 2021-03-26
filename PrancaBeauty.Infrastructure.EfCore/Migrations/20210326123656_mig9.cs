using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrancaBeauty.Infrastructure.EfCore.Migrations
{
    public partial class mig9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("18d98e1a-0f7b-434c-a7dc-acf70112d292"));

            migrationBuilder.AlterColumn<string>(
                name: "Abbr",
                table: "TblLanguage",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UseForSiteLanguage",
                table: "TblLanguage",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "PageName", "ParentId", "Sort" },
                values: new object[] { new Guid("352657f4-4762-455f-8bb0-acf7011a0d97"), "5bf79a5e-c696-40e9-a37d-1faf58da5dde", "دسترسی مدیر کل", "FullControl", "FULLCONTROL", "FullControl", null, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("352657f4-4762-455f-8bb0-acf7011a0d97"));

            migrationBuilder.DropColumn(
                name: "UseForSiteLanguage",
                table: "TblLanguage");

            migrationBuilder.AlterColumn<string>(
                name: "Abbr",
                table: "TblLanguage",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "PageName", "ParentId", "Sort" },
                values: new object[] { new Guid("18d98e1a-0f7b-434c-a7dc-acf70112d292"), "b1b265ae-2c8e-4e57-9b49-ca9baebd4753", "دسترسی مدیر کل", "FullControl", "FULLCONTROL", "FullControl", null, 0 });
        }
    }
}
