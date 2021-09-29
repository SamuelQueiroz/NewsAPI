using Entidades.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Configuracoes
{
    public class Contexto : IdentityDbContext<ApplicationUser>
    {
        public Contexto(DbContextOptions<Contexto> opcoes): base(opcoes)
        {

        }

        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }

        }

        public string ObterStringConexao()
        {
            string conn = "User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=NewsAPI;Pooling=true";
            return conn;
        }
    }
}
