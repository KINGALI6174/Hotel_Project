using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Infrastructuer.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableFirstBaner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FirstBaners",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    banerTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    banerBotton = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstBaners", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FirstBaners");
        }
    }
}
