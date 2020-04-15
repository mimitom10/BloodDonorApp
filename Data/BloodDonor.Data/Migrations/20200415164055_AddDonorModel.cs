using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodDonor.Data.Migrations
{
    public partial class AddDonorModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Locations_LocationId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_AspNetUsers_UserId",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_UserId",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LocationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BloodType",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "DonorId",
                table: "Responses",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Donor",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    FullName = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false),
                    BloodType = table.Column<string>(nullable: true),
                    LocationId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donor_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Responses_DonorId",
                table: "Responses",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_Donor_IsDeleted",
                table: "Donor",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Donor_LocationId",
                table: "Donor",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Donor_DonorId",
                table: "Responses",
                column: "DonorId",
                principalTable: "Donor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Donor_DonorId",
                table: "Responses");

            migrationBuilder.DropTable(
                name: "Donor");

            migrationBuilder.DropIndex(
                name: "IX_Responses_DonorId",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "DonorId",
                table: "Responses");

            migrationBuilder.AddColumn<string>(
                name: "BloodType",
                table: "Responses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Responses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Responses_UserId",
                table: "Responses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LocationId",
                table: "AspNetUsers",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Locations_LocationId",
                table: "AspNetUsers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_AspNetUsers_UserId",
                table: "Responses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
