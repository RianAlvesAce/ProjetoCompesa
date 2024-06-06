using Microsoft.EntityFrameworkCore;

namespace compesa.Models
{
    public partial class DataContext : DbContext
    {
        public DbSet<User> Usuario { get; set; }
        public DbSet<UserTeste> UserTestes { get; set; }
        public DbSet<UserPermissions> Permissions { get; set; }
        public DbSet<UnidadeQuant> unidadeQuants { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<LigModUser> Lig_Mod_User { get; set; }
        public DbSet<UserMod> UserMod { get; set; }
        public DbSet<GetOcorrencia> Ocorrencias { get; set; }
        public DbSet<Ocorrencia> ocorrencia {  get; set; }
        public DbSet<Unidade> Unidades { get; set; }
        public DbSet<Tipo> Tipos { get; set; }

        public DataContext()
        {
        }

        public DataContext(DbContextOptions options) : base(options)
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
