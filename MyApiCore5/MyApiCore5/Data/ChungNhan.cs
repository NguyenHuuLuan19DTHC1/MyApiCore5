using System;
using System.ComponentModel.DataAnnotations;

namespace MyApiCore5.Data
{
    public class ChungNhan
    {
        [Key]
        [MaxLength(100)]
        public string IDChungNhan { get; set; }
        [MaxLength(100)]
        public string TenChungNhan { get; set; }
        [MaxLength(100)]
        public string IDForm { get; set; }

    }
}
