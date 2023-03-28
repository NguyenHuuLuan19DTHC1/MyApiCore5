using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_Data.Migrations
{
    public partial class Db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dataCSVs",
                columns: table => new
                {
                    number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    journal_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    issn = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    eissn = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    category1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    category2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    category3 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    category4 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    category5 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    category6 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    citations = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    if_2022 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    jci = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    percentageOAGold = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dataCSVs", x => x.number);
                });

            migrationBuilder.CreateTable(
                name: "TemporaryDatas",
                columns: table => new
                {
                    number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    journal_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    issn = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    eissn = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    category1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    category2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    category3 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    category4 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    category5 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    category6 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    citations = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    if_2022 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    jci = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    percentageOAGold = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemporaryDatas", x => x.number);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AccountType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dataCSVs");

            migrationBuilder.DropTable(
                name: "TemporaryDatas");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
