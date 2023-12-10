using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace config_server.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Config",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClusterRadius = table.Column<float>(type: "real", nullable: false),
                    GeoFencing = table.Column<bool>(type: "bit", nullable: false),
                    TimeBuffer = table.Column<float>(type: "real", nullable: false),
                    LocationBuffer = table.Column<float>(type: "real", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    MapType = table.Column<int>(type: "int", nullable: false),
                    MapSubType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Config");
        }
    }
}
