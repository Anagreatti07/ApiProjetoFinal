using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<UsersModel> User { get; set; }

        public DbSet<UsuariosModel> Usuario { get; set; }

        public DbSet<ObservacoesModel> Observacoes { get; set; }
        public DbSet<ObjetosModel> Objeto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsersMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ObservacoesMap());
            modelBuilder.ApplyConfiguration(new ObjetoMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
