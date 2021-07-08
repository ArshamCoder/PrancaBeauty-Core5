using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrancaBeauty.Infrastructure.EfCore.Migrations
{
    public partial class mig7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblCategoris",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: true),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCategoris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblCategoris_TblCategoris_ParentId",
                        column: x => x.ParentId,
                        principalTable: "TblCategoris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblCategoris_TblFile_ImageId",
                        column: x => x.ImageId,
                        principalTable: "TblFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblCategory_Translates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: false),
                    LangId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCategory_Translates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblCategory_Translates_TblCategoris_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TblCategoris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblCategory_Translates_TblLanguage_LangId",
                        column: x => x.LangId,
                        principalTable: "TblLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblCategoris_ImageId",
                table: "TblCategoris",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCategoris_ParentId",
                table: "TblCategoris",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCategory_Translates_CategoryId",
                table: "TblCategory_Translates",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCategory_Translates_LangId",
                table: "TblCategory_Translates",
                column: "LangId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblCategory_Translates");

            migrationBuilder.DropTable(
                name: "TblCategoris");
        }
    }
}
