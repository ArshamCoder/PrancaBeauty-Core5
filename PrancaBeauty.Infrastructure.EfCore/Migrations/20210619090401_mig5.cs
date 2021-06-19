using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrancaBeauty.Infrastructure.EfCore.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TblLanguage_TblLanguageId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TblLanguageId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TblLanguageId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "LangId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                maxLength: 150,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LangId",
                table: "AspNetUsers",
                column: "LangId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TblLanguage_LangId",
                table: "AspNetUsers",
                column: "LangId",
                principalTable: "TblLanguage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TblLanguage_LangId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LangId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LangId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "TblLanguageId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TblLanguageId",
                table: "AspNetUsers",
                column: "TblLanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TblLanguage_TblLanguageId",
                table: "AspNetUsers",
                column: "TblLanguageId",
                principalTable: "TblLanguage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
