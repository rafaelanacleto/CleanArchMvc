using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace CleanArchMvc.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Ativo> Ativos { get; set; }
        public DbSet<Passivo> Passivos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Conta> Contas { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            builder.Entity<Ativo>()
                .Property(a => a.Valor)
                .HasColumnType("decimal(18,4)");

            builder.Entity<Passivo>()
                .Property(p =>  p.Valor)
                .HasColumnType("decimal(18,4");

            builder.Entity<Conta>()
                .Property(c => c.Saldo)
                .HasColumnType("decimal(18,4)");




        }
    }
}
