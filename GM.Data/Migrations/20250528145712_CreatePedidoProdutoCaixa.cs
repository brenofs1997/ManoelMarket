using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GM.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatePedidoProdutoCaixa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Pedidos_PedidoId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_PedidoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Produtos");

            migrationBuilder.AddColumn<string>(
                name: "CaixaId",
                table: "Produtos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Pedido_Id",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Caixas",
                columns: table => new
                {
                    CaixaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caixas", x => x.CaixaId);
                    table.ForeignKey(
                        name: "FK_Caixas_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Pedido_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CaixaId",
                table: "Produtos",
                column: "CaixaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Pedido_Id",
                table: "Produtos",
                column: "Pedido_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Caixas_PedidoId",
                table: "Caixas",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Caixas_CaixaId",
                table: "Produtos",
                column: "CaixaId",
                principalTable: "Caixas",
                principalColumn: "CaixaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Pedidos_Pedido_Id",
                table: "Produtos",
                column: "Pedido_Id",
                principalTable: "Pedidos",
                principalColumn: "Pedido_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Caixas_CaixaId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Pedidos_Pedido_Id",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "Caixas");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_CaixaId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_Pedido_Id",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CaixaId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Pedido_Id",
                table: "Produtos");

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_PedidoId",
                table: "Produtos",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Pedidos_PedidoId",
                table: "Produtos",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Pedido_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
