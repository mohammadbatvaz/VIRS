using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VIRS.Infra.DataBase.EFCoreSqlServer.Migrations
{
    /// <inheritdoc />
    public partial class AddTrackingNumberIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TrackingNumber",
                table: "InspectionRequests",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionRequests_TrackingNumber",
                table: "InspectionRequests",
                column: "TrackingNumber",
                unique: true,
                filter: "[TrackingNumber] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InspectionRequests_TrackingNumber",
                table: "InspectionRequests");

            migrationBuilder.AlterColumn<string>(
                name: "TrackingNumber",
                table: "InspectionRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
