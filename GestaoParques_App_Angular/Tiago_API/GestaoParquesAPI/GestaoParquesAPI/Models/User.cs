using System;
using System.Collections.Generic;

namespace GestaoParquesAPI.Models;

public partial class User
{
    public int IdUser { get; set; }

    public int? IdFuncao { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime DataCriacao { get; set; }

    public DateTime DataAtualizacao { get; set; }

    public bool Inativo { get; set; }

    public virtual Funcionario? Funcionario { get; set; }

    public virtual Funcao? IdFuncaoNavigation { get; set; }
}
