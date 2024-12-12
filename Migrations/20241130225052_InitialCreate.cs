using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjetoApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_TAREFAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Título = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Observacao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Classe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TAREFAS", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TB_TAREFAS",
                columns: new[] { "Id", "Classe", "Descricao", "Observacao", "Título" },
                values: new object[,]
                {
                    { 1, 2, "Estudar para á prova", "Andamento", "Estudar" },
                    { 2, 3, "Viagem para pesquisa/trabalho da universidade", "Não iniciado", "Viagem" },
                    { 3, 1, "Fazer atividade em grupo na casa da Mariana", "Concluido", "Trablho em grupo" },
                    { 4, 3, "Aniversario de uma amiga", "nao iniciada", "Compromisso" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_TAREFAS");
        }
    }
}
