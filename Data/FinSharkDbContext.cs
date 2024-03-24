using FinShark.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class FinSharkDbContext:DbContext
    {
        public FinSharkDbContext(DbContextOptions<FinSharkDbContext> dbContextOptions):base(dbContextOptions)
        {
            
        }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}