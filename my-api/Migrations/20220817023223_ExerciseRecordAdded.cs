using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace my_api.Migrations
{
    public partial class ExerciseRecordAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "ImageUrl", "MuscularGroupId", "Name" },
                values: new object[] { 10, null, 1, "Arnold Press" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
