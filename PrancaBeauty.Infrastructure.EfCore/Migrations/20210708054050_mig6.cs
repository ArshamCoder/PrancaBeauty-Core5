using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrancaBeauty.Infrastructure.EfCore.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneCode",
                table: "TblCountries",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "TblAddress",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_TblAddress_CityId",
                table: "TblAddress",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TblAddress_ProviceId",
                table: "TblAddress",
                column: "ProviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblAddress_TblCities_CityId",
                table: "TblAddress",
                column: "CityId",
                principalTable: "TblCities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblAddress_TblProvinces_ProviceId",
                table: "TblAddress",
                column: "ProviceId",
                principalTable: "TblProvinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblAddress_TblCities_CityId",
                table: "TblAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_TblAddress_TblProvinces_ProviceId",
                table: "TblAddress");

            migrationBuilder.DropIndex(
                name: "IX_TblAddress_CityId",
                table: "TblAddress");

            migrationBuilder.DropIndex(
                name: "IX_TblAddress_ProviceId",
                table: "TblAddress");

            migrationBuilder.DropColumn(
                name: "PhoneCode",
                table: "TblCountries");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "TblAddress");
        }
    }
}
