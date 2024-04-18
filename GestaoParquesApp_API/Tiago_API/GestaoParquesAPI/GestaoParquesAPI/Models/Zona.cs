using System;
using System.Collections.Generic;

namespace GestaoParquesAPI.Models;

public partial class Zona
{
    public int IdZona { get; set; }

    public int? IdParque { get; set; }

    public int? IdQrCode { get; set; }

    public string NomeZona { get; set; } = null!;

    public int NumeroZona { get; set; }

    public string Cor { get; set; } = null!;

    public DateTime DataCriacao { get; set; }

    public DateTime DataAtualizacao { get; set; }

    public bool Inativo { get; set; }

    public virtual ICollection<Estrutura> Estruturas { get; set; } = new List<Estrutura>();

    public virtual Parque? IdParqueNavigation { get; set; }

    public virtual QrCode? IdQrCodeNavigation { get; set; }

    public virtual ICollection<Ocorrencium> Ocorrencia { get; set; } = new List<Ocorrencium>();

    public virtual ICollection<ZonaFauna> ZonaFaunas { get; set; } = new List<ZonaFauna>();

    public virtual ICollection<ZonaFlora> ZonaFloras { get; set; } = new List<ZonaFlora>();

    public virtual ICollection<ZonaRio> ZonaRios { get; set; } = new List<ZonaRio>();
}
