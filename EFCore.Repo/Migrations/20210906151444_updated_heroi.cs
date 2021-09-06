using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Repo.Migrations
{
    public partial class updated_heroi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IdentidadesSecretas_HeroiId",
                table: "IdentidadesSecretas");

            migrationBuilder.CreateIndex(
                name: "IX_IdentidadesSecretas_HeroiId",
                table: "IdentidadesSecretas",
                column: "HeroiId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IdentidadesSecretas_HeroiId",
                table: "IdentidadesSecretas");

            migrationBuilder.CreateIndex(
                name: "IX_IdentidadesSecretas_HeroiId",
                table: "IdentidadesSecretas",
                column: "HeroiId");
        }
    }
}
