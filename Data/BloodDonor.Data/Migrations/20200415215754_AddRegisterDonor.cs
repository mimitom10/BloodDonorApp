using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodDonor.Data.Migrations
{
    public partial class AddRegisterDonor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donor_Locations_LocationId",
                table: "Donor");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Donor_DonorId",
                table: "Responses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Donor",
                table: "Donor");

            migrationBuilder.RenameTable(
                name: "Donor",
                newName: "Donors");

            migrationBuilder.RenameIndex(
                name: "IX_Donor_LocationId",
                table: "Donors",
                newName: "IX_Donors_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Donor_IsDeleted",
                table: "Donors",
                newName: "IX_Donors_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donors",
                table: "Donors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_Locations_LocationId",
                table: "Donors",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Donors_DonorId",
                table: "Responses",
                column: "DonorId",
                principalTable: "Donors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donors_Locations_LocationId",
                table: "Donors");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Donors_DonorId",
                table: "Responses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Donors",
                table: "Donors");

            migrationBuilder.RenameTable(
                name: "Donors",
                newName: "Donor");

            migrationBuilder.RenameIndex(
                name: "IX_Donors_LocationId",
                table: "Donor",
                newName: "IX_Donor_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Donors_IsDeleted",
                table: "Donor",
                newName: "IX_Donor_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donor",
                table: "Donor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Donor_Locations_LocationId",
                table: "Donor",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Donor_DonorId",
                table: "Responses",
                column: "DonorId",
                principalTable: "Donor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
