using System;
using System.Collections.Generic;

namespace MagazinComponentePC.Models.DBObjects;

public partial class DetaliiComanda
{
    public Guid DetaliiId { get; set; }

    public Guid? ComandaId { get; set; }

    public Guid? ProdusId { get; set; }

    public int Cantitate { get; set; }

    public decimal PretProdus { get; set; }

    public virtual Comenzi? Comanda { get; set; }

    public virtual Produse? Produs { get; set; }
}
