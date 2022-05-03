using ExenoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExenoApi.Data
{
    public class ExenoContext : DbContext
    {
        public ExenoContext(DbContextOptions<ExenoContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
