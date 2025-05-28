using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GM.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatePedidoProdutoTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dimensoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Altura = table.Column<int>(type: "int", nullable: false),
                    Largura = table.Column<int>(type: "int", nullable: false),
                    Comprimento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimensoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Pedido_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Pedido_Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Produto_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DimensoesId = table.Column<int>(type: "int", nullable: false),
                    Observacao = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Produto_Id);
                    table.ForeignKey(
                        name: "FK_Produto_Dimensoes_DimensoesId",
                        column: x => x.DimensoesId,
                        principalTable: "Dimensoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produto_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Pedido_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_DimensoesId",
                table: "Produto",
                column: "DimensoesId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_PedidoId",
                table: "Produto",
                column: "PedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Dimensoes");

            migrationBuilder.DropTable(
                name: "Pedidos");
        }
    }
}
