using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    public partial class Cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cart_article_article_id",
                schema: "public",
                table: "cart");

            migrationBuilder.DropIndex(
                name: "ix_cart_article_id",
                schema: "public",
                table: "cart");

            migrationBuilder.DropColumn(
                name: "article_id",
                schema: "public",
                table: "cart");

            migrationBuilder.AlterColumn<DateTime>(
                name: "add_date",
                schema: "public",
                table: "cart",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "creation_date",
                schema: "public",
                table: "article",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<int>(
                name: "cart_id",
                schema: "public",
                table: "article",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_article_cart_id",
                schema: "public",
                table: "article",
                column: "cart_id");

            migrationBuilder.AddForeignKey(
                name: "fk_article_carts_cart_id",
                schema: "public",
                table: "article",
                column: "cart_id",
                principalSchema: "public",
                principalTable: "cart",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_article_carts_cart_id",
                schema: "public",
                table: "article");

            migrationBuilder.DropIndex(
                name: "ix_article_cart_id",
                schema: "public",
                table: "article");

            migrationBuilder.DropColumn(
                name: "cart_id",
                schema: "public",
                table: "article");

            migrationBuilder.AlterColumn<DateTime>(
                name: "add_date",
                schema: "public",
                table: "cart",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<int>(
                name: "article_id",
                schema: "public",
                table: "cart",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "creation_date",
                schema: "public",
                table: "article",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.CreateIndex(
                name: "ix_cart_article_id",
                schema: "public",
                table: "cart",
                column: "article_id");

            migrationBuilder.AddForeignKey(
                name: "fk_cart_article_article_id",
                schema: "public",
                table: "cart",
                column: "article_id",
                principalSchema: "public",
                principalTable: "article",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
