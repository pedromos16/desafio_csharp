using WebAPI_Reply.Data;
using WebAPI_Reply.Entities;

public class TarefaRepository : Repository<Tarefas>, IRepository<Tarefas>
{
    public TarefaRepository(DataContext context) : base(context) { }
}