using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizChallenge.Infrastructure.Migrations
{
    public partial class addKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Quizzes",
                newName: "QuizId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuizId",
                table: "Quizzes",
                newName: "Id");
        }
    }
}
