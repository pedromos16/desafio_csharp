using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Reply.Entities;

namespace WebAPI_Reply.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Projetos>>> GetAllProjects()
        {
            var projetos = new List<Projetos>
            {
                new Projetos
                {
                    Id = 1,
                    Nome = "Spedroman",
                    Descricao = "teste",
                    DataInicio = new DateTime(2024, 06, 02),
                    DataFim = new DateTime(2024, 12, 05)
                    }
            };
            return Ok(projetos);
        }
    }
}
