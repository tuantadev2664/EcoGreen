using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfrasStructure.Migrations
{
    /// <inheritdoc />
    public partial class addMediaUrlToActivity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MediaUrl",
                table: "Activities",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MediaUrl",
                table: "Activities");
        }
    }
}
