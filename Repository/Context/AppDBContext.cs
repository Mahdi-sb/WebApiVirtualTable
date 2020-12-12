using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) 

            : base(dbContextOptions)
        {

        }

        public DbSet<Tables> Tables { get; set; }
        public DbSet<Types> Types { get; set; }
        public DbSet<Value> Values { get; set; }
        public DbSet<CreateTime> CreateTimes { get; set; }


    }
}
