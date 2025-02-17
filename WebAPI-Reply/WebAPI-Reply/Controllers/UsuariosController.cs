using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_Reply.Data;
using WebAPI_Reply.Entities;

namespace WebAPI_Reply.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuariosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuarios>>> GetUsuarios()
        {
            return Ok(await _context.Usuarios.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Usuarios>> GetUsuario(int Id)
        {
            var usuario = await _context.Usuarios.FindAsync(Id);
            if (usuario is null)
                return NotFound("Usuário não encontrado");

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult> AddUsuario(Usuarios usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUsuario(Usuarios usuario)
        {
            var user = await _context.Usuarios.FindAsync(usuario.Id);
            if (user is null)
                return NotFound("Usuário não encontrado");

            user.Nome = usuario.Nome;
            user.Email = usuario.Email;
            user.Telefone = usuario.Telefone;
            user.Cargo = usuario.Cargo;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteUsuario(int Id)
        {
            var user = await _context.Usuarios.FindAsync(Id);
            if (user is null)
                return NotFound("Usuário não encontrado");

            _context.Usuarios.Remove(user);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
