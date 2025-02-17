using Microsoft.EntityFrameworkCore;
using WebAPI_Reply.Entities;

namespace WebAPI_Reply.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Projetos> Projetos { get; set; }

        public DbSet<Tarefas> Tarefas { get; set; }

        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<Equipes> Equipes { get; set; }

        public DbSet<Usuarios_Equipes> Usuarios_Equipes { get; set; }

    }
}
