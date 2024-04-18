using System;
using System.Collections.Generic;

namespace GestaoParquesAPI.Models;

public partial class ZonaFlora
{
    public int IdFlora { get; set; }

    public int IdZona { get; set; }

    public string? Descricao { get; set; }

    public DateTime DataCriacao { get; set; }

    public DateTime DataAtualizacao { get; set; }

    public bool Inativo { get; set; }

    public virtual Flora IdFloraNavigation { get; set; } = null!;

    public virtual Zona IdZonaNavigation { get; set; } = null!;
}
