using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheEvent.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NavbarViewModelId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NavbarViewModels",
                columns: table => new
                {
                    NavbarViewModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnreadMessageCount = table.Column<int>(type: "int", nullable: false),
                    UnreadNotificationCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavbarViewModels", x => x.NavbarViewModelId);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iconcolor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRead = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NavbarViewModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notifications_NavbarViewModels_NavbarViewModelId",
                        column: x => x.NavbarViewModelId,
                        principalTable: "NavbarViewModels",
                        principalColumn: "NavbarViewModelId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_NavbarViewModelId",
                table: "Messages",
                column: "NavbarViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_NavbarViewModelId",
                table: "Notifications",
                column: "NavbarViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_NavbarViewModels_NavbarViewModelId",
                table: "Messages",
                column: "NavbarViewModelId",
                principalTable: "NavbarViewModels",
                principalColumn: "NavbarViewModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_NavbarViewModels_NavbarViewModelId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "NavbarViewModels");

            migrationBuilder.DropIndex(
                name: "IX_Messages_NavbarViewModelId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "NavbarViewModelId",
                table: "Messages");
        }
    }
}
