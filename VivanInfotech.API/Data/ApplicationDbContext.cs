using Microsoft.EntityFrameworkCore;

namespace VivanInfotech.API.Data
{
    using Microsoft.EntityFrameworkCore;
    using VivanInfotech.API.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Technology> Technologies => Set<Technology>();
        public DbSet<Testimonial> Testimonials => Set<Testimonial>();
        public DbSet<ContactRequest> ContactRequests => Set<ContactRequest>();
    }
}
