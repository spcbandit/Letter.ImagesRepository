using Letter.Infrastructure.Application.Domains.Entities;
using Microsoft.EntityFrameworkCore;

namespace Letter.Infrastructure.Database.Context;

public class ImageContext: DbContext
{
    public virtual DbSet<Image> Images { get; set; }

    public ImageContext(DbContextOptions<ImageContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

}