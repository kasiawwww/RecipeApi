using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeApi.Migrations
{
    public partial class foreign_key_category3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Recipes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Recipes",
                maxLength: 100,
                nullable: true);
        }
    }
}
