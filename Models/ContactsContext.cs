

using Microsoft.EntityFrameworkCore;

namespace vasotoSQLAzure.Models
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Contacts> ContactSet {get; set;}
    }
}