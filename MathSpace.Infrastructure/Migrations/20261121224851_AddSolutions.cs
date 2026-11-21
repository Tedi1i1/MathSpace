using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MathSpace.Infrastructure.Migrations;

/// <inheritdoc />
public partial class _20261121224851_AddSolutions : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Solutions",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Problem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Steps = table.Column<string>(type: "nvarchar(max)", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Solutions", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Solutions");
    }
}
