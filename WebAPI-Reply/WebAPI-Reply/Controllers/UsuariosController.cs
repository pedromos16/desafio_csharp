using Microsoft.AspNetCore.Mvc;
using WebAPI_Reply.Entities;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IRepository<Usuarios> _repository;

    public UsuariosController(IRepository<Usuarios> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuarios>>> GetAll()
    {
        return Ok(await _repository.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Usuarios>> GetById(int id)
    {
        var usuario = await _repository.GetByIdAsync(id);
        if (usuario is null) 
            return NotFound();
        return Ok(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Usuarios usuario)
    {
        await _repository.AddAsync(usuario);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(Usuarios usuario)
    {
        await _repository.UpdateAsync(usuario);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return Ok();
    }
}
