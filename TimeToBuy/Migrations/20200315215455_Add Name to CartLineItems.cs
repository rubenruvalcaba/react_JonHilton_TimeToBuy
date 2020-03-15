using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeToBuy.Migrations
{
    public partial class AddNametoCartLineItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CartLineItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "CartLineItems");
        }
    }
}
