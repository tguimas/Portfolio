using System;
using System.Collections.Generic;

namespace GestaoParquesAPI.Models;

public partial class Fauna
{
    public int IdFauna { get; set; }

    public string EspecieFauna { get; set; } = null!;

    public string NomeCientificoFauna { get; set; } = null!;

    public string CategoriaFauna { get; set; } = null!;

    public DateTime DataCriacao { get; set; }

    public DateTime DataAtualizacao { get; set; }

    public bool Inativo { get; set; }

    public virtual ICollection<ZonaFauna> ZonaFaunas { get; set; } = new List<ZonaFauna>();
}
