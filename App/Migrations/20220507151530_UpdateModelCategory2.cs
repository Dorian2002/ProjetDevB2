using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    public partial class UpdateModelCategory2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_category_article_article_id",
                schema: "public",
                table: "category");

            migrationBuilder.DropIndex(
                name: "ix_category_article_id",
                schema: "public",
                table: "category");

            migrationBuilder.DropColumn(
                name: "article_id",
                schema: "public",
                table: "category");

            migrationBuilder.CreateTable(
                name: "articlecategory",
                schema: "public",
                columns: table => new
                {
                    articles_id = table.Column<int>(type: "integer", nullable: false),
                    categories_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_articlecategory", x => new { x.articles_id, x.categories_id });
                    table.ForeignKey(
                        name: "fk_articlecategory_article_articles_id",
                        column: x => x.articles_id,
                        principalSchema: "public",
                        principalTable: "article",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_articlecategory_category_categories_id",
                        column: x => x.categories_id,
                        principalSchema: "public",
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_articlecategory_categories_id",
                schema: "public",
                table: "articlecategory",
                column: "categories_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articlecategory",
                schema: "public");

            migrationBuilder.AddColumn<int>(
                name: "article_id",
                schema: "public",
                table: "category",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_category_article_id",
                schema: "public",
                table: "category",
                column: "article_id");

            migrationBuilder.AddForeignKey(
                name: "fk_category_article_article_id",
                schema: "public",
                table: "category",
                column: "article_id",
                principalSchema: "public",
                principalTable: "article",
                principalColumn: "id");
        }
    }
}
