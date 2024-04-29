using Microsoft.EntityFrameworkCore;

namespace compesa.Models
{
    public partial class UserContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }

        public UserContext()
        {
        }

        public UserContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder model);
    }
}
