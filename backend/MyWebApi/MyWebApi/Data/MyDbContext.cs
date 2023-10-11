
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace MyWebApi.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        public DbSet<InfoMovies> InfoMovies { get; set; }
        public DbSet<ShowTimes> ShowTimes { get; set; }
        public DbSet<AccountUsers> AccountUsers { get; set; }
        public DbSet<EventsData> EventsData { get; set; }
        public DbSet<SlideMovies> SlideMovies { get; set; }
    }
}
