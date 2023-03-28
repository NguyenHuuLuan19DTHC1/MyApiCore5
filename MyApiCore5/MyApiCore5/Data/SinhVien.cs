using System;
using System.ComponentModel.DataAnnotations;

namespace MyApiCore5.Data
{
    public class SinhVien
    {
        [Key]
        [MaxLength(100)]
        public string MSSV { get; set; }
        [MaxLength(100)]
        public string HoTen { get;set; }
        public DateTime NgaySinh { get; set; }

        public byte TrangThai { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string Phone { get; set; }

    }
}
