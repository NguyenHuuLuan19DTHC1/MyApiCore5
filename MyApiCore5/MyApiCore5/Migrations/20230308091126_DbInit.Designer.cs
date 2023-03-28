﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyApiCore5.Data;

namespace MyApiCore5.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20230308091126_DbInit")]
    partial class DbInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyApiCore5.Data.Admin", b =>
                {
                    b.Property<string>("IDAdmin")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Ten")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IDAdmin");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("MyApiCore5.Data.ChiTietChungNhan", b =>
                {
                    b.Property<string>("IDChiTietChungNhan")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("IDAdmin1")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("IDAdmin2")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("IDAmin3")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("IDChungNhan")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("IDTrangThaiDuyet")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("MSSV")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("NgayCapOffline")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayCapOnline")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoQuyetDinhOffline")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SoQuyetDinhOnline")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IDChiTietChungNhan");

                    b.ToTable("ChiTietChungNhans");
                });

            modelBuilder.Entity("MyApiCore5.Data.ChiTietQuyenAdmin", b =>
                {
                    b.Property<string>("IDAdmin")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("IDQuyen")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte>("TrangThai")
                        .HasColumnType("tinyint");

                    b.HasKey("IDAdmin");

                    b.ToTable("ChiTietQuyenAdmins");
                });

            modelBuilder.Entity("MyApiCore5.Data.ChiTietQuyenSinhVien", b =>
                {
                    b.Property<string>("MSSV")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("IDQuyen")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("TrangThai")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("MSSV");

                    b.ToTable("ChiTietQuyenSinhViens");
                });

            modelBuilder.Entity("MyApiCore5.Data.ChungNhan", b =>
                {
                    b.Property<string>("IDChungNhan")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("IDForm")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TenChungNhan")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IDChungNhan");

                    b.ToTable("ChungNhans");
                });

            modelBuilder.Entity("MyApiCore5.Data.FormChungNhan", b =>
                {
                    b.Property<string>("IDForm")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("Images")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("IDForm");

                    b.ToTable("FormChungNhans");
                });

            modelBuilder.Entity("MyApiCore5.Data.Quyen", b =>
                {
                    b.Property<string>("IDQuyen")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MoTa")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TacVu")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IDQuyen");

                    b.ToTable("Quyens");
                });

            modelBuilder.Entity("MyApiCore5.Data.SinhVien", b =>
                {
                    b.Property<string>("MSSV")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("HoTen")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<byte>("TrangThai")
                        .HasColumnType("tinyint");

                    b.HasKey("MSSV");

                    b.ToTable("SinhViens");
                });

            modelBuilder.Entity("MyApiCore5.Data.TacVu", b =>
                {
                    b.Property<string>("IDTacVu")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TenTacVu")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IDTacVu");

                    b.ToTable("TacVus");
                });

            modelBuilder.Entity("MyApiCore5.Data.TrangThaiDuyet", b =>
                {
                    b.Property<string>("IDTrangThai")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TenTrangThai")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IDTrangThai");

                    b.ToTable("TrangThaiDuyets");
                });
#pragma warning restore 612, 618
        }
    }
}
