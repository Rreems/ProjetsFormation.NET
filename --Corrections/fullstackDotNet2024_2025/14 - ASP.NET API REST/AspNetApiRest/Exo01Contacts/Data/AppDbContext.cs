using Exo01Contacts.Models;
using Microsoft.EntityFrameworkCore;

namespace Exo01Contacts.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
