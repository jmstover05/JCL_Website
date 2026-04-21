using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JCL_Website.Migrations
{
    /// <inheritdoc />
    public partial class ShippedOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GiftWrap",
                table: "Orders",
                newName: "Shipped");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Shipped",
                table: "Orders",
                newName: "GiftWrap");
        }
    }
}
