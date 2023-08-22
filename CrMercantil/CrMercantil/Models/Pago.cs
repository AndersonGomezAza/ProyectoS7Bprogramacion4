using System;
using System.Collections.Generic;

namespace CrMercantil.Models;

public partial class Pago
{
    public int RcPagos { get; set; }

    public int FacturaPagos { get; set; }

    public DateTime FechaPagos { get; set; }

    public DateTime FechaAbonoCanonPagos { get; set; }

    public decimal AbonoAdministracionPagos { get; set; }

    public decimal InteresPagos { get; set; }

    public decimal TasaInteresPagos { get; set; }

    public virtual ICollection<ContratoArriendo> ContratoArriendos { get; set; } = new List<ContratoArriendo>();
}
