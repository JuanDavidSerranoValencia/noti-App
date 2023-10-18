using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "modulomaestro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreModulo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modulomaestro", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pemrisogenerico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombrePermiso = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pemrisogenerico", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "submodulo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreSubmodulo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_submodulo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rolmaestro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdRolFk = table.Column<int>(type: "int", nullable: false),
                    IdModuloMaestroFk = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rolmaestro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rolmaestro_modulomaestro_IdModuloMaestroFk",
                        column: x => x.IdModuloMaestroFk,
                        principalTable: "modulomaestro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rolmaestro_rol_IdRolFk",
                        column: x => x.IdRolFk,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "maestrovssubmodulo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdModuloMaestroFk = table.Column<int>(type: "int", nullable: false),
                    IdSubModuloFk = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maestrovssubmodulo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_maestrovssubmodulo_modulomaestro_IdModuloMaestroFk",
                        column: x => x.IdModuloMaestroFk,
                        principalTable: "modulomaestro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_maestrovssubmodulo_submodulo_IdSubModuloFk",
                        column: x => x.IdSubModuloFk,
                        principalTable: "submodulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "genericosvssubmodulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdRolFk = table.Column<int>(type: "int", nullable: false),
                    IdPermisoGenerioFk = table.Column<int>(type: "int", nullable: false),
                    IdMaestroSubmoduloFk = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genericosvssubmodulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_genericosvssubmodulos_maestrovssubmodulo_IdMaestroSubmoduloFk",
                        column: x => x.IdMaestroSubmoduloFk,
                        principalTable: "maestrovssubmodulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_genericosvssubmodulos_pemrisogenerico_IdPermisoGenerioFk",
                        column: x => x.IdPermisoGenerioFk,
                        principalTable: "pemrisogenerico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_genericosvssubmodulos_rol_IdRolFk",
                        column: x => x.IdRolFk,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_genericosvssubmodulos_IdMaestroSubmoduloFk",
                table: "genericosvssubmodulos",
                column: "IdMaestroSubmoduloFk");

            migrationBuilder.CreateIndex(
                name: "IX_genericosvssubmodulos_IdPermisoGenerioFk",
                table: "genericosvssubmodulos",
                column: "IdPermisoGenerioFk");

            migrationBuilder.CreateIndex(
                name: "IX_genericosvssubmodulos_IdRolFk",
                table: "genericosvssubmodulos",
                column: "IdRolFk");

            migrationBuilder.CreateIndex(
                name: "IX_maestrovssubmodulo_IdModuloMaestroFk",
                table: "maestrovssubmodulo",
                column: "IdModuloMaestroFk");

            migrationBuilder.CreateIndex(
                name: "IX_maestrovssubmodulo_IdSubModuloFk",
                table: "maestrovssubmodulo",
                column: "IdSubModuloFk");

            migrationBuilder.CreateIndex(
                name: "IX_rolmaestro_IdModuloMaestroFk",
                table: "rolmaestro",
                column: "IdModuloMaestroFk");

            migrationBuilder.CreateIndex(
                name: "IX_rolmaestro_IdRolFk",
                table: "rolmaestro",
                column: "IdRolFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "genericosvssubmodulos");

            migrationBuilder.DropTable(
                name: "rolmaestro");

            migrationBuilder.DropTable(
                name: "maestrovssubmodulo");

            migrationBuilder.DropTable(
                name: "pemrisogenerico");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "modulomaestro");

            migrationBuilder.DropTable(
                name: "submodulo");
        }
    }
}
