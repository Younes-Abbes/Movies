using WebApplication1.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;
    public DbSet<Memebershiptype> memebershipTypes { get; set; } = null!;
}
