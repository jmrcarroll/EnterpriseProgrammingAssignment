using Microsoft.EntityFrameworkCore.Migrations;

namespace EnterpriseProgrammingAssignment.Migrations
{
    public partial class updateCars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Sites_LocationID",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                table: "Cars",
                newName: "SiteID");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_LocationID",
                table: "Cars",
                newName: "IX_Cars_SiteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Sites_SiteID",
                table: "Cars",
                column: "SiteID",
                principalTable: "Sites",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Sites_SiteID",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "SiteID",
                table: "Cars",
                newName: "LocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_SiteID",
                table: "Cars",
                newName: "IX_Cars_LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Sites_LocationID",
                table: "Cars",
                column: "LocationID",
                principalTable: "Sites",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
