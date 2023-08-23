using System;
using System.Collections.Generic;

namespace CrMercantil.Models;

public partial class Propietario
{
    public int CedulaPropietario { get; set; }

    public string NombrePropietario { get; set; } = null!;

    public string ApellidoPropietario { get; set; } = null!;

    public int TelefonoPropietario { get; set; }

    public string? CorreoPropietario { get; set; }

    public int CuentaBancariaPropietario { get; set; }

    public string? TipoCuentaPropietario { get; set; }

    public string? NombreBancoPropietario { get; set; }

    public virtual ICollection<Inmueble> Inmuebles { get; set; } = new List<Inmueble>();
}
