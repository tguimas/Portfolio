using System;
using System.Collections.Generic;

namespace GestaoParquesAPI.Models;

public partial class ZonaRio
{
    public int IdZona { get; set; }

    public int IdRio { get; set; }

    public DateTime DataCriacao { get; set; }

    public DateTime DataAtualizacao { get; set; }

    public bool Inativo { get; set; }

    public virtual Rio IdRioNavigation { get; set; } = null!;

    public virtual Zona IdZonaNavigation { get; set; } = null!;
}
