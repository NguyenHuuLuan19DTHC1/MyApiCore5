using System;
using System.ComponentModel.DataAnnotations;

namespace MyApiCore5.Data
{
    public class ChiTietQuyenSinhVien
    {
        [Key]
        [MaxLength(100)]
        public string MSSV { get; set; }
        [MaxLength(100)]
        public string IDQuyen { get; set; }
        public byte[] TrangThai { get; set; }
    }
}
