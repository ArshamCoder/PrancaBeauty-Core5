using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrancaBeauty.Infrastructure.EfCore.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1b1098fa-de5e-4d82-8059-acd301747526"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "TblSetting",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsEnable",
                table: "TblSetting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "PageName", "ParentId", "Sort" },
                values: new object[] { new Guid("8708382d-890b-402e-82f6-acd60104348a"), "b4f3f3c5-8071-41d5-9185-e1ce60802d38", "دسترسی مدیر کل", "FullControl", "FULLCONTROL", "FullControl", null, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8708382d-890b-402e-82f6-acd60104348a"));

            migrationBuilder.DropColumn(
                name: "Date",
                table: "TblSetting");

            migrationBuilder.DropColumn(
                name: "IsEnable",
                table: "TblSetting");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "PageName", "ParentId", "Sort" },
                values: new object[] { new Guid("1b1098fa-de5e-4d82-8059-acd301747526"), "265eab78-2b0d-4f15-92ba-57f21bd7cdf3", "دسترسی مدیر کل", "FullControl", "FULLCONTROL", "FullControl", null, 0 });
        }
    }
}
