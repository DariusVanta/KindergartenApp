using Microsoft.EntityFrameworkCore.Migrations;

namespace KindergartenApp.Migrations.ChildrenDb
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Characterization = table.Column<string>(nullable: true),
                    Age = table.Column<double>(nullable: false),
                    Height = table.Column<long>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    ChildrenGroup = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Children");
        }
    }
}
