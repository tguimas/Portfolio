using System;
using System.Collections.Generic;

namespace GestaoParquesAPI.Models;

public partial class TipoEstrutura
{
    public int IdTipoEstrutura { get; set; }

    public string NomeTipoEstrutura { get; set; } = null!;

    public string DescricaoTipoEstrutura { get; set; } = null!;

    public DateTime DataCriacao { get; set; }

    public DateTime DataAtualizacao { get; set; }

    public bool Inativo { get; set; }

    public virtual ICollection<Estrutura> Estruturas { get; set; } = new List<Estrutura>();
}
