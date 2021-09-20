using Consumer.MovieList.Api.Domain.Movie.Model;
using Consumer.MovieList.Api.Dto;
using Microsoft.EntityFrameworkCore;

namespace Consumer.MovieList.Api.Infra
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        public MovieDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Movie");
        }

        public DbSet<MovieModel> Movie { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieModel>().ToTable("Movie");

            modelBuilder.Entity<MovieModel>().HasKey(m => m.Id);

            modelBuilder.Entity<MovieModel>().Property(m => m.Year)
                .IsRequired();
            modelBuilder.Entity<MovieModel>().Property(m => m.Title)
                .HasMaxLength(250)
                .IsRequired();
            modelBuilder.Entity<MovieModel>().Property(m => m.Studio)
                .HasMaxLength(250)
                .IsRequired();
            modelBuilder.Entity<MovieModel>().Property(m => m.Producer)
                .HasMaxLength(250)
                .IsRequired();
            modelBuilder.Entity<MovieModel>().Property(m => m.Winner)
                .IsRequired();
        }
    }
}
