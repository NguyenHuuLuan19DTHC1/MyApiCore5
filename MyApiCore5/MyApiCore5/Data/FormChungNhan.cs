using System;
using System.ComponentModel.DataAnnotations;

namespace MyApiCore5.Data
{
    public class FormChungNhan
    {
        [Key]
        [MaxLength(100)]
        public string IDForm { get; set; }
        public byte[] Images { get; set; }
    }
}
