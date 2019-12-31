using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Entities.Migrations
{
    public partial class CQRS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Paid",
                table: "orders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Sent",
                table: "orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Paid",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "Sent",
                table: "orders");
        }
    }
}
