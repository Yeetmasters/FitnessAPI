using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    password = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    firstname = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    lastname = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    height = table.Column<float>(nullable: false),
                    weight = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.user_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
