using System.Data.Entity;

namespace EFTransactions
{
    class TestEntities : DbContext
    {
        public DbSet<Person> Persons { get; set; }
    }
}
