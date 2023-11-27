using System;
using System.Collections.Generic;

namespace MagazinComponentePC.Models.DBObjects;

public partial class Comenzi
{
    public Guid ComandaId { get; set; }

    public Guid? UserId { get; set; }

    public DateTime DataComanda { get; set; }

    public string Stare { get; set; } = null!;

    public virtual ICollection<DetaliiComanda> DetaliiComanda { get; set; } = new List<DetaliiComanda>();

    public virtual Utilizatori? User { get; set; }
}
