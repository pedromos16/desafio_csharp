﻿namespace WebAPI_Reply.Entities
{
    public class Projetos
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }

        public DateOnly DataInicio { get; set; }

        public DateOnly DataFim { get; set; }

    }
}
