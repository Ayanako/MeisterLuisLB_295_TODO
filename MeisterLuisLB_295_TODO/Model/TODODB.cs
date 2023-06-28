using Microsoft.EntityFrameworkCore;

namespace MeisterLuisLB_295_TODO.Model
{
    public class TODODB : DbContext
    {

        public TODODB(DbContextOptions<TODODB> options) : base(options)
        {
        }
        public DbSet<TODO> TODOs { get; set; }

        //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //  {
        //        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TODODB;Trusted_Connection=True");
        //  }
    }
}
