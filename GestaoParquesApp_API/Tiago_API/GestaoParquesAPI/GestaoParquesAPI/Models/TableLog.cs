using System;
using System.Collections.Generic;

namespace GestaoParquesAPI.Models;

public partial class TableLog
{
    public int LogId { get; set; }

    public int? TransactionId { get; set; }

    public string? UserId { get; set; }

    public DateTime? Data { get; set; }

    public int? Status { get; set; }

    public string? Observacao { get; set; }
}
