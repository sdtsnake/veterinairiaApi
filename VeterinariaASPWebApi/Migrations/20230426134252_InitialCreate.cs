using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VeterinariaASPWebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "colaboradores_id_seq",
                maxValue: 9999L);

            migrationBuilder.CreateSequence(
                name: "detalles_historias_clinicas_id_seq",
                maxValue: 9999L);

            migrationBuilder.CreateSequence(
                name: "historias_clinicas_id_seq",
                maxValue: 9999L);

            migrationBuilder.CreateSequence(
                name: "mascotas_id_seq",
                maxValue: 9999L);

            migrationBuilder.CreateSequence(
                name: "usuarios_id_seq",
                maxValue: 9999L);

            migrationBuilder.CreateTable(
                name: "colaboradores",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    cargo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    especialidad = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    tipo_documento = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    documento_identificacion = table.Column<int>(type: "integer", nullable: true),
                    apellido = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("colaboradores_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    apellido = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    tipo_documento = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    documento_identificacion = table.Column<int>(type: "integer", nullable: true),
                    estado = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    sexo = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("usuario_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mascotas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    raza = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    usuario_id = table.Column<int>(type: "integer", nullable: true),
                    sexo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("macotas_pkey", x => x.id);
                    table.ForeignKey(
                        name: "macotas_usuario_id_fkey",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "historias_clinicas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mascota_id = table.Column<int>(type: "integer", nullable: true),
                    fecha_creacion = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("historias_clinicas_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_historia_clinica_mascotas",
                        column: x => x.mascota_id,
                        principalTable: "mascotas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "detalles_historias_clinicas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    temperatura = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    peso = table.Column<float>(type: "real", nullable: true),
                    frecuencia_cardiaca = table.Column<float>(type: "real", nullable: true),
                    frecuencia_respiratoria = table.Column<float>(type: "real", nullable: true),
                    fecha_hora = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    alimentacion = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    habitad = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    observacion = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    colaborador_id = table.Column<int>(type: "integer", nullable: true),
                    historia_clinica_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("detalles_historias_clinicas_pkey", x => x.id);
                    table.ForeignKey(
                        name: "detalles_historias_clinicas_colaborador_id_fkey",
                        column: x => x.colaborador_id,
                        principalTable: "colaboradores",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "detalles_historias_clinicas_historia_clinica_id_fkey",
                        column: x => x.historia_clinica_id,
                        principalTable: "historias_clinicas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_detalles_historias_clinicas_colaborador_id",
                table: "detalles_historias_clinicas",
                column: "colaborador_id");

            migrationBuilder.CreateIndex(
                name: "IX_detalles_historias_clinicas_historia_clinica_id",
                table: "detalles_historias_clinicas",
                column: "historia_clinica_id");

            migrationBuilder.CreateIndex(
                name: "IX_historias_clinicas_mascota_id",
                table: "historias_clinicas",
                column: "mascota_id");

            migrationBuilder.CreateIndex(
                name: "IX_mascotas_usuario_id",
                table: "mascotas",
                column: "usuario_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalles_historias_clinicas");

            migrationBuilder.DropTable(
                name: "colaboradores");

            migrationBuilder.DropTable(
                name: "historias_clinicas");

            migrationBuilder.DropTable(
                name: "mascotas");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropSequence(
                name: "colaboradores_id_seq");

            migrationBuilder.DropSequence(
                name: "detalles_historias_clinicas_id_seq");

            migrationBuilder.DropSequence(
                name: "historias_clinicas_id_seq");

            migrationBuilder.DropSequence(
                name: "mascotas_id_seq");

            migrationBuilder.DropSequence(
                name: "usuarios_id_seq");
        }
    }
}
