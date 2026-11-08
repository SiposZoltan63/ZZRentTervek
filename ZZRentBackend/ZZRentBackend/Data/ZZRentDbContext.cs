using Microsoft.EntityFrameworkCore;
using ZZRent.Models;

namespace ZZRent.Data
{
    public class ZZRentDbContext : DbContext
    {
        public ZZRentDbContext(DbContextOptions<ZZRentDbContext> options) : base(options)
        {

        }
        public DbSet<Auto> Autok { get; set; }
        public DbSet<Sofor> Soforok { get; set; }
    }
}
