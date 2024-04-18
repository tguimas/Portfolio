using System;
using System.Collections.Generic;

namespace GestaoParquesAPI.Models;

public partial class Funcionario
{
    public int IdFuncionario { get; set; }

    public int? IdParque { get; set; }

    public int? IdUser { get; set; }

    public string? NomeFuncionario { get; set; }

    public DateTime? DataNascimento { get; set; }

    public DateTime? DataAdmissao { get; set; }

    public DateTime DataCriacao { get; set; }

    public DateTime DataAtualizacao { get; set; }

    public bool Inativo { get; set; }

    public virtual ICollection<HistoricoOcorrencium> HistoricoOcorrencia { get; set; } = new List<HistoricoOcorrencium>();

    public virtual Parque? IdParqueNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
