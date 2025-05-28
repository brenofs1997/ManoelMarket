using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GM.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatePedidoProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Dimensoes_DimensoesId",
                table: "Produto");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Pedidos_PedidoId",
                table: "Produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produto",
                table: "Produto");

            migrationBuilder.RenameTable(
                name: "Produto",
                newName: "Produtos");

            migrationBuilder.RenameIndex(
                name: "IX_Produto_PedidoId",
                table: "Produtos",
                newName: "IX_Produtos_PedidoId");

            migrationBuilder.RenameIndex(
                name: "IX_Produto_DimensoesId",
                table: "Produtos",
                newName: "IX_Produtos_DimensoesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "Produto_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Dimensoes_DimensoesId",
                table: "Produtos",
                column: "DimensoesId",
                principalTable: "Dimensoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Pedidos_PedidoId",
                table: "Produtos",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Pedido_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Dimensoes_DimensoesId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Pedidos_PedidoId",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "Produto");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_PedidoId",
                table: "Produto",
                newName: "IX_Produto_PedidoId");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_DimensoesId",
                table: "Produto",
                newName: "IX_Produto_DimensoesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produto",
                table: "Produto",
                column: "Produto_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Dimensoes_DimensoesId",
                table: "Produto",
                column: "DimensoesId",
                principalTable: "Dimensoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Pedidos_PedidoId",
                table: "Produto",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Pedido_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
