using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class nulableoprava : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Addresses_AddressId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Contracts_ContractId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_AddressId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_ContractId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Companies");

            migrationBuilder.AddColumn<int>(
                name: "CompanyCompId",
                table: "Contracts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_CompanyCompId",
                table: "Contracts",
                column: "CompanyCompId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Companies_CompanyCompId",
                table: "Contracts",
                column: "CompanyCompId",
                principalTable: "Companies",
                principalColumn: "CompId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Companies_CompanyCompId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_CompanyCompId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "CompanyCompId",
                table: "Contracts");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContractId",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AddressId",
                table: "Companies",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ContractId",
                table: "Companies",
                column: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Addresses_AddressId",
                table: "Companies",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Contracts_ContractId",
                table: "Companies",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id");
        }
    }
}
