using Microsoft.EntityFrameworkCore;
using WebAPI_Reply.Entities;

namespace WebAPI_Reply.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Projetos> Projetos {  get; set; }
    }
}
