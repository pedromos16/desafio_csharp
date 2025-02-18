using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_Reply.Entities
{
    public class Tarefas
    {
        public int Id { get; set; }

        [ForeignKey("Projetos")]
        public int ProjetoId { get; set; }
        public string Titulo { get; set; } = string.Empty;

        public string? Descricao { get; set; }
        public string Status { get; set; }  = string.Empty;

    }
}
