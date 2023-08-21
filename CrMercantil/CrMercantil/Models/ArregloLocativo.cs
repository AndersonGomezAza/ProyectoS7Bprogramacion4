using System;
using System.Collections.Generic;

namespace CrMercantil.Models;

public partial class ArregloLocativo
{
    public int IdLocativaArreglo { get; set; }

    public DateTime FechaInicioArreglo { get; set; }

    public DateTime? FechaFinalizacionArreglo { get; set; }

    public string EstadoArreglo { get; set; } = null!;

    public string ObservacionesArreglo { get; set; } = null!;

    public virtual ICollection<Inmueble> Inmuebles { get; set; } = new List<Inmueble>();
}
