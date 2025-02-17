using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_Reply.Entities
{
    public class Equipes
    {
        public int Id { get; set; }

        [ForeignKey("Projetos")]
        public int ProjetoId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Setor { get; set; } = string.Empty;
        public string Responsavel { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;

        public Projetos Projetos { get; set; }
    }
}
