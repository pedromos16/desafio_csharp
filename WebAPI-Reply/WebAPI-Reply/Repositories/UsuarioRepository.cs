using WebAPI_Reply.Data;
using WebAPI_Reply.Entities;

public class UsuarioRepository : Repository<Usuarios>, IRepository<Usuarios>
{
    public UsuarioRepository(DataContext context) : base(context) { }
}