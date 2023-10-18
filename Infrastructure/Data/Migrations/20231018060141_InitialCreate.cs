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
                name: "auditoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreUsuarioAuditoria = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescAccion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auditoria", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "estadonotificacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreEstadoNotificacion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estadonotificacion", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "formato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreFormato = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_formato", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "hilorespuestanotificacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreTipoHilo = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hilorespuestanotificacion", x => x.Id);
                })
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
                name: "radicado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_radicado", x => x.Id);
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
                name: "tiponotificacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreTipoNoti = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tiponotificacion", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tiporequerimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreTipoRequerimiento = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tiporequerimiento", x => x.Id);
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
                name: "blockchain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HashGenerado = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdTipoNotisFk = table.Column<int>(type: "int", nullable: false),
                    IdAuditoriaFk = table.Column<int>(type: "int", nullable: false),
                    IdHiloRespuestaNotiFk = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blockchain", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blockchain_auditoria_IdAuditoriaFk",
                        column: x => x.IdAuditoriaFk,
                        principalTable: "auditoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_blockchain_hilorespuestanotificacion_IdHiloRespuestaNotiFk",
                        column: x => x.IdHiloRespuestaNotiFk,
                        principalTable: "hilorespuestanotificacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_blockchain_tiponotificacion_IdTipoNotisFk",
                        column: x => x.IdTipoNotisFk,
                        principalTable: "tiponotificacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "modulonotificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AsuntoNotificacion = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TextoNotificacion = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdRadicadoFk = table.Column<int>(type: "int", nullable: false),
                    IdFormatoFk = table.Column<int>(type: "int", nullable: false),
                    IdHiloNotiFk = table.Column<int>(type: "int", nullable: false),
                    IdTipoRequerimientoFk = table.Column<int>(type: "int", nullable: false),
                    IdTipoNotisFk = table.Column<int>(type: "int", nullable: false),
                    IdEstadoNotiFk = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modulonotificaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_modulonotificaciones_estadonotificacion_IdEstadoNotiFk",
                        column: x => x.IdEstadoNotiFk,
                        principalTable: "estadonotificacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_modulonotificaciones_formato_IdFormatoFk",
                        column: x => x.IdFormatoFk,
                        principalTable: "formato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_modulonotificaciones_hilorespuestanotificacion_IdHiloNotiFk",
                        column: x => x.IdHiloNotiFk,
                        principalTable: "hilorespuestanotificacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_modulonotificaciones_radicado_IdRadicadoFk",
                        column: x => x.IdRadicadoFk,
                        principalTable: "radicado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_modulonotificaciones_tiponotificacion_IdTipoNotisFk",
                        column: x => x.IdTipoNotisFk,
                        principalTable: "tiponotificacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_modulonotificaciones_tiporequerimiento_IdTipoRequerimientoFk",
                        column: x => x.IdTipoRequerimientoFk,
                        principalTable: "tiporequerimiento",
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
                name: "IX_blockchain_IdAuditoriaFk",
                table: "blockchain",
                column: "IdAuditoriaFk");

            migrationBuilder.CreateIndex(
                name: "IX_blockchain_IdHiloRespuestaNotiFk",
                table: "blockchain",
                column: "IdHiloRespuestaNotiFk");

            migrationBuilder.CreateIndex(
                name: "IX_blockchain_IdTipoNotisFk",
                table: "blockchain",
                column: "IdTipoNotisFk");

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
                name: "IX_modulonotificaciones_IdEstadoNotiFk",
                table: "modulonotificaciones",
                column: "IdEstadoNotiFk");

            migrationBuilder.CreateIndex(
                name: "IX_modulonotificaciones_IdFormatoFk",
                table: "modulonotificaciones",
                column: "IdFormatoFk");

            migrationBuilder.CreateIndex(
                name: "IX_modulonotificaciones_IdHiloNotiFk",
                table: "modulonotificaciones",
                column: "IdHiloNotiFk");

            migrationBuilder.CreateIndex(
                name: "IX_modulonotificaciones_IdRadicadoFk",
                table: "modulonotificaciones",
                column: "IdRadicadoFk");

            migrationBuilder.CreateIndex(
                name: "IX_modulonotificaciones_IdTipoNotisFk",
                table: "modulonotificaciones",
                column: "IdTipoNotisFk");

            migrationBuilder.CreateIndex(
                name: "IX_modulonotificaciones_IdTipoRequerimientoFk",
                table: "modulonotificaciones",
                column: "IdTipoRequerimientoFk");

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
                name: "blockchain");

            migrationBuilder.DropTable(
                name: "genericosvssubmodulos");

            migrationBuilder.DropTable(
                name: "modulonotificaciones");

            migrationBuilder.DropTable(
                name: "rolmaestro");

            migrationBuilder.DropTable(
                name: "auditoria");

            migrationBuilder.DropTable(
                name: "maestrovssubmodulo");

            migrationBuilder.DropTable(
                name: "pemrisogenerico");

            migrationBuilder.DropTable(
                name: "estadonotificacion");

            migrationBuilder.DropTable(
                name: "formato");

            migrationBuilder.DropTable(
                name: "hilorespuestanotificacion");

            migrationBuilder.DropTable(
                name: "radicado");

            migrationBuilder.DropTable(
                name: "tiponotificacion");

            migrationBuilder.DropTable(
                name: "tiporequerimiento");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "modulomaestro");

            migrationBuilder.DropTable(
                name: "submodulo");
        }
    }
}
