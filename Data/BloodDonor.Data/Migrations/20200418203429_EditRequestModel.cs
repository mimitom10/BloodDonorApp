namespace BloodDonor.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class EditRequestModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MedicalCondition",
                table: "Requests",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonalMessage",
                table: "Requests",
                maxLength: 300,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedicalCondition",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "PersonalMessage",
                table: "Requests");
        }
    }
}
