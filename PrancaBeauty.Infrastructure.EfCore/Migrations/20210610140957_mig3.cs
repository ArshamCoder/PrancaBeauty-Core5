using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrancaBeauty.Infrastructure.EfCore.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodeMeli",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TblLanguageId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TblCountries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: false),
                    FlagImgId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCountries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblCountries_TblFile_FlagImgId",
                        column: x => x.FlagImgId,
                        principalTable: "TblFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 450, nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: false),
                    ProviceId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: false),
                    District = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Plaque = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblAddress_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblAddress_TblCountries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "TblCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblCountries_Translates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: false),
                    LangId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCountries_Translates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblCountries_Translates_TblCountries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "TblCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblCountries_Translates_TblLanguage_LangId",
                        column: x => x.LangId,
                        principalTable: "TblLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblProvinces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProvinces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblProvinces_TblCountries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "TblCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblCities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: false),
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblCities_TblProvinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "TblProvinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblProvinces_Translate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: false),
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: false),
                    LangId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProvinces_Translate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblProvinces_Translate_TblLanguage_LangId",
                        column: x => x.LangId,
                        principalTable: "TblLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblProvinces_Translate_TblProvinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "TblProvinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblCities_Translates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: false),
                    LangId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCities_Translates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblCities_Translates_TblCities_CityId",
                        column: x => x.CityId,
                        principalTable: "TblCities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TblCities_Translates_TblLanguage_LangId",
                        column: x => x.LangId,
                        principalTable: "TblLanguage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TblLanguageId",
                table: "AspNetUsers",
                column: "TblLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_TblAddress_CountryId",
                table: "TblAddress",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TblAddress_UserId",
                table: "TblAddress",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCities_ProvinceId",
                table: "TblCities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCities_Translates_CityId",
                table: "TblCities_Translates",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCities_Translates_LangId",
                table: "TblCities_Translates",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCountries_FlagImgId",
                table: "TblCountries",
                column: "FlagImgId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCountries_Translates_CountryId",
                table: "TblCountries_Translates",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCountries_Translates_LangId",
                table: "TblCountries_Translates",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_TblProvinces_CountryId",
                table: "TblProvinces",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TblProvinces_Translate_LangId",
                table: "TblProvinces_Translate",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_TblProvinces_Translate_ProvinceId",
                table: "TblProvinces_Translate",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TblLanguage_TblLanguageId",
                table: "AspNetUsers",
                column: "TblLanguageId",
                principalTable: "TblLanguage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TblLanguage_TblLanguageId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TblAddress");

            migrationBuilder.DropTable(
                name: "TblCities_Translates");

            migrationBuilder.DropTable(
                name: "TblCountries_Translates");

            migrationBuilder.DropTable(
                name: "TblProvinces_Translate");

            migrationBuilder.DropTable(
                name: "TblCities");

            migrationBuilder.DropTable(
                name: "TblProvinces");

            migrationBuilder.DropTable(
                name: "TblCountries");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TblLanguageId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CodeMeli",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TblLanguageId",
                table: "AspNetUsers");
        }
    }
}
