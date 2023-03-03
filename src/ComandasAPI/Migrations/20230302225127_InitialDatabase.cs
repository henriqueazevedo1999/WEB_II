using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestAPIFurb.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "comandas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    nomeUsuario = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    telefoneUsuario = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    timeCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comandas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "produtos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idLista = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    preco = table.Column<int>(type: "int", nullable: false),
                    comandaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtos", x => x.id);
                    table.ForeignKey(
                        name: "FK_produtos_comandas_comandaId",
                        column: x => x.comandaId,
                        principalTable: "comandas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "comandas",
                columns: new[] { "id", "idUsuario", "nomeUsuario", "telefoneUsuario" },
                values: new object[,]
                {
                    { 1, 1, "joao", "478888888" },
                    { 2, 2, "Pedro", "47999999" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_comandas_idUsuario",
                table: "comandas",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_produtos_comandaId",
                table: "produtos",
                column: "comandaId");

            migrationBuilder.CreateIndex(
                name: "IX_produtos_idLista",
                table: "produtos",
                column: "idLista");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "produtos");

            migrationBuilder.DropTable(
                name: "comandas");
        }
    }
}
