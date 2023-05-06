using DotNetWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
    }
}
