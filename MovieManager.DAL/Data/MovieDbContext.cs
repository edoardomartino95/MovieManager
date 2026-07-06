using Microsoft.EntityFrameworkCore;
using MovieManager.DAL.Entities;

namespace MovieManager.DAL.Data;

public class MovieDbContext : DbContext
{
    public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) { }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<MovieActor> MovieActors { get; set; }
    public DbSet<Review> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Chiave composta su MovieActor
        modelBuilder.Entity<MovieActor>()
            .HasKey(ma => new { ma.MovieId, ma.ActorId });



        // Relazione MovieActor -> Movie
        modelBuilder.Entity<MovieActor>()
            .HasOne(ma => ma.Movie)
            .WithMany(m => m.MovieActors)
            .HasForeignKey(ma => ma.MovieId);

        // Relazione MovieActor -> Actor
        modelBuilder.Entity<MovieActor>()
            .HasOne(ma => ma.Actor)
            .WithMany(a => a.MovieActors)
            .HasForeignKey(ma => ma.ActorId);

        // Vincoli e lunghezze
        modelBuilder.Entity<Movie>(b =>
        {
            b.Property(m => m.Title).IsRequired().HasMaxLength(200);
        });

        modelBuilder.Entity<Genre>(b =>
        {
            b.Property(g => g.Name).IsRequired().HasMaxLength(50);
        });

        modelBuilder.Entity<Director>(b =>
        {
            b.Property(d => d.FirstName).IsRequired().HasMaxLength(100);
            b.Property(d => d.LastName).IsRequired().HasMaxLength(100);
        });

        modelBuilder.Entity<Actor>(b =>
        {
            b.Property(a => a.FirstName).IsRequired().HasMaxLength(100);
            b.Property(a => a.LastName).IsRequired().HasMaxLength(100);
        });

        modelBuilder.Entity<Review>(b =>
        {
            b.Property(r => r.ReviewerName).IsRequired().HasMaxLength(100);
            // Vincolo score recensione: da 1 a 10
            b.ToTable(t => t.HasCheckConstraint("CK_Review_Score", "[Score] >= 1 AND [Score] <= 10"));
        });
    }
}