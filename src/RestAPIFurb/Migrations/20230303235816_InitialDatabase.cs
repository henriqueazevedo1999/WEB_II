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
                name: "AspNetRoles",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    normalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    concurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    userName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    normalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    normalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    emailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    passwordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    securityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    concurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    twoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    lockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    lockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    accessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Comandas",
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
                    table.PrimaryKey("PK_Comandas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    claimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    claimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_roleId",
                        column: x => x.roleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    claimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    claimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    loginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    providerKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    providerDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.loginProvider, x.providerKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    roleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.userId, x.roleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_roleId",
                        column: x => x.roleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    loginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.userId, x.loginProvider, x.name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
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
                    table.PrimaryKey("PK_Produtos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Produtos_Comandas_comandaId",
                        column: x => x.comandaId,
                        principalTable: "Comandas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "id", "concurrencyStamp", "name", "normalizedName" },
                values: new object[,]
                {
                    { "07134982-1dc4-4656-b8f9-652a4eba6189", null, "Administrador", "ADMINISTRADOR" },
                    { "8A990D37-D53C-458A-B9EB-B2FA67DC6F35", null, "Gerente", "GERENTE" },
                    { "e3f59cf5-c2f1-4f11-a4bf-700abde193a8", null, "Caixa", "CAIXA" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "id", "accessFailedCount", "concurrencyStamp", "email", "emailConfirmed", "firstName", "lastName", "lockoutEnabled", "lockoutEnd", "normalizedEmail", "normalizedUserName", "passwordHash", "phoneNumber", "phoneNumberConfirmed", "securityStamp", "twoFactorEnabled", "userName" },
                values: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "644f9f75-68e0-4e29-85ef-46c39be71ad4", null, false, "Gerente", "Inicial", false, null, null, "GERENTEINICIAL", "AQAAAAIAAYagAAAAEIgaRZxFdCbc0gkouNF6kxDUHLn4f8DVVtb5U/lCP7FyHS7SsFuamdNr8UXRkW5wCg==", null, false, "6e201a1c-c37e-41b9-9d02-83f0abb9d9ad", false, "GerenteInicial" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "roleId", "userId" },
                values: new object[] { "8A990D37-D53C-458A-B9EB-B2FA67DC6F35", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_roleId",
                table: "AspNetRoleClaims",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "normalizedName",
                unique: true,
                filter: "[normalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_userId",
                table: "AspNetUserClaims",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_userId",
                table: "AspNetUserLogins",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_roleId",
                table: "AspNetUserRoles",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "normalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "normalizedUserName",
                unique: true,
                filter: "[normalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comandas_idUsuario",
                table: "Comandas",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_comandaId",
                table: "Produtos",
                column: "comandaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_idLista",
                table: "Produtos",
                column: "idLista");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Comandas");
        }
    }
}
