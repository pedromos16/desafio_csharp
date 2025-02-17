using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_Reply.Data;
using WebAPI_Reply.Entities;

namespace WebAPI_Reply.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private readonly DataContext _context;

        public ProjetosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Projetos>>> GetAllProjects()
        {
            var projetos = await _context.Projetos.ToListAsync();
            return Ok(projetos);
        }



        [HttpGet("{Id}")]
        public async Task<ActionResult<Projetos>> GetProject(int Id)
        {
            var projeto = await _context.Projetos.FindAsync(Id);
            if (projeto is null)
                return NotFound("Projeto nao encontrado");

            return Ok(projeto);
        }

        [HttpPost]
        public async Task<ActionResult<List<Projetos>>> AddProject(Projetos projeto)
        {
             _context.Projetos.Add(projeto);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<List<Projetos>>> UpdateProject(Projetos updateProjeto)
        {
            var projeto = await _context.Projetos.FindAsync(updateProjeto.Id);
            if (projeto is null)
                return NotFound("Projeto nao encontrado");

            projeto.Nome = updateProjeto.Nome;
            projeto.Descricao = updateProjeto.Descricao;
            projeto.DataFim = updateProjeto.DataFim;
            projeto.DataInicio = updateProjeto.DataInicio;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<List<Projetos>>> DeleteProject(int Id)
        {
            var projeto = await _context.Projetos.FindAsync(Id);
            if (projeto is null)
                return NotFound("Projeto nao encontrado");

            _context.Projetos.Remove(projeto);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
