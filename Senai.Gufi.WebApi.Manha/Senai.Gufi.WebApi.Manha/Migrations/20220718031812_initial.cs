using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Senai.Gufi.WebApi.Manha.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    IdGenero = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.IdGenero);
                });

            migrationBuilder.CreateTable(
                name: "Instituicao",
                columns: table => new
                {
                    IdInstituicao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CNPJ = table.Column<string>(unicode: false, maxLength: 14, nullable: false),
                    NomeFantasia = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Endereco = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicao", x => x.IdInstituicao);
                });

            migrationBuilder.CreateTable(
                name: "TipoEvento",
                columns: table => new
                {
                    IdTipoEvento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TituloTipoEvento = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEvento", x => x.IdTipoEvento);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    IdTipoUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TituloTipoUsuario = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.IdTipoUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    IdFilme = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    IdGenero = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.IdFilme);
                    table.ForeignKey(
                        name: "FK__Filmes__IdGenero__19DFD96B",
                        column: x => x.IdGenero,
                        principalTable: "Generos",
                        principalColumn: "IdGenero",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    IdEvento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeEvento = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    DataEvento = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    AcessoLivre = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IdInstituicao = table.Column<int>(nullable: true),
                    IdTipoEvento = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.IdEvento);
                    table.ForeignKey(
                        name: "FK__Evento__IdInstit__693CA210",
                        column: x => x.IdInstituicao,
                        principalTable: "Instituicao",
                        principalColumn: "IdInstituicao",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Evento__IdTipoEv__6A30C649",
                        column: x => x.IdTipoEvento,
                        principalTable: "TipoEvento",
                        principalColumn: "IdTipoEvento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeUsuario = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Senha = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: true),
                    Genero = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    IdTipousuario = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK__Usuario__IdTipou__4316F928",
                        column: x => x.IdTipousuario,
                        principalTable: "TipoUsuario",
                        principalColumn: "IdTipoUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Presenca",
                columns: table => new
                {
                    IdPresenca = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdUsuario = table.Column<int>(nullable: true),
                    IdEvento = table.Column<int>(nullable: true),
                    Situacao = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presenca", x => x.IdPresenca);
                    table.ForeignKey(
                        name: "FK__Presenca__IdEven__6E01572D",
                        column: x => x.IdEvento,
                        principalTable: "Evento",
                        principalColumn: "IdEvento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Presenca__IdUsua__6D0D32F4",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evento_IdInstituicao",
                table: "Evento",
                column: "IdInstituicao");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_IdTipoEvento",
                table: "Evento",
                column: "IdTipoEvento");

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_IdGenero",
                table: "Filmes",
                column: "IdGenero");

            migrationBuilder.CreateIndex(
                name: "UQ__Filmes__7B406B563051A64A",
                table: "Filmes",
                column: "Titulo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Generos__7D8FE3B27DA425AE",
                table: "Generos",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Institui__AA57D6B4A0D8C4A9",
                table: "Instituicao",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Institui__4DF3E1FFEB31E649",
                table: "Instituicao",
                column: "Endereco",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Institui__F5389F316511E1BD",
                table: "Instituicao",
                column: "NomeFantasia",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Presenca_IdEvento",
                table: "Presenca",
                column: "IdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_Presenca_IdUsuario",
                table: "Presenca",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "UQ__TipoEven__40023AD22E845A9E",
                table: "TipoEvento",
                column: "TituloTipoEvento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__TipoUsua__37BBE07EE206D0FA",
                table: "TipoUsuario",
                column: "TituloTipoUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Usuario__A9D105340E1BBF9E",
                table: "Usuario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdTipousuario",
                table: "Usuario",
                column: "IdTipousuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmes");

            migrationBuilder.DropTable(
                name: "Presenca");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Instituicao");

            migrationBuilder.DropTable(
                name: "TipoEvento");

            migrationBuilder.DropTable(
                name: "TipoUsuario");
        }
    }
}
