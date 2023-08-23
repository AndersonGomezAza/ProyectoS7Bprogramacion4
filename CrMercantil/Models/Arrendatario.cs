using System;
using System.Collections.Generic;

namespace CrMercantil.Models;

public partial class Arrendatario
{
    public int CedulaArrendatario { get; set; }

    public string NombreArrendatario { get; set; } = null!;

    public string ApellidoArrendatario { get; set; } = null!;

    public int TelefonoArrendatario { get; set; }

    public string? CorreoArrendatario { get; set; }

    public virtual ICollection<ContratoArriendo> ContratoArriendos { get; set; } = new List<ContratoArriendo>();
}
