using System;
using System.Collections.Generic;

namespace CrMercantil.Models;

public partial class ContratoArriendo
{
    public int IdContrato { get; set; }

    public DateTime FechaInicioContrato { get; set; }

    public decimal ValorCanonContrato { get; set; }

    public decimal ValorAdministracionContrato { get; set; }

    public int RcPagosContrato { get; set; }

    public int CedulaArrendatarioContrato { get; set; }

    public virtual Arrendatario CedulaArrendatarioContratoNavigation { get; set; } = null!;

    public virtual Pago RcPagosContratoNavigation { get; set; } = null!;
}
