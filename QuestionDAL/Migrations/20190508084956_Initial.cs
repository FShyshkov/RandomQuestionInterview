using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RandomQuestionInterview.QuestionDAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "QDB");

            migrationBuilder.CreateTable(
                name: "Questions",
                schema: "QDB",
                columns: table => new
                {
                    QuestionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                });

            migrationBuilder.InsertData(
                schema: "QDB",
                table: "Questions",
                columns: new[] { "QuestionId", "QuestionText" },
                values: new object[,]
                {
                    { 1, "От какого класса наследуются все обекты C#?" },
                    { 2, "Расскажите в чем разница между value и reference типами." },
                    { 3, "Что такое делегаты и события" },
                    { 4, "Опишите разницу между абстрактными классами и интерфейсами" },
                    { 5, "В чем разница между Dispose и Finalize?" },
                    { 6, "Опишите работу Garbage Collector в C#." },
                    { 7, "Что такое версионность WebAPI." },
                    { 8, "Перечислите елементы SOLID" },
                    { 9, "Опишите что означает Restful API" },
                    { 10, "Что такое Dependency Injection?" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions",
                schema: "QDB");
        }
    }
}
