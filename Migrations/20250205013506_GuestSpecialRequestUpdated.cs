using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderingSystem.Migrations
{
    /// <inheritdoc />
    public partial class GuestSpecialRequestUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GuestSpecialRequest",
                table: "GuestSpecialRequest");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "GuestSpecialRequest",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "GuestSpecialRequestId",
                table: "GuestSpecialRequest",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GuestSpecialRequest",
                table: "GuestSpecialRequest",
                column: "GuestSpecialRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GuestSpecialRequest",
                table: "GuestSpecialRequest");

            migrationBuilder.DropColumn(
                name: "GuestSpecialRequestId",
                table: "GuestSpecialRequest");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "GuestSpecialRequest",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GuestSpecialRequest",
                table: "GuestSpecialRequest",
                column: "Email");
        }
    }
}
