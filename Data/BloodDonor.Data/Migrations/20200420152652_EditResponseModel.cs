using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodDonor.Data.Migrations
{
    public partial class EditResponseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "HasBeenResponsed",
                table: "Patients");

            migrationBuilder.AddColumn<bool>(
                name: "IsAnonymous",
                table: "Responses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "Responses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RequestId",
                table: "Responses",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_RequestId",
                table: "Responses",
                column: "RequestId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Requests_RequestId",
                table: "Responses",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Requests_RequestId",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_RequestId",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "IsAnonymous",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Responses");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Responses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HasBeenResponsed",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
