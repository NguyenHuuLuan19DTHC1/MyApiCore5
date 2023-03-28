using System.ComponentModel.DataAnnotations;

namespace Api_Data.Data
{
    public class Users
    {
        [MaxLength(100)]
        [Key]
        public string Username { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string AccountType { get; set; }
    }
}
