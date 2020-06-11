using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste_Piloto.Server.Migrations
{
    public partial class PrimeiraMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chefias",
                columns: table => new
                {
                    ChefiaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeChefia = table.Column<string>(nullable: false),
                    Setor = table.Column<string>(nullable: false),
                    FuncionarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chefias", x => x.ChefiaId);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id_Curso = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCurso = table.Column<string>(maxLength: 60, nullable: false),
                    ValorCurso = table.Column<decimal>(nullable: false),
                    ProfessorCurso = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id_Curso);
                });

            migrationBuilder.CreateTable(
                name: "Finaiceiros",
                columns: table => new
                {
                    FinanceiroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finaiceiros", x => x.FinanceiroId);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    Rg = table.Column<string>(maxLength: 9, nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false),
                    Datanascimento = table.Column<DateTime>(nullable: false),
                    DataInicioCurso = table.Column<DateTime>(nullable: false),
                    DataTerminoCurso = table.Column<DateTime>(nullable: true),
                    Genero = table.Column<string>(maxLength: 9, nullable: false),
                    CursosId = table.Column<int>(nullable: false),
                    CursoId_Curso = table.Column<int>(nullable: true),
                    FinanceiroId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.AlunoId);
                    table.ForeignKey(
                        name: "FK_Alunos_Cursos_CursoId_Curso",
                        column: x => x.CursoId_Curso,
                        principalTable: "Cursos",
                        principalColumn: "Id_Curso",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alunos_Finaiceiros_FinanceiroId",
                        column: x => x.FinanceiroId,
                        principalTable: "Finaiceiros",
                        principalColumn: "FinanceiroId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFuncionario = table.Column<string>(maxLength: 60, nullable: false),
                    Rg = table.Column<string>(maxLength: 9, nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false),
                    Datanascimento = table.Column<DateTime>(nullable: false),
                    DataContratacao = table.Column<DateTime>(nullable: false),
                    DataDemissao = table.Column<DateTime>(nullable: true),
                    Genero = table.Column<string>(maxLength: 9, nullable: false),
                    SalarioFuncionario = table.Column<decimal>(nullable: false),
                    Funcionario = table.Column<int>(nullable: true),
                    FinanceiroId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Finaiceiros_FinanceiroId",
                        column: x => x.FinanceiroId,
                        principalTable: "Finaiceiros",
                        principalColumn: "FinanceiroId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Chefias_Funcionario",
                        column: x => x.Funcionario,
                        principalTable: "Chefias",
                        principalColumn: "ChefiaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id_Email = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _Email = table.Column<string>(nullable: false),
                    AlunoId = table.Column<int>(nullable: false),
                    ChefiaId = table.Column<int>(nullable: false),
                    FuncionarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id_Email);
                    table.ForeignKey(
                        name: "FK_Emails_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "AlunoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emails_Chefias_ChefiaId",
                        column: x => x.ChefiaId,
                        principalTable: "Chefias",
                        principalColumn: "ChefiaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emails_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    TelefoneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelefoneNumber = table.Column<string>(nullable: false),
                    AlunoId = table.Column<int>(nullable: false),
                    FuncionarioId = table.Column<int>(nullable: false),
                    ChefiaId = table.Column<int>(nullable: false),
                    Telefone = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.TelefoneId);
                    table.ForeignKey(
                        name: "FK_Telefones_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "AlunoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Telefones_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Telefones_Chefias_Telefone",
                        column: x => x.Telefone,
                        principalTable: "Chefias",
                        principalColumn: "ChefiaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_CursoId_Curso",
                table: "Alunos",
                column: "CursoId_Curso");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_FinanceiroId",
                table: "Alunos",
                column: "FinanceiroId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_AlunoId",
                table: "Emails",
                column: "AlunoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emails_ChefiaId",
                table: "Emails",
                column: "ChefiaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emails_FuncionarioId",
                table: "Emails",
                column: "FuncionarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_FinanceiroId",
                table: "Funcionarios",
                column: "FinanceiroId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_Funcionario",
                table: "Funcionarios",
                column: "Funcionario");

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_AlunoId",
                table: "Telefones",
                column: "AlunoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_FuncionarioId",
                table: "Telefones",
                column: "FuncionarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_Telefone",
                table: "Telefones",
                column: "Telefone",
                unique: true,
                filter: "[Telefone] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Finaiceiros");

            migrationBuilder.DropTable(
                name: "Chefias");
        }
    }
}
