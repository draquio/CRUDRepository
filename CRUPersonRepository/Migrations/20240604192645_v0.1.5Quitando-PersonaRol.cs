using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUPersonRepository.Migrations
{
    /// <inheritdoc />
    public partial class v015QuitandoPersonaRol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonRols");

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_RolId",
                table: "Persons",
                column: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Rols_RolId",
                table: "Persons",
                column: "RolId",
                principalTable: "Rols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Rols_RolId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_RolId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "Persons");

            migrationBuilder.CreateTable(
                name: "PersonRols",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRols", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonRols_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonRols_Rols_RolId",
                        column: x => x.RolId,
                        principalTable: "Rols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonRols_PersonId",
                table: "PersonRols",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRols_RolId",
                table: "PersonRols",
                column: "RolId");
        }
    }
}
