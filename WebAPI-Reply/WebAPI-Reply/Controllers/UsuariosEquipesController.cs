using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_Reply.Data;
using WebAPI_Reply.Entities;

namespace WebAPI_Reply.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosEquipesController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuariosEquipesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuarios_Equipes>>> GetUsuariosEquipes()
        {
            return Ok(await _context.Usuarios_Equipes.ToListAsync());
        }

        [HttpGet("{IdUsuario}/{IdEquipe}")]
        public async Task<ActionResult<Usuarios_Equipes>> GetUsuarioEquipe(int IdUsuario, int IdEquipe)
        {
            var usuarioEquipe = await _context.Usuarios_Equipes
                .FirstOrDefaultAsync(ue => ue.IdUsuario == IdUsuario && ue.IdEquipe == IdEquipe);

            if (usuarioEquipe is null)
                return NotFound("Relação usuário-equipe não encontrada");

            return Ok(usuarioEquipe);
        }

        [HttpPost]
        public async Task<ActionResult> AddUsuarioEquipe(Usuarios_Equipes usuarioEquipe)
        {
            _context.Usuarios_Equipes.Add(usuarioEquipe);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUsuarioEquipe(Usuarios_Equipes usuarioEquipe)
        {
            var usuarioEquipeDB = await _context.Usuarios_Equipes
                .FirstOrDefaultAsync(ue => ue.IdUsuario == usuarioEquipe.IdUsuario && ue.IdEquipe == usuarioEquipe.IdEquipe);

            if (usuarioEquipeDB is null)
                return NotFound("Relação usuário-equipe não encontrada");

            usuarioEquipeDB.DataEntrada = usuarioEquipe.DataEntrada;
            usuarioEquipeDB.Funcao = usuarioEquipe.Funcao;
            usuarioEquipeDB.Ativo = usuarioEquipe.Ativo;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{IdUsuario}/{IdEquipe}")]
        public async Task<ActionResult> DeleteUsuarioEquipe(int IdUsuario, int IdEquipe)
        {
            var usuarioEquipe = await _context.Usuarios_Equipes
                .FirstOrDefaultAsync(ue => ue.IdUsuario == IdUsuario && ue.IdEquipe == IdEquipe);

            if (usuarioEquipe is null)
                return NotFound("Relação usuário-equipe não encontrada");

            _context.Usuarios_Equipes.Remove(usuarioEquipe);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
