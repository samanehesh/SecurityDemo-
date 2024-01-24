using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SecurityDemo.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    cityId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cityName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.cityId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    buildingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    cityId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.buildingId);
                    table.ForeignKey(
                        name: "FK_Buildings_Cities_cityId",
                        column: x => x.cityId,
                        principalTable: "Cities",
                        principalColumn: "cityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    roomId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    buildingId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.roomId);
                    table.ForeignKey(
                        name: "FK_Rooms_Buildings_buildingId",
                        column: x => x.buildingId,
                        principalTable: "Buildings",
                        principalColumn: "buildingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "admin-role-id", null, "Admin", "ADMIN" },
                    { "customer-role-id", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "admin-user-id", 0, "656810d5-414f-47c5-a299-e207e86b1f91", "admin@home.com", true, false, null, "ADMIN@HOME.COM", "ADMIN@HOME.COM", "AQAAAAIAAYagAAAAEF4G0QAorXHy/rQGykTIXrUP2Vtz/7sQEKT2MeiYpNzppps3UDWDp3BYGZOG0FyMsg==", null, false, "", false, "admin@home.com" },
                    { "keiko-user-id", 0, "87be3d16-c8c8-4829-a693-4ff9d19e28f9", "keiko@Outlook.com", true, false, null, "KEIKO@OUTLOOK.COM", "KEIKO@OUTLOOK.COM", "AQAAAAIAAYagAAAAEA/AwO52fBiWhyx1J5hW7VkQN4eYBhdm2qFCN1jH2fk7dyaYmZGKbipP0kY8Sw1NyQ==", null, false, "", false, "keiko@Outlook.com" },
                    { "kwame-user-id", 0, "e45ed6ce-411f-49e2-9e4f-726175ae5704", "kwame@aol.com", true, false, null, "KWAME@AOL.COM", "KWAME@AOL.COM", "AQAAAAIAAYagAAAAEA/g53z7wTg6IelpmcmQAt4fSo4HBLOGFDqJ47m/OQH0LlyBev6y1lukanS/2M4XTg==", null, false, "", false, "kwame@aol.com" },
                    { "mateo-user-id", 0, "1425b32e-4e4e-4bf4-896e-cbfddcde0bd6", "mateo@gmail.com", true, false, null, "MATEO@GMAIL.COM", "MATEO@GMAIL.COM", "AQAAAAIAAYagAAAAEGOpmA9k82YqhJvmMncEn96PMW2WniEFuv19PPcW9cWWbzg0YSolCsHK/WJ956EThQ==", null, false, "", false, "mateo@gmail.com" },
                    { "priya-user-id", 0, "c03b192f-569c-42c9-a799-cb999cb65bb9", "priya@yahoo.com", true, false, null, "PRAYA@YAHOO.COM", "PRAYA@YAHOO.COM", "AQAAAAIAAYagAAAAEHAgSvtENApMawbUz6P+N1J3XzhhSjWM5jyhnGoIF9232h/2oibRFmTQNkVCVqfXeA==", null, false, "", false, "priya@yahoo.com" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "cityId", "cityName" },
                values: new object[,]
                {
                    { 1, "Vancouver" },
                    { 2, "Toronto" },
                    { 3, "Montreal" },
                    { 4, "Calgary" },
                    { 5, "Surrey" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "admin-role-id", "admin-user-id" },
                    { "customer-role-id", "keiko-user-id" },
                    { "customer-role-id", "kwame-user-id" },
                    { "customer-role-id", "mateo-user-id" },
                    { "customer-role-id", "priya-user-id" }
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "buildingId", "cityId", "name" },
                values: new object[,]
                {
                    { 1, 1, "Building A" },
                    { 2, 5, "Building B" },
                    { 3, 5, "Building C" },
                    { 4, 1, "Building D" },
                    { 5, 4, "Building E" },
                    { 6, 1, "Building F" },
                    { 7, 4, "Building G" },
                    { 8, 5, "Building H" },
                    { 9, 1, "Building I" },
                    { 10, 4, "Building J" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "roomId", "buildingId", "capacity", "name" },
                values: new object[,]
                {
                    { 1, 1, 22, "Room 101" },
                    { 2, 1, 35, "Room 201" },
                    { 3, 2, 15, "Room 301" },
                    { 4, 3, 55, "Room 151" },
                    { 5, 3, 55, "Room 251" },
                    { 6, 3, 25, "Room 301" },
                    { 7, 4, 12, "Room 101" },
                    { 8, 4, 75, "Room 201" },
                    { 9, 4, 8, "Room 301" },
                    { 10, 4, 21, "Room 312" },
                    { 11, 4, 35, "Room 313" },
                    { 12, 4, 77, "Room 314" },
                    { 13, 5, 75, "Room 401" },
                    { 14, 6, 30, "Room 801" },
                    { 15, 7, 28, "Room 901" },
                    { 16, 8, 55, "Room 551" },
                    { 17, 9, 30, "Room 801" },
                    { 18, 10, 25, "Room 601" },
                    { 19, 10, 21, "Room 701" },
                    { 20, 10, 30, "Room 801" },
                    { 21, 10, 20, "Room 901" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_cityId",
                table: "Buildings",
                column: "cityId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_buildingId",
                table: "Rooms",
                column: "buildingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
