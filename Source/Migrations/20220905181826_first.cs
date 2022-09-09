using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMWebApi.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    user_surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    user_phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    user_email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    user_password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    user_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_isActive = table.Column<bool>(type: "bit", nullable: false),
                    user_confirmed = table.Column<bool>(type: "bit", nullable: false),
                    user_confirmationCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionToken = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    ipAddress = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    session_expiretime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Settlements",
                columns: table => new
                {
                    settle_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    settle_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    settle_city = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    settle_province = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    settle_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    settle_phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    settle_email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    settle_bankIban = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    settle_bankName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settlements", x => x.settle_id);
                    table.ForeignKey(
                        name: "FK_Settlements_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    build_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    build_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    build_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    settle_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.build_id);
                    table.ForeignKey(
                        name: "FK_Buildings_Settlements_settle_id",
                        column: x => x.settle_id,
                        principalTable: "Settlements",
                        principalColumn: "settle_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Buildings_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    req_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    req_title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    req_desc = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    req_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    req_isCompleted = table.Column<bool>(type: "bit", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    settle_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.req_id);
                    table.ForeignKey(
                        name: "FK_Requests_Settlements_settle_id",
                        column: x => x.settle_id,
                        principalTable: "Settlements",
                        principalColumn: "settle_id");
                    table.ForeignKey(
                        name: "FK_Requests_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Flats",
                columns: table => new
                {
                    flat_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    flat_number = table.Column<int>(type: "int", nullable: false),
                    flat_desc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    build_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flats", x => x.flat_id);
                    table.ForeignKey(
                        name: "FK_Flats_Buildings_build_id",
                        column: x => x.build_id,
                        principalTable: "Buildings",
                        principalColumn: "build_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Debts",
                columns: table => new
                {
                    debt_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    debt_amount = table.Column<long>(type: "bigint", nullable: false),
                    debt_duedate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    debt_iscompleted = table.Column<bool>(type: "bit", nullable: false),
                    debt_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    debtFlatIdflat_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debts", x => x.debt_id);
                    table.ForeignKey(
                        name: "FK_Debts_Flats_debtFlatIdflat_id",
                        column: x => x.debtFlatIdflat_id,
                        principalTable: "Flats",
                        principalColumn: "flat_id");
                });

            migrationBuilder.CreateTable(
                name: "FlatUsers",
                columns: table => new
                {
                    rel_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    flat_id = table.Column<long>(type: "bigint", nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    isOwner = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlatUsers", x => x.rel_id);
                    table.ForeignKey(
                        name: "FK_FlatUsers_Flats_flat_id",
                        column: x => x.flat_id,
                        principalTable: "Flats",
                        principalColumn: "flat_id");
                    table.ForeignKey(
                        name: "FK_FlatUsers_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_settle_id",
                table: "Buildings",
                column: "settle_id");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_user_id",
                table: "Buildings",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Debts_debtFlatIdflat_id",
                table: "Debts",
                column: "debtFlatIdflat_id");

            migrationBuilder.CreateIndex(
                name: "IX_Flats_build_id",
                table: "Flats",
                column: "build_id");

            migrationBuilder.CreateIndex(
                name: "IX_FlatUsers_flat_id",
                table: "FlatUsers",
                column: "flat_id");

            migrationBuilder.CreateIndex(
                name: "IX_FlatUsers_user_id",
                table: "FlatUsers",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_settle_id",
                table: "Requests",
                column: "settle_id");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_user_id",
                table: "Requests",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_user_id",
                table: "Sessions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_user_id",
                table: "Settlements",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Debts");

            migrationBuilder.DropTable(
                name: "FlatUsers");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Flats");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Settlements");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
