using Microsoft.EntityFrameworkCore;

namespace MyApiCore5.Data
{
    public class MyDBContext:DbContext
    {
        public MyDBContext(DbContextOptions options):base (options) 
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<ChiTietChungNhan> ChiTietChungNhans { get; set; }
        public DbSet<ChiTietQuyenAdmin> ChiTietQuyenAdmins { get; set; }
        public DbSet<ChiTietQuyenSinhVien> ChiTietQuyenSinhViens { get; set; }
        public DbSet<ChungNhan> ChungNhans { get; set; }
        public DbSet<FormChungNhan> FormChungNhans { get; set; }
        public DbSet<Quyen> Quyens { get; set; }
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<TacVu> TacVus { get; set; }
        public DbSet<TrangThaiDuyet> TrangThaiDuyets { get; set; }

    }
}
