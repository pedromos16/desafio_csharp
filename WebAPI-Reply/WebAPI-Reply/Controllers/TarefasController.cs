using Microsoft.AspNetCore.Mvc;
using WebAPI_Reply.Entities;

[ApiController]
[Route("api/[controller]")]
public class TarefasController : ControllerBase
{
    private readonly IRepository<Tarefas> _repository;

    public TarefasController(IRepository<Tarefas> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tarefas>>> GetAll()
    {
        return Ok(await _repository.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Tarefas>> GetById(int id)
    {
        var tarefa = await _repository.GetByIdAsync(id);
        if (tarefa is null) 
            return NotFound();
        return Ok(tarefa);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Tarefas tarefa)
    {
        await _repository.AddAsync(tarefa);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(Tarefas tarefa)
    {
        await _repository.UpdateAsync(tarefa);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return Ok();
    }
}
