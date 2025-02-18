using WebAPI_Reply.Data;
using WebAPI_Reply.Entities;

public class ProjetoRepository : Repository<Projetos>, IRepository<Projetos>
{
    public ProjetoRepository(DataContext context) : base(context) { }
}