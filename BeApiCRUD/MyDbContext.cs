using BeApiCRUD.Model;
using Microsoft.EntityFrameworkCore;

namespace BeApiCRUD
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<EventsInfo> EventsInfos { get; set; }
        public DbSet<SlideMovie> SlideMovies { get; set; }
    }
}
