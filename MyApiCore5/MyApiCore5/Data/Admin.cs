using System;
using System.ComponentModel.DataAnnotations;

namespace MyApiCore5.Data
{
    public class Admin
    {
        [Key]
        [MaxLength(100)]
        public string IDAdmin { get; set; }
        [MaxLength(50)]
        public string Ten { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
