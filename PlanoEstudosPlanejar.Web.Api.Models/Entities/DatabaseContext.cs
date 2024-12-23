using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoEstudosPlanejar.Web.Api.Models.Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<PlanoEstudo> PlanoEstudos { get; set; }
        public DbSet<Materias> Materias { get; set; }
        public DbSet<Arquivos> Arquivos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlanoEstudo>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.PlanoEstudos)
                .HasForeignKey(u => u.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Materias>()
                .HasOne(p => p.PlanoEstudo)
                .WithMany(m => m.Materias)
                .HasForeignKey(u => u.PlanoEstudoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Arquivos>()
                .HasOne(p => p.PlanoEstudo)
                .WithMany(u => u.Arquivos)
                .HasForeignKey(u => u.PlanoEstudoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
