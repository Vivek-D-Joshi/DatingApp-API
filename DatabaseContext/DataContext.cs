using API.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace API.DatabaseContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
