using BookAppSolution.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAppSolution.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories {get; set;}
    }
}
