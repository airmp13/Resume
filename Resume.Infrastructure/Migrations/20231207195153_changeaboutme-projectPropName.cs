using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeaboutmeprojectPropName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "img",
                table: "projects",
                newName: "PicPath");

            migrationBuilder.RenameColumn(
                name: "Title2_img",
                table: "aboutMe",
                newName: "Title2_PicPath");

            migrationBuilder.RenameColumn(
                name: "Title1_img",
                table: "aboutMe",
                newName: "Title1_PicPath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PicPath",
                table: "projects",
                newName: "img");

            migrationBuilder.RenameColumn(
                name: "Title2_PicPath",
                table: "aboutMe",
                newName: "Title2_img");

            migrationBuilder.RenameColumn(
                name: "Title1_PicPath",
                table: "aboutMe",
                newName: "Title1_img");
        }
    }
}
