using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace my_api.Migrations
{
    public partial class ExerciseRecordUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: null);
        }
    }
}
