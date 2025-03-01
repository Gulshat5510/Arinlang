﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Export_Word : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageForShare",
                table: "Words",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageForShare",
                table: "Words");
        }
    }
}
