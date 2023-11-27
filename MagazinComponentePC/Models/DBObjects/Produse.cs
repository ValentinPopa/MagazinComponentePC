using System;
using System.Collections.Generic;

namespace MagazinComponentePC.Models.DBObjects;

public partial class Produse
{
    public Guid ProdusId { get; set; }

    public string NumeProdus { get; set; } = null!;

    public string? Descriere { get; set; }

    public decimal Pret { get; set; }

    public int Stoc { get; set; }

    public virtual ICollection<DetaliiComanda> DetaliiComanda { get; set; } = new List<DetaliiComanda>();
}
