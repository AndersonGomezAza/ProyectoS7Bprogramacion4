using System;
using System.Collections.Generic;

namespace CrMercantil.Models;

public partial class Proyecto
{
    public int MatriculaInmobiliariaProyecto { get; set; }

    public string NombreProyecto { get; set; } = null!;

    public string DireccionProyecto { get; set; } = null!;

    public int EstratoProyecto { get; set; }

    public string EscrituraReglamentoProyecto { get; set; } = null!;

    public string AdministradorProyecto { get; set; } = null!;

    public string TelefonoAdministradorProyecto { get; set; } = null!;

    public string? CorreoAdministradorProyecto { get; set; }

    public virtual ICollection<Inmueble> Inmuebles { get; set; } = new List<Inmueble>();
}
