using System;
using System.Collections.Generic;

namespace GestaoParquesAPI.Models;

public partial class StatusOcorrencium
{
    public int IdStatusOcorrencia { get; set; }

    public string DescricaoStatus { get; set; } = null!;

    public DateTime DataCriacao { get; set; }

    public DateTime DataAtualizacao { get; set; }

    public bool Inativo { get; set; }

    public virtual ICollection<HistoricoOcorrencium> HistoricoOcorrencia { get; set; } = new List<HistoricoOcorrencium>();
}
