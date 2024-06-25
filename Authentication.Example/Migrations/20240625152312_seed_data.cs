using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Authentication.Example.Migrations
{
    /// <inheritdoc />
    public partial class seed_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3a54c9c8-be16-4ed7-8a7b-ecde04982d3e", "793c19f6-ef17-4dd8-a5a4-8fabe422066e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8666ad74-d09d-441f-8219-1ca16f6abc40", "793c19f6-ef17-4dd8-a5a4-8fabe422066e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3a54c9c8-be16-4ed7-8a7b-ecde04982d3e", "bf6c48d4-2fdd-477b-b7ac-147eff504786" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a54c9c8-be16-4ed7-8a7b-ecde04982d3e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8666ad74-d09d-441f-8219-1ca16f6abc40");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "793c19f6-ef17-4dd8-a5a4-8fabe422066e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bf6c48d4-2fdd-477b-b7ac-147eff504786");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "87999f0e-cc7e-462d-b20f-5d64a37f7542", null, "Moderator", "MODERATOR" },
                    { "f9c9577f-5def-4ac4-a131-f2182bd315b3", null, "Administrator", "ADMİNİSTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "79e073b6-2b9e-4a0c-aa66-586ef8e255ae", 0, "1877cc8c-9547-41bf-b96d-cd9c5c2f7757", "administrator@example.com", true, false, null, "ADMINISTRATOR@EXAMPLE.COM", "ADMINISTRATOR", "AQAAAAIAAYagAAAAEMOMirkbQVgmYWkqlBnVF80JitszpC/vHeAnsxfXkLKqvaBU7/U/FvdiNVRBNgRsIA==", null, false, "b80f096f-46bd-45f6-a7c1-e2e5f55d941b", false, "Administrator" },
                    { "f4c556e0-8dcf-4f22-9d56-526279be8c11", 0, "f1f0e801-db2c-4ccf-a89b-b4e0e10410fd", "moderator@example.com", true, false, null, "MODERATOR@EXAMPLE.COM", "MODERATOR", "AQAAAAIAAYagAAAAEF13bnbFx1PvRkM7qUMVzpcsOTTYqRSe6Y4IuWHyJ2WSFOXRa3/1tZm0WG6fPhuN6g==", null, false, "e3c0c417-068d-4f6d-9459-7b4580394102", false, "Moderator" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "87999f0e-cc7e-462d-b20f-5d64a37f7542", "79e073b6-2b9e-4a0c-aa66-586ef8e255ae" },
                    { "f9c9577f-5def-4ac4-a131-f2182bd315b3", "79e073b6-2b9e-4a0c-aa66-586ef8e255ae" },
                    { "87999f0e-cc7e-462d-b20f-5d64a37f7542", "f4c556e0-8dcf-4f22-9d56-526279be8c11" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "87999f0e-cc7e-462d-b20f-5d64a37f7542", "79e073b6-2b9e-4a0c-aa66-586ef8e255ae" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f9c9577f-5def-4ac4-a131-f2182bd315b3", "79e073b6-2b9e-4a0c-aa66-586ef8e255ae" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "87999f0e-cc7e-462d-b20f-5d64a37f7542", "f4c556e0-8dcf-4f22-9d56-526279be8c11" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87999f0e-cc7e-462d-b20f-5d64a37f7542");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9c9577f-5def-4ac4-a131-f2182bd315b3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "79e073b6-2b9e-4a0c-aa66-586ef8e255ae");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f4c556e0-8dcf-4f22-9d56-526279be8c11");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a54c9c8-be16-4ed7-8a7b-ecde04982d3e", null, "Moderator", "MODERATOR" },
                    { "8666ad74-d09d-441f-8219-1ca16f6abc40", null, "Administrator", "ADMİNİSTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "793c19f6-ef17-4dd8-a5a4-8fabe422066e", 0, "33fe9552-2695-473d-a3ee-e4d57328a0d5", "testadministrator@example.com", true, false, null, "TESTADMINISTRATOR@EXAMPLE.COM", "TESTADMINISTRATOR", "AQAAAAIAAYagAAAAEHcnWX5oP44ttBi4+e7Pkf5cVqHM8zcVQmWZbkDqcOo5emudDXcPZU4GPqHsO/hahg==", null, false, "077e3d78-39c7-4a69-9ab9-6ead7913dc85", false, "TestAdministrator" },
                    { "bf6c48d4-2fdd-477b-b7ac-147eff504786", 0, "8855359a-b778-4dc3-afd9-591ac4d7a6ee", "testmoderator@example.com", true, false, null, "TESTMODERATOR@EXAMPLE.COM", "TESTMODERATOR", "AQAAAAIAAYagAAAAEAznzzfa76JptJSMzOonUumwexF/IliirsQ/foIQlgIKKvvnTi74u7JJ3UJ6OcwOzw==", null, false, "e23bca32-d233-48ac-8524-9dbd17739d86", false, "TestModerator" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "3a54c9c8-be16-4ed7-8a7b-ecde04982d3e", "793c19f6-ef17-4dd8-a5a4-8fabe422066e" },
                    { "8666ad74-d09d-441f-8219-1ca16f6abc40", "793c19f6-ef17-4dd8-a5a4-8fabe422066e" },
                    { "3a54c9c8-be16-4ed7-8a7b-ecde04982d3e", "bf6c48d4-2fdd-477b-b7ac-147eff504786" }
                });
        }
    }
}
