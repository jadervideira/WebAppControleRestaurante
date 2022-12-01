using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppControleRestaurante.Data.Migrations
{
    public partial class criacaodb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PagtoMesaModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<int>(type: "int", nullable: false),
                    NumMesa = table.Column<int>(type: "int", nullable: false),
                    ValConsumo = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagtoMesaModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PagtoMesaModel");
        }
    }
}
