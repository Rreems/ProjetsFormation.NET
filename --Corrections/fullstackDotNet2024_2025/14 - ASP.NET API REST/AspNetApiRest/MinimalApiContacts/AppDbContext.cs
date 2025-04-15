using Microsoft.EntityFrameworkCore;
class AppDbContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}