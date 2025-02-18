using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_Reply.Entities
{
    [PrimaryKey(nameof(IdUsuario), nameof(IdEquipe))]
    public class Usuarios_Equipes
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Usuarios")]
        public int IdUsuario { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Equipes")]
        public int IdEquipe { get; set; }

        public DateOnly DataEntrada { get; set; }
        public string Funcao { get; set; } = string.Empty;
        public string Ativo { get; set; } = "Sim";

        public Usuarios Usuario { get; set; }
        public Equipes Equipe { get; set; }
    }
}
