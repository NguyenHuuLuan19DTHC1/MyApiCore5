using System;
using System.ComponentModel.DataAnnotations;

namespace MyApiCore5.Data
{
    public class ChiTietQuyenAdmin
    {
        [Key]
        [MaxLength(100)]
        public string IDAdmin { get; set; }
        [MaxLength(100)]
        public string IDQuyen { get; set; }
        public byte TrangThai { get; set;}

    }
}
