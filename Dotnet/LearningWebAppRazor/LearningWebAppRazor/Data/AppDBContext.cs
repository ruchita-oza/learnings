using Microsoft.EntityFrameworkCore;
using LearningWebAppRazor.Models;

namespace LearningWebAppRazor.Data
{
	public class AppDBContext : DbContext
    {
        public AppDBContext (DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; } = default!;
    }
}
