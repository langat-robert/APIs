using Microsoft.EntityFrameworkCore;

namespace CSharpSample1.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        // DbSets will go here if needed
    }
}
