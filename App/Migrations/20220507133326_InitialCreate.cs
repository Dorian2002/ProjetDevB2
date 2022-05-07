using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace App.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "applicationrole",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_applicationrole", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "applicationuser",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: true),
                    security_stamp = table.Column<string>(type: "text", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    access_failed_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_applicationuser", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "identityroleclaim<int>",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identityroleclaim_int", x => x.id);
                    table.ForeignKey(
                        name: "fk_identityroleclaim_int_applicationrole_role_id",
                        column: x => x.role_id,
                        principalSchema: "public",
                        principalTable: "applicationrole",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identityuserclaim<int>",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identityuserclaim_int", x => x.id);
                    table.ForeignKey(
                        name: "fk_identityuserclaim_int_applicationuser_user_id",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "applicationuser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identityuserlogin<int>",
                schema: "public",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    provider_key = table.Column<string>(type: "text", nullable: false),
                    provider_display_name = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identityuserlogin_int", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_identityuserlogin_int_applicationuser_user_id",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "applicationuser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identityuserrole<int>",
                schema: "public",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identityuserrole_int", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_identityuserrole_int_applicationrole_role_id",
                        column: x => x.role_id,
                        principalSchema: "public",
                        principalTable: "applicationrole",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_identityuserrole_int_applicationuser_user_id",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "applicationuser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "identityusertoken<int>",
                schema: "public",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identityusertoken_int", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_identityusertoken_int_applicationuser_user_id",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "applicationuser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "public",
                table: "applicationrole",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "public",
                table: "applicationuser",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "public",
                table: "applicationuser",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_identityroleclaim_int_role_id",
                schema: "public",
                table: "identityroleclaim<int>",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_identityuserclaim_int_user_id",
                schema: "public",
                table: "identityuserclaim<int>",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_identityuserlogin_int_user_id",
                schema: "public",
                table: "identityuserlogin<int>",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_identityuserrole_int_role_id",
                schema: "public",
                table: "identityuserrole<int>",
                column: "role_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "identityroleclaim<int>",
                schema: "public");

            migrationBuilder.DropTable(
                name: "identityuserclaim<int>",
                schema: "public");

            migrationBuilder.DropTable(
                name: "identityuserlogin<int>",
                schema: "public");

            migrationBuilder.DropTable(
                name: "identityuserrole<int>",
                schema: "public");

            migrationBuilder.DropTable(
                name: "identityusertoken<int>",
                schema: "public");

            migrationBuilder.DropTable(
                name: "applicationrole",
                schema: "public");

            migrationBuilder.DropTable(
                name: "applicationuser",
                schema: "public");
        }
    }
}
