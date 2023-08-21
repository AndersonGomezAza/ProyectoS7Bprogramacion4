using System;
using System.Collections.Generic;

namespace CrMercantil.Models;

public partial class ContratoInmueble
{
    public int IdContrato { get; set; }

    public string MatriculaInmobiliariaInmueble { get; set; } = null!;

    public virtual ContratoArriendo IdContratoNavigation { get; set; } = null!;

    public virtual Inmueble MatriculaInmobiliariaInmuebleNavigation { get; set; } = null!;
}
