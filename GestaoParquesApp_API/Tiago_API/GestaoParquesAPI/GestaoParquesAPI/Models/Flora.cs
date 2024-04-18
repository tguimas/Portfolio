using System;
using System.Collections.Generic;

namespace GestaoParquesAPI.Models;

public partial class Flora
{
    public int IdFlora { get; set; }

    public string EspecieFlora { get; set; } = null!;

    public string NomeCientificoFlora { get; set; } = null!;

    public string TipoPlanta { get; set; } = null!;

    public DateTime DataCriacao { get; set; }

    public DateTime DataAtualizacao { get; set; }

    public bool Inativo { get; set; }

    public virtual ICollection<ZonaFlora> ZonaFloras { get; set; } = new List<ZonaFlora>();
}
