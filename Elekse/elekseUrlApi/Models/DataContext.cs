using Microsoft.EntityFrameworkCore;

namespace elekseUrlApi.Models
{
   
        public class DataContext : DbContext
        {
            public DataContext(DbContextOptions options) : base(options)
            {

            }
            public DbSet<Url> Urls { get; set; }
        }
    
}
