using System;
using System.Collections.Generic;

namespace GestaoParquesAPI.Models;

public partial class TipoOcorrencium
{
    public int IdTipoOcorrencia { get; set; }

    public string NomeTipoOcorrencia { get; set; } = null!;

    public DateTime DataCriacao { get; set; }

    public DateTime DataAtualizacao { get; set; }

    public bool Inativo { get; set; }

    public virtual ICollection<Ocorrencium> Ocorrencia { get; set; } = new List<Ocorrencium>();
}
