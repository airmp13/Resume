using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changePicToProfilePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "personalInformation",
                newName: "ProfilePicPath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfilePicPath",
                table: "personalInformation",
                newName: "Picture");
        }
    }
}
