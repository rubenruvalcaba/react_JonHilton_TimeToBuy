﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeToBuy.Migrations
{
    public partial class AddPricetoCartLineItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "CartLineItems",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "CartLineItems");
        }
    }
}
