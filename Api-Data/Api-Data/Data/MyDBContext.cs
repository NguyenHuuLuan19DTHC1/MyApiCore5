using Microsoft.EntityFrameworkCore;

namespace Api_Data.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<DataCSV> dataCSVs { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<TemporaryData> TemporaryDatas { get; set; }
       
    }
    

}
