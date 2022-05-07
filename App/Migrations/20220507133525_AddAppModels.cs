using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace App.Migrations
{
    public partial class AddAppModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "article",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    seller_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    location = table.Column<string>(type: "text", nullable: false),
                    creation_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_article", x => x.id);
                    table.ForeignKey(
                        name: "fk_article_applicationuser_seller_id",
                        column: x => x.seller_id,
                        principalSchema: "public",
                        principalTable: "applicationuser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chat",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_chat", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "favourite",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    article_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_favourite", x => x.id);
                    table.ForeignKey(
                        name: "fk_favourite_applicationuser_user_id",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "applicationuser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "message",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_message", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cart",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    article_id = table.Column<int>(type: "integer", nullable: false),
                    add_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cart", x => x.id);
                    table.ForeignKey(
                        name: "fk_cart_applicationuser_user_id",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "applicationuser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_cart_article_article_id",
                        column: x => x.article_id,
                        principalSchema: "public",
                        principalTable: "article",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "category",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    article_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category", x => x.id);
                    table.ForeignKey(
                        name: "fk_category_article_article_id",
                        column: x => x.article_id,
                        principalSchema: "public",
                        principalTable: "article",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_article_seller_id",
                schema: "public",
                table: "article",
                column: "seller_id");

            migrationBuilder.CreateIndex(
                name: "ix_cart_article_id",
                schema: "public",
                table: "cart",
                column: "article_id");

            migrationBuilder.CreateIndex(
                name: "ix_cart_user_id",
                schema: "public",
                table: "cart",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_category_article_id",
                schema: "public",
                table: "category",
                column: "article_id");

            migrationBuilder.CreateIndex(
                name: "ix_favourite_user_id",
                schema: "public",
                table: "favourite",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cart",
                schema: "public");

            migrationBuilder.DropTable(
                name: "category",
                schema: "public");

            migrationBuilder.DropTable(
                name: "chat",
                schema: "public");

            migrationBuilder.DropTable(
                name: "favourite",
                schema: "public");

            migrationBuilder.DropTable(
                name: "message",
                schema: "public");

            migrationBuilder.DropTable(
                name: "article",
                schema: "public");
        }
    }
}
