using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Order_Food_Online.Migrations
{
    /// <inheritdoc />
    public partial class editcustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId1",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomersId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId1",
                table: "Orders",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomersId",
                table: "Orders",
                column: "CustomersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomersId",
                table: "Orders",
                column: "CustomersId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_CustomerId1",
                table: "Orders",
                column: "CustomerId1",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomersId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_CustomerId1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomersId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomersId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
