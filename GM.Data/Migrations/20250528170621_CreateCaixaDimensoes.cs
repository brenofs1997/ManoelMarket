using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GM.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateCaixaDimensoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Caixas_CaixaId",
                table: "Produtos");

            migrationBuilder.AlterColumn<string>(
                name: "CaixaId",
                table: "Produtos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "DimensoesId",
                table: "Caixas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Caixas_DimensoesId",
                table: "Caixas",
                column: "DimensoesId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Caixas_Dimensoes_DimensoesId",
                table: "Caixas",
                column: "DimensoesId",
                principalTable: "Dimensoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Caixas_CaixaId",
                table: "Produtos",
                column: "CaixaId",
                principalTable: "Caixas",
                principalColumn: "CaixaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caixas_Dimensoes_DimensoesId",
                table: "Caixas");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Caixas_CaixaId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Caixas_DimensoesId",
                table: "Caixas");

            migrationBuilder.DropColumn(
                name: "DimensoesId",
                table: "Caixas");

            migrationBuilder.AlterColumn<string>(
                name: "CaixaId",
                table: "Produtos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Caixas_CaixaId",
                table: "Produtos",
                column: "CaixaId",
                principalTable: "Caixas",
                principalColumn: "CaixaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
