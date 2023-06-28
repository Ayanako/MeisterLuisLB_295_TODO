using Microsoft.EntityFrameworkCore;

namespace MeisterLuisLB_295_TODO.Model
{
    public class TODODB : DbContext
    {
        public TODODB(DbContextOptions<TODODB> options) : base(options)
        {
        }

        public DbSet<TODO> TODOs { get; set; }
    }
}
