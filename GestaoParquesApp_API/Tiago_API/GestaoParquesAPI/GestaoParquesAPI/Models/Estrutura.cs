using System;
using System.Collections.Generic;

namespace GestaoParquesAPI.Models;

public partial class Estrutura
{
    public int IdEstrutura { get; set; }

    public int IdZona { get; set; }

    public int IdTipoEstrutura { get; set; }

    public DateTime DataCriacao { get; set; }

    public DateTime DataAtualizacao { get; set; }

    public bool Inativo { get; set; }

    public virtual TipoEstrutura IdTipoEstruturaNavigation { get; set; } = null!;

    public virtual Zona IdZonaNavigation { get; set; } = null!;
}
