using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizChallenge.Infrastructure.Migrations
{
    public partial class addSeedDataToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "QuizId", "Title" },
                values: new object[] { 3, "Iphone" });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "QuizId", "Title" },
                values: new object[] { 4, "Samsung" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "QuizId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "QuizId",
                keyValue: 4);
        }
    }
}
