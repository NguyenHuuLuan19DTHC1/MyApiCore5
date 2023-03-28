using System;
using System.ComponentModel.DataAnnotations;

namespace MyApiCore5.Data
{
    public class Quyen
    {
        [Key]
        [MaxLength(100)]
        public string IDQuyen { get; set; }
        [MaxLength(100)]
        public string MoTa { get; set; }
        [MaxLength(100)]
        public string TacVu { get; set; }
    }
}
