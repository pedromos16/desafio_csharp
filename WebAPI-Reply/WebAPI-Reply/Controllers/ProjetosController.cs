using Microsoft.AspNetCore.Mvc;
using WebAPI_Reply.Entities;

[ApiController]
[Route("api/[controller]")]
public class ProjetosController : ControllerBase
{
    private readonly IRepository<Projetos> _repository;

    public ProjetosController(IRepository<Projetos> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Projetos>>> GetAll()
    {
        return Ok(await _repository.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Projetos>> GetById(int id)
    {
        var projeto = await _repository.GetByIdAsync(id);
        if (projeto is null) 
            return NotFound();
        return Ok(projeto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Projetos projeto)
    {
        await _repository.AddAsync(projeto);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(Projetos projeto)
    {
        await _repository.UpdateAsync(projeto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return Ok();
    }
}
