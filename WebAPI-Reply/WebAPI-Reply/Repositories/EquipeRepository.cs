using WebAPI_Reply.Data;
using WebAPI_Reply.Entities;

public class EquipeRepository : Repository<Equipes>, IRepository<Equipes>
{
    public EquipeRepository(DataContext context) : base(context) { }
}