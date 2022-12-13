using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SO.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangePKTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_AspNetUsers_ChangedById",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_AspNetUsers_CreatedById",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Tickets");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_CreatedById",
                table: "Tickets",
                newName: "IX_Tickets_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_ChangedById",
                table: "Tickets",
                newName: "IX_Tickets_ChangedById");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "AspNetUserTokens",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<long>(
                name: "RoleId",
                table: "AspNetUserRoles",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "AspNetUserRoles",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "AspNetUserLogins",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "AspNetUserClaims",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AspNetRoles",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<long>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Protocol",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "Tickets",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ChangedById",
                table: "Tickets",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Protocol",
                table: "Tickets",
                column: "Protocol",
                unique: true,
                filter: "[Protocol] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_ChangedById",
                table: "Tickets",
                column: "ChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_CreatedById",
                table: "Tickets",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_ChangedById",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_CreatedById",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_Protocol",
                table: "Tickets");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Ticket");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_CreatedById",
                table: "Ticket",
                newName: "IX_Ticket_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_ChangedById",
                table: "Ticket",
                newName: "IX_Ticket_ChangedById");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserTokens",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "AspNetUserRoles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserRoles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserLogins",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserClaims",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "AspNetRoles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Protocol",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedById",
                table: "Ticket",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ChangedById",
                table: "Ticket",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_AspNetUsers_ChangedById",
                table: "Ticket",
                column: "ChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_AspNetUsers_CreatedById",
                table: "Ticket",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
