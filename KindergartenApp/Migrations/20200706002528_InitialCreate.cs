using Microsoft.EntityFrameworkCore.Migrations;

namespace KindergartenApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kindergartens",
                columns: table => new
                {
                    KindergartenId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KindergartenName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Capacity = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kindergartens", x => x.KindergartenId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    ChildId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Characterization = table.Column<string>(nullable: true),
                    Age = table.Column<double>(nullable: false),
                    Height = table.Column<long>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    ChildrenGroup = table.Column<int>(nullable: false),
                    KindergartenID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.ChildId);
                    table.ForeignKey(
                        name: "FK_Children_Kindergartens_KindergartenID",
                        column: x => x.KindergartenID,
                        principalTable: "Kindergartens",
                        principalColumn: "KindergartenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserKindergartens",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    KindergardenId = table.Column<long>(nullable: false),
                    UserId1 = table.Column<int>(nullable: true),
                    KindergartenId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserKindergartens", x => new { x.UserId, x.KindergardenId });
                    table.ForeignKey(
                        name: "FK_UserKindergartens_Kindergartens_KindergartenId",
                        column: x => x.KindergartenId,
                        principalTable: "Kindergartens",
                        principalColumn: "KindergartenId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserKindergartens_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Children_KindergartenID",
                table: "Children",
                column: "KindergartenID");

            migrationBuilder.CreateIndex(
                name: "IX_UserKindergartens_KindergartenId",
                table: "UserKindergartens",
                column: "KindergartenId");

            migrationBuilder.CreateIndex(
                name: "IX_UserKindergartens_UserId1",
                table: "UserKindergartens",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "UserKindergartens");

            migrationBuilder.DropTable(
                name: "Kindergartens");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
