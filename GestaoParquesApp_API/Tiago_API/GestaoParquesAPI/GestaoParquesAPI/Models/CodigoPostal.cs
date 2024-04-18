using System;
using System.Collections.Generic;

namespace GestaoParquesAPI.Models;

public partial class CodigoPostal
{
    public int IdCodPostal { get; set; }

    public int CodPostal { get; set; }

    public string Concelho { get; set; } = null!;

    public string Freguesia { get; set; } = null!;

    public string Rua { get; set; } = null!;

    public int Numero { get; set; }

    public double Lat { get; set; }

    public double Long { get; set; }

    public DateTime DataCriacao { get; set; }

    public DateTime DataAtualizacao { get; set; }

    public bool Inativo { get; set; }

    public virtual ICollection<Parque> Parques { get; set; } = new List<Parque>();
}
