using Microsoft.EntityFrameworkCore.Migrations;
using static System.Runtime.InteropServices.JavaScript.JSType;

#nullable disable

namespace Order_Food_Online.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("INSERT INTO [security].[Users]([Id],[UserName],[NormalizedUserName],[Email],[NormalizedEmail],[EmailConfirmed],[PasswordHash],[SecurityStamp],[ConcurrencyStamp],[PhoneNumber],[PhoneNumberConfirmed],[TwoFactorEnabled],[LockoutEnd],[LockoutEnabled],[AccessFailedCount],[Age],[CardNum],[City],[FirstName],[Gender],[LastName],[ProfilePicture]) VALUES(N'0539785c-fb34-4913-9e37-878baf3d1132',N'rehabzaki1712',N'REHABZAKI1712',N'rehabzaki1712@gmail.com',N'REHABZAKI1712@GMAIL.COM',N'False',N'AQAAAAIAAYagAAAAEH+9rao/ImhfHyvcvmZH9IiU06mDZqXGbY0Hna+pKc/1UdWzoLoN3Mq4wE1WaE6rgQ==',N'ZTWUSBJRDUUOQHPIWA7O4EE55K2LWZNA',N'3f767e5f-2d94-4dc3-9a08-48414671bd33',N'01003445978',N'False',N'False',NULL,N'True',0,25,N'1234567',0,N'Hassann',0,N'Hassannn',NULL)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [security].[Users] WHERE Id='0539785c-fb34-4913-9e37-878baf3d1132'");
        }
    }
}
