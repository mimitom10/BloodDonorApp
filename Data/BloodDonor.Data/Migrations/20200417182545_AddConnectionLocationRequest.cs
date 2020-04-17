using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodDonor.Data.Migrations
{
    public partial class AddConnectionLocationRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodType",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "Requests");

            migrationBuilder.AddColumn<string>(
                name: "LocationId",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MedicalCondition",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Requests",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BloodType",
                table: "Patients",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "MedicalCondition",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Requests");

            migrationBuilder.AddColumn<string>(
                name: "BloodType",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BloodType",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
