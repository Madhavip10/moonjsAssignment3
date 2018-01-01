using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BasicWebApp.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public new DbSet<User> Users { get; set; }

        public DbSet<Reset> ResetTable { get; set; }

        public DbSet<PostModel> Posts { get; set; }

    }
}
