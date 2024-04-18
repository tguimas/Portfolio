using System;
using System.Collections.Generic;

namespace GestaoParquesAPI.Models;

public partial class Parque
{
    public int IdParque { get; set; }

    public int IdCodPostal { get; set; }

    public string NomeParque { get; set; } = null!;

    public double Dimensao { get; set; }

    public DateTime DataCriacao { get; set; }

    public DateTime DataAtualizacao { get; set; }

    public bool Inativo { get; set; }

    public virtual ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

    public virtual CodigoPostal IdCodPostalNavigation { get; set; } = null!;

    public virtual ICollection<Zona> Zonas { get; set; } = new List<Zona>();
}
