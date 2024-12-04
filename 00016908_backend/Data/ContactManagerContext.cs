using _00016908_backend.models;
using Microsoft.EntityFrameworkCore;

namespace _00016908_backend.Data
{
    public class ContactManagerContext : DbContext
    {
        public ContactManagerContext(DbContextOptions<ContactManagerContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
