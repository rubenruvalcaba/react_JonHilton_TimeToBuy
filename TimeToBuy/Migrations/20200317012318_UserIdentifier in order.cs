using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeToBuy.Migrations
{
    public partial class UserIdentifierinorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserIdentifier",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserIdentifier",
                table: "Orders");
        }
    }
}
