using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_Reply.Data;
using WebAPI_Reply.Entities;

namespace WebAPI_Reply.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipesController : ControllerBase
    {
        private readonly DataContext _context;

        public EquipesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Equipes>>> GetEquipes()
        {
            return Ok(await _context.Equipes.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Equipes>> GetEquipe(int Id)
        {
            var equipe = await _context.Equipes.FindAsync(Id);
            if (equipe is null)
                return NotFound("Equipe não encontrada");

            return Ok(equipe);
        }

        [HttpPost]
        public async Task<ActionResult> AddEquipe(Equipes equipe)
        {
            _context.Equipes.Add(equipe);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEquipe(Equipes equipe)
        {
            var equipeDB = await _context.Equipes.FindAsync(equipe.Id);
            if (equipeDB is null)
                return NotFound("Equipe não encontrada");

            equipeDB.Nome = equipe.Nome;
            equipeDB.Setor = equipe.Setor;
            equipeDB.Responsavel = equipe.Responsavel;
            equipeDB.Descricao = equipe.Descricao;
            equipeDB.ProjetoId = equipe.ProjetoId;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteEquipe(int Id)
        {
            var equipe = await _context.Equipes.FindAsync(Id);
            if (equipe is null)
                return NotFound("Equipe não encontrada");

            _context.Equipes.Remove(equipe);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
