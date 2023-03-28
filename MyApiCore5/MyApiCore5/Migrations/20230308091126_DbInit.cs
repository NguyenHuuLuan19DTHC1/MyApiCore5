using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyApiCore5.Migrations
{
    public partial class DbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    IDAdmin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.IDAdmin);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietChungNhans",
                columns: table => new
                {
                    IDChiTietChungNhan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SoQuyetDinhOnline = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SoQuyetDinhOffline = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgayCapOnline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayCapOffline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MSSV = table.Column<int>(type: "int", nullable: false),
                    IDTrangThaiDuyet = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IDChungNhan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IDAdmin1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IDAdmin2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IDAmin3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietChungNhans", x => x.IDChiTietChungNhan);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietQuyenAdmins",
                columns: table => new
                {
                    IDAdmin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IDQuyen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TrangThai = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietQuyenAdmins", x => x.IDAdmin);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietQuyenSinhViens",
                columns: table => new
                {
                    MSSV = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IDQuyen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TrangThai = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietQuyenSinhViens", x => x.MSSV);
                });

            migrationBuilder.CreateTable(
                name: "ChungNhans",
                columns: table => new
                {
                    IDChungNhan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenChungNhan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IDForm = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChungNhans", x => x.IDChungNhan);
                });

            migrationBuilder.CreateTable(
                name: "FormChungNhans",
                columns: table => new
                {
                    IDForm = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Images = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormChungNhans", x => x.IDForm);
                });

            migrationBuilder.CreateTable(
                name: "Quyens",
                columns: table => new
                {
                    IDQuyen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TacVu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quyens", x => x.IDQuyen);
                });

            migrationBuilder.CreateTable(
                name: "SinhViens",
                columns: table => new
                {
                    MSSV = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<byte>(type: "tinyint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhViens", x => x.MSSV);
                });

            migrationBuilder.CreateTable(
                name: "TacVus",
                columns: table => new
                {
                    IDTacVu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenTacVu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TacVus", x => x.IDTacVu);
                });

            migrationBuilder.CreateTable(
                name: "TrangThaiDuyets",
                columns: table => new
                {
                    IDTrangThai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenTrangThai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrangThaiDuyets", x => x.IDTrangThai);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "ChiTietChungNhans");

            migrationBuilder.DropTable(
                name: "ChiTietQuyenAdmins");

            migrationBuilder.DropTable(
                name: "ChiTietQuyenSinhViens");

            migrationBuilder.DropTable(
                name: "ChungNhans");

            migrationBuilder.DropTable(
                name: "FormChungNhans");

            migrationBuilder.DropTable(
                name: "Quyens");

            migrationBuilder.DropTable(
                name: "SinhViens");

            migrationBuilder.DropTable(
                name: "TacVus");

            migrationBuilder.DropTable(
                name: "TrangThaiDuyets");
        }
    }
}
