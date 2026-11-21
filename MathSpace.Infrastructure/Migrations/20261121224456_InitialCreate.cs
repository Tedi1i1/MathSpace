using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MathSpace.Infrastructure.Migrations;

/// <inheritdoc />
public partial class _20261121224456_InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "MathTopics",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Grade = table.Column<int>(type: "int", nullable: false),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MathTopics", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Exercises",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Difficulty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                MathTopicId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Exercises", x => x.Id);
                table.ForeignKey(
                    name: "FK_Exercises_MathTopics_MathTopicId",
                    column: x => x.MathTopicId,
                    principalTable: "MathTopics",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Exercises_MathTopicId",
            table: "Exercises",
            column: "MathTopicId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Exercises");

        migrationBuilder.DropTable(
            name: "MathTopics");
    }
}
