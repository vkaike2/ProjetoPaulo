using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoPaulo.Data.Migrations
{
    public partial class tabelaExemplo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_exemplo",
                columns: table => new
                {
                    ex_id = table.Column<Guid>(nullable: false),
                    ex_descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tb_exemplo", x => x.ex_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_exemplo");
        }
    }
}
