using Microsoft.EntityFrameworkCore.Migrations;

namespace PrancaBeauty.Infrastructure.EfCore.Migrations
{
    public partial class mig8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblCategory_Translates_TblCategoris_CategoryId",
                table: "TblCategory_Translates");

            migrationBuilder.AddForeignKey(
                name: "FK_TblCategory_Translates_TblCategoris_CategoryId",
                table: "TblCategory_Translates",
                column: "CategoryId",
                principalTable: "TblCategoris",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblCategory_Translates_TblCategoris_CategoryId",
                table: "TblCategory_Translates");

            migrationBuilder.AddForeignKey(
                name: "FK_TblCategory_Translates_TblCategoris_CategoryId",
                table: "TblCategory_Translates",
                column: "CategoryId",
                principalTable: "TblCategoris",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
