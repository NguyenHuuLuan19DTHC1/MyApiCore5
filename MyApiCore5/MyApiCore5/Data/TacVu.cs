using System;
using System.ComponentModel.DataAnnotations;

namespace MyApiCore5.Data
{
    public class TacVu
    {
        [Key]
        [MaxLength(100)]
        public string IDTacVu { get; set; }
        [MaxLength(100)]
        public string TenTacVu { get; set; }
    }
}
