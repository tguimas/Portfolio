using System;
using System.Collections.Generic;

namespace GestaoParquesAPI.Models;

public partial class Ocorrencium
{
    public int IdOcorrencia { get; set; }

    public int IdTipoOcorrencia { get; set; }

    public int IdZona { get; set; }

    public DateOnly DataCriacaoOcorrencia { get; set; }

    public DateOnly? DataResolucaoOcorrencia { get; set; }

    public string Email { get; set; } = null!;

    public DateTime DataCriacao { get; set; }

    public DateTime DataAtualizacao { get; set; }

    public bool Inativo { get; set; }

    public virtual ICollection<HistoricoOcorrencium> HistoricoOcorrencia { get; set; } = new List<HistoricoOcorrencium>();

    public virtual TipoOcorrencium IdTipoOcorrenciaNavigation { get; set; } = null!;

    public virtual Zona IdZonaNavigation { get; set; } = null!;
}
