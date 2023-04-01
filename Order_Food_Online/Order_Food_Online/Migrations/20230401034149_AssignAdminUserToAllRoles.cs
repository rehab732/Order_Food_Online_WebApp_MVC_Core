using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Order_Food_Online.Migrations
{
    /// <inheritdoc />
    public partial class AssignAdminUserToAllRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [security].[UserRoles] (UserId,RoleId) SELECT '0539785c-fb34-4913-9e37-878baf3d1132',Id FROM [security].[Roles]");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [security].[UserRoles] WHERE UserId='0539785c-fb34-4913-9e37-878baf3d1132'");

        }
    }
}
