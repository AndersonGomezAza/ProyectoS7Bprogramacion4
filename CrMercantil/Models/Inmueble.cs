using System;
using System.Collections.Generic;

namespace CrMercantil.Models;

public partial class Inmueble
{
    public string MatriculaInmobiliariaInmueble { get; set; } = null!;

    public string ChipInmueble { get; set; } = null!;

    public string TipoInmueble { get; set; } = null!;

    public string NomenclaruraInmueble { get; set; } = null!;

    public decimal AreaPrivadaInmueble { get; set; }

    public decimal AreaConstruidaInmueble { get; set; }

    public string NumeroEscrituraInmueble { get; set; } = null!;

    public int AlcobasInmueble { get; set; }

    public int BañosInmueble { get; set; }

    public int VehiculoInmueble { get; set; }

    public int IdLocativaInmueble { get; set; }

    public int CedulaPropietarioInmueble { get; set; }

    public int MatriculaInmobiliariaProyectoInmueble { get; set; }

    public virtual Propietario CedulaPropietarioInmuebleNavigation { get; set; } = null!;

    public virtual ArregloLocativo IdLocativaInmuebleNavigation { get; set; } = null!;

    public virtual Proyecto MatriculaInmobiliariaProyectoInmuebleNavigation { get; set; } = null!;
}
