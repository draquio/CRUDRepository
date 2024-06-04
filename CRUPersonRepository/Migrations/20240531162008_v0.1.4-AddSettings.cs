using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUPersonRepository.Migrations
{
    /// <inheritdoc />
    public partial class v014AddSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonRol_Persons_PersonId",
                table: "PersonRol");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonRol_Rol_RolId",
                table: "PersonRol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rol",
                table: "Rol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonRol",
                table: "PersonRol");

            migrationBuilder.RenameTable(
                name: "Rol",
                newName: "Rols");

            migrationBuilder.RenameTable(
                name: "PersonRol",
                newName: "PersonRols");

            migrationBuilder.RenameIndex(
                name: "IX_PersonRol_RolId",
                table: "PersonRols",
                newName: "IX_PersonRols_RolId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonRol_PersonId",
                table: "PersonRols",
                newName: "IX_PersonRols_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rols",
                table: "Rols",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonRols",
                table: "PersonRols",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonRols_Persons_PersonId",
                table: "PersonRols",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonRols_Rols_RolId",
                table: "PersonRols",
                column: "RolId",
                principalTable: "Rols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonRols_Persons_PersonId",
                table: "PersonRols");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonRols_Rols_RolId",
                table: "PersonRols");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rols",
                table: "Rols");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonRols",
                table: "PersonRols");

            migrationBuilder.RenameTable(
                name: "Rols",
                newName: "Rol");

            migrationBuilder.RenameTable(
                name: "PersonRols",
                newName: "PersonRol");

            migrationBuilder.RenameIndex(
                name: "IX_PersonRols_RolId",
                table: "PersonRol",
                newName: "IX_PersonRol_RolId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonRols_PersonId",
                table: "PersonRol",
                newName: "IX_PersonRol_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rol",
                table: "Rol",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonRol",
                table: "PersonRol",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonRol_Persons_PersonId",
                table: "PersonRol",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonRol_Rol_RolId",
                table: "PersonRol",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
