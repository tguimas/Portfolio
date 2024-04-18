using System;
using System.Collections.Generic;

namespace GestaoParquesAPI.Models;

public partial class QrCode
{
    public int IdQrCode { get; set; }

    public DateOnly DataCriacaoQr { get; set; }

    public DateOnly? DataExpiracaoQr { get; set; }

    public string Link { get; set; } = null!;

    public DateTime DataCriacao { get; set; }

    public DateTime DataAtualizacao { get; set; }

    public bool Inativo { get; set; }

    public virtual ICollection<Zona> Zonas { get; set; } = new List<Zona>();
}
