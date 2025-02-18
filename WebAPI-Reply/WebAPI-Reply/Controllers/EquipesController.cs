using Microsoft.AspNetCore.Mvc;
using WebAPI_Reply.Entities;

[ApiController]
[Route("api/[controller]")]
public class EquipesController : ControllerBase
{
    private readonly IRepository<Equipes> _repository;

    public EquipesController(IRepository<Equipes> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Equipes>>> GetAll()
    {
        return Ok(await _repository.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Equipes>> GetById(int id)
    {
        var equipe = await _repository.GetByIdAsync(id);
        if (equipe is null) 
            return NotFound();
        return Ok(equipe);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Equipes equipe)
    {
        await _repository.AddAsync(equipe);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(Equipes equipe)
    {
        await _repository.UpdateAsync(equipe);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return Ok();
    }
}
