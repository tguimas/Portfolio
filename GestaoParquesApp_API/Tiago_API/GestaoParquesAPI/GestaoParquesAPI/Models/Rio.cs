using System;
using System.Collections.Generic;

namespace GestaoParquesAPI.Models;

public partial class Rio
{
    public int IdRio { get; set; }

    public string NomeRio { get; set; } = null!;

    public int Comprimento { get; set; }

    public DateTime DataCriacao { get; set; }

    public DateTime DataAtualizacao { get; set; }

    public bool Inativo { get; set; }

    public virtual ICollection<ZonaRio> ZonaRios { get; set; } = new List<ZonaRio>();
}
