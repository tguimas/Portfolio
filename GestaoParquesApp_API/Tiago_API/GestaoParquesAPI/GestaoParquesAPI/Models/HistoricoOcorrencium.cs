using System;
using System.Collections.Generic;

namespace GestaoParquesAPI.Models;

public partial class HistoricoOcorrencium
{
    public int IdStatusOcorrencia { get; set; }

    public int IdFuncionario { get; set; }

    public int IdOcorrencia { get; set; }

    public DateTime DataModificacao { get; set; }

    public string Descricao { get; set; } = null!;

    public DateTime DataCriacao { get; set; }

    public DateTime DataAtualizacao { get; set; }

    public bool Inativo { get; set; }

    public virtual Funcionario IdFuncionarioNavigation { get; set; } = null!;

    public virtual Ocorrencium IdOcorrenciaNavigation { get; set; } = null!;

    public virtual StatusOcorrencium IdStatusOcorrenciaNavigation { get; set; } = null!;
}
