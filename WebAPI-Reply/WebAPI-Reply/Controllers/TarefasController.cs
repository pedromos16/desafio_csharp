using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_Reply.Data;
using WebAPI_Reply.Entities;

namespace WebAPI_Reply.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly DataContext _context;

        public TarefasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tarefas>>> GetAllTarefas()
        {
            return Ok(await _context.Tarefas.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Tarefas>>> AddTarefa(Tarefas tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();

            return Ok(tarefa);
        }

        [HttpPut]
        public async Task<ActionResult<List<Tarefas>>> UpdateTarefas(Tarefas updateTarefas)
        {
            var tarefa = await _context.Tarefas.FindAsync(updateTarefas.Id);
            if (tarefa is null)
                return NotFound("Tarefa nao encontrada");

            tarefa.Titulo = updateTarefas.Titulo;
            tarefa.Descricao = updateTarefas.Descricao;
            tarefa.ProjetoId = updateTarefas.ProjetoId;
            tarefa.Status = updateTarefas.Status;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<List<Tarefas>>> DeleteTarefa(int Id)
        {
            var tarefa = await _context.Tarefas.FindAsync(Id);
            if (tarefa is null)
                return NotFound("Tarefa nao encontrada");

            _context.Tarefas.Remove(tarefa);

            await _context.SaveChangesAsync();

            return Ok();

        }

    }
}
