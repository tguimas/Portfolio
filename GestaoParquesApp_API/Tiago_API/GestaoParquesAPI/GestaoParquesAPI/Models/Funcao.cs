using System;
using System.Collections.Generic;

namespace GestaoParquesAPI.Models;

public partial class Funcao
{
    public int IdFuncao { get; set; }

    public string NomeFuncao { get; set; } = null!;

    public DateTime DataCriacao { get; set; }

    public DateTime DataAtualizacao { get; set; }

    public bool Inativo { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
