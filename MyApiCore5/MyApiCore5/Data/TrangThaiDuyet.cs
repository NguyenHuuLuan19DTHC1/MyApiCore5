using System;
using System.ComponentModel.DataAnnotations;

namespace MyApiCore5.Data
{
    public class TrangThaiDuyet
    {
        [Key]
        [MaxLength(100)]
        public string IDTrangThai { get; set; }
        [MaxLength(100)]
        public string TenTrangThai { get; set; }
    }
}
