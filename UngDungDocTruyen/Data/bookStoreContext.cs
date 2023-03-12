using Microsoft.EntityFrameworkCore;

namespace UngDungDocTruyen.Data
{
    public class bookStoreContext : DbContext
    {
        public bookStoreContext(DbContextOptions<bookStoreContext> opt): base(opt)
        {
        }


        #region DbSet
        public DbSet<book> books { get; set; }
        public DbSet<user> users { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            //Property Configurations
            modelBuilder.Entity<user>(e =>
            {
                e.ToTable("users");
                e.HasKey(user => new {user.MaUser, user.Gmail} );
                
            });

            modelBuilder.Entity<book>(b =>
            {
                b.HasKey(book => new { book.MaBook});

            });

        }

    }
}
