using AspCoreApplication2023.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Memebershiptype> memebershipTypes { get; set; }
}