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
        public DbSet<Showtime> Showtimes { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<AccUser> AccUsers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
