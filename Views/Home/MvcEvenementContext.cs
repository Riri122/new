using Microsoft.EntityFrameworkCore;

namespace Newrtest.Views.Home
{
    public class MvcEvenementContext : DbContext
    {
        public MvcEvenementContext(DbContextOptions<MvcEvenementContext> options)
            : base(options) 
        { 
        
        }

        public DbSet<Evenement> Evenements { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}
