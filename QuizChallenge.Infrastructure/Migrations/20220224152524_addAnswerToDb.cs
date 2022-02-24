using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizChallenge.Infrastructure.Migrations
{
    public partial class addAnswerToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "QuestionId", "Text" },
                values: new object[] { 1, 1, "Answer 1" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "QuestionId", "Text" },
                values: new object[] { 4, 2, "Answer 2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
